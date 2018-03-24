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
            Account account = new Account
            {
                Username = accountModel.Username,
                Firstname = accountModel.Firstname,
                Lastname = accountModel.Lastname,
                EmailAddress = accountModel.EmailAddress,
                ContactNumber = accountModel.ContactNumber,
                RoleId = accountModel.RoleId.Value,
                OrganisationId = accountModel.OrganisationId.Value,
                CompanyId = accountModel.CompanyId,
                CreateUserId = accountModel.CreateUserId,
                CreateDate = DateTime.Now,
                IsFirstTimeLogin = true,
                PasswordSalt = GeneratePassword.PasswordSalt()
            };

            account.Password = GeneratePassword.HashedPassword(accountModel.Password, account.PasswordSalt);

            return account;
        }

        public AccountModel BuildToAccountModel(Account account)
        {
            AccountModel accountModel = new AccountModel
            {
                Id = account.Guid,
                Username = account.Username,
                Firstname = account.Firstname,
                Lastname = account.Lastname,
                EmailAddress = account.EmailAddress,
                ContactNumber = account.ContactNumber,
                RoleId = account.RoleId,
                OrganisationId = account.OrganisationId,
                CompanyId = account.CompanyId,
                CreateUserId = account.CreateUserId,
                ForgotPasswordKey = account.PasswordResetKey
            };

            return accountModel;
        }

        public UserModel BuildToUserModel(Account account)
        {
            UserModel userModel = new UserModel
            {
                Id = account.Id,
                UserName = account.Username,
                OrganisationId = account.OrganisationId,
                OrganisationName = account.Organisation.Name,
                CompanyId = account.CompanyId,
                CompanyName = account.Company == null ? null : account.Company.Name,
                RoleId = account.RoleId,
                RoleName = account.Role.Name,
                IsFirstTimeLogIn = account.IsFirstTimeLogin
            };

            return userModel;
        }
    }
}
