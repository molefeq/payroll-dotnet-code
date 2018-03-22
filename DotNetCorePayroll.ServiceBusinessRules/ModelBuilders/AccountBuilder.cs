using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using SqsLibraries.Common.Utilities;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class AccountBuilder
    {
        public Account Build(AccountModel accountModel)
        {
            Account account = new Account();

            account.Username = accountModel.Username;
            account.Firstname = accountModel.Firstname;
            account.Lastname = accountModel.Lastname;
            account.EmailAddress = accountModel.EmailAddress;
            account.ContactNumber = accountModel.ContactNumber;
            account.RoleId = accountModel.RoleId;
            account.OrganisationId = accountModel.OrganisationId;
            account.CompanyId = accountModel.CompanyId;
            account.CreateUserId = accountModel.CreateUserId;
            account.CreateDate = DateTime.Now;
            account.IsFirstTimeLogin = true;
            account.PasswordSalt = GeneratePassword.PasswordSalt();
            account.Password = GeneratePassword.HashedPassword(accountModel.Password, account.PasswordSalt);

            return account;
        }

        public AccountModel BuildToAccountModel(Account account)
        {
            AccountModel accountModel = new AccountModel();

            accountModel.Username = account.Username;
            accountModel.Firstname = account.Firstname;
            accountModel.Lastname = account.Lastname;
            accountModel.EmailAddress = account.EmailAddress;
            accountModel.ContactNumber = account.ContactNumber;
            accountModel.RoleId = account.RoleId;
            accountModel.OrganisationId = account.OrganisationId;
            accountModel.CompanyId = account.CompanyId;
            accountModel.CreateUserId = account.CreateUserId;
            accountModel.ForgotPasswordKey = account.PasswordResetKey;


            return accountModel;
        }

        public UserModel BuildToUserModel(Account account)
        {
            UserModel userModel = new UserModel();

            userModel.Id = account.Id;
            userModel.UserName = account.Username;
            userModel.OrganisationId = account.OrganisationId;
            userModel.OrganisationName = account.Organisation.Name;
            userModel.CompanyId = account.CompanyId;
            userModel.CompanyName = account.Company == null ? null : account.Company.Name;
            userModel.RoleId = account.RoleId;
            userModel.RoleName = account.Role.Name;


            return userModel;
        }
    }
}
