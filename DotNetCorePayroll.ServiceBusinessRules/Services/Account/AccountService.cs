using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;

using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Email;
using SqsLibraries.Common.Utilities;
using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.Linq;
using System.Text;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Account
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork unitOfWork;
        private AccountBuilder accountBuilder;
        private AccountAdapter accountAdapter;
        private AccountBusinessRules accountBusinessRules;

        public AccountService(IUnitOfWork unitOfWork, AccountBuilder accountBuilder, AccountAdapter accountAdapter, AccountBusinessRules accountBusinessRules)
        {
            this.unitOfWork = unitOfWork;
            this.accountBuilder = accountBuilder;
            this.accountAdapter = accountAdapter;
            this.accountBusinessRules = accountBusinessRules;
        }

        public Result<AccountModel> Get(AccountSearchFilter accountSearchFilter)
        {
            var result = unitOfWork.Account.Get(accountSearchFilter);

            if (result == null)
            {
                new Result<AccountModel>();
            }

            return new Result<AccountModel>
            {
                TotalItems = result.TotalItems,
                Items = result.Items.Select(a => accountBuilder.BuildToAccountModel(a)).ToList()
            };
        }

        public AccountModel Read(Guid accountId)
        {
            var account = unitOfWork.Account.GetById(a => a.Guid == accountId, "Organisation, Company, Role");

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Account entry you trying to fetch does not exist."));
            }

            return accountBuilder.BuildToAccountModel(account);
        }

        public AccountModel Create(AccountModel accountModel, IConfiguration configuration)
        {
            accountBusinessRules.CreateCheck(accountModel, unitOfWork.Account);
            accountModel.Password = GeneratePassword.CreateRandomPassword();
            unitOfWork.Account.Insert(accountBuilder.Build(accountModel));
            unitOfWork.Save();

            //SendCreateAccountEmail(accountModel, configuration);

            return GetAccountByUsername(accountModel.Username);
        }

        public AccountModel Update(AccountModel accountModel)
        {
            accountBusinessRules.UpdateCheck(accountModel, unitOfWork.Account);

            var account = unitOfWork.Account.GetById(a => a.Guid == accountModel.Id.Value);

            accountAdapter.Update(account, accountModel);
            unitOfWork.Account.Update(account);
            unitOfWork.Save();

            return GetAccountByUsername(accountModel.Username);
        }

        public void Delete(Guid accountId)
        {
            var account = unitOfWork.Account.GetById(a => a.Guid == accountId && a.DisableDate == null);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("The account entry you trying to delete does not exist."));
            }

            account.DisableDate = DateTime.Now;

            unitOfWork.Account.Update(account);

            unitOfWork.Save();
        }

        public AccountModel GetAccountByUsername(string username)
        {
            var account = unitOfWork.Account.GetById(a => a.Username == username, "Organisation, Company, Role");

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Account entry you trying to fetch does not exist."));
            }

            return accountBuilder.BuildToAccountModel(account);
        }

        public UserModel Login(LoginModel loginModel)
        {
            accountBusinessRules.LoginCheck(loginModel, unitOfWork.Account);

            var account = unitOfWork.Account.GetById(a => a.Username == loginModel.Username, "Company, Organisation, Role");

            return accountBuilder.BuildToUserModel(account);
        }

        public AccountModel PasswordResetRequest(string username, IConfiguration configuration)
        {
            AccountModel accountModel = null;
            accountBusinessRules.ResetPasswordRequestCheck(username, unitOfWork.Account);

            var account = unitOfWork.Account.GetById(a => a.Username == username, "Company, Organisation, Role");

            account.PasswordResetKey = Guid.NewGuid();
            unitOfWork.Account.Update(account);

            accountModel = accountBuilder.BuildToAccountModel(account);
            // SendResetPasswordEmail(accountModel, configuration);

            return accountModel;
        }

        public UserModel ChangePassword(string username, string password)
        {
            accountBusinessRules.ChangePasswordCheck(username, unitOfWork.Account);

            var account = unitOfWork.Account.GetById(a => a.Username == username, "Organisation, Company, Role");

            account.PasswordSalt = GeneratePassword.PasswordSalt();
            account.Password = GeneratePassword.HashedPassword(password, account.PasswordSalt);

            unitOfWork.Account.Update(account);

            return accountBuilder.BuildToUserModel(account);
        }

        public UserModel ResetPassword(Guid forgotPasswordKey, string password)
        {
            accountBusinessRules.ResetPasswordCheck(forgotPasswordKey, unitOfWork.Account);

            var account = unitOfWork.Account.GetById(a => a.PasswordResetKey == forgotPasswordKey, "Organisation, Company, Role");

            account.PasswordSalt = GeneratePassword.PasswordSalt();
            account.Password = GeneratePassword.HashedPassword(password, account.PasswordSalt);

            unitOfWork.Account.Update(account);

            return accountBuilder.BuildToUserModel(account);
        }

        #region Private Methods

        private void SendCreateAccountEmail(AccountModel accountModel, IConfiguration configuration)
        {
            string smtpServerAddress = configuration.SmtpAddress();
            int smtpPortNumber = configuration.SmtpPortNumber();
            string fromAddress = configuration.FromAddress();

            string subject = string.Format("{0} Email notification ... Welcome to {0}!", configuration.SiteName());

            StringBuilder sb = new StringBuilder();

            // Add email heading
            sb.Append(string.Format("Dear {0} User.", configuration.ApplicationName()));
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append(string.Format("This Email confirms that your unique profile has been created with the following credentials."));
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append(string.Format("Username: {0}", accountModel.Username));
            sb.Append("<br />");
            sb.Append(string.Format("Password: {0}", accountModel.Password));
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("Follow the steps to finalize your profile.");
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("<ol>");
            sb.Append(string.Format("<li>Log on to {0} by clicking on this link <a href='{1}'>{1}</a></li>", configuration.SiteName(), configuration.SiteUrl()));
            sb.Append("<li>Insert your credentials as provided in this email and follow the change password steps.</li>");
            sb.Append("</ol>");

            EmailHandler.SendEmail(smtpServerAddress, smtpPortNumber, fromAddress, accountModel.EmailAddress, null, subject, sb.ToString());
        }

        private void SendResetPasswordEmail(AccountModel accountModel, IConfiguration configuration)
        {
            string smtpServerAddress = configuration.SmtpAddress();
            int smtpPortNumber = configuration.SmtpPortNumber();
            string fromAddress = configuration.FromAddress();

            string subject = string.Format("{0} Email notification ... Password Reset to {1}!", configuration.ApplicationName(), configuration.SiteName());
            string siteLink = configuration.PasswordResetUrl() + "?key=" + accountModel.ForgotPasswordKey.Value.ToString();

            StringBuilder sb = new StringBuilder();

            // Add email heading
            sb.Append(string.Format("Dear {0} User.", configuration.ApplicationName()));
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append(string.Format("This Email confirms that you have requested a password reset please click the below link to reset your password."));
            sb.Append("<br />");
            sb.Append(string.Format("<a href='{0}'>Click Here</a>", siteLink));
            sb.Append("<br />");

            EmailHandler.SendEmail(smtpServerAddress, smtpPortNumber, fromAddress, accountModel.EmailAddress, null, subject, sb.ToString());
        }

        #endregion
    }
}
