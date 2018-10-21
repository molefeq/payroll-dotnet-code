using DotNetCorePayroll.Common.Exceptions;

using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess.Repositories;

using SqsLibraries.Common.Utilities;
using SqsLibraries.Common.Utilities.ResponseObjects;

using System;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Account
{
    public class AccountBusinessRules
    {
        public void LoginCheck(LoginModel loginModel, AccountRepository accountRepository)
        {
            if (string.IsNullOrEmpty(loginModel.Username) || string.IsNullOrEmpty(loginModel.Password))
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Username and password is required."));
            }

            var account = accountRepository.GetById(a => a.Username == loginModel.Username);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Username or Password is incorrect."));
            }

            byte[] hashedPassword = GeneratePassword.HashedPassword(loginModel.Password, account.PasswordSalt);

            account = accountRepository.GetById(a => a.Username == loginModel.Username && a.Password == hashedPassword);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Username or Password is incorrect."));
            }
        }

        public void ResetPasswordRequestCheck(string username, AccountRepository accountRepository)
        {
            var account = accountRepository.GetById(a => a.Username == username);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Password reset failed, user does not exists."));
            }
        }

        public void ChangePasswordCheck(string username, string oldPassword, AccountRepository accountRepository)
        {
            var account = accountRepository.GetById(a => a.Username == username);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Password change failed, user does not exists."));
            }

            byte[] hashedPassword = GeneratePassword.HashedPassword(oldPassword, account.PasswordSalt);

            account = accountRepository.GetById(a => a.Username == username && a.Password == hashedPassword);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Password change failed, username or old password is incorrect."));
            }
        }

        public void ResetPasswordCheck(Guid forgotPasswordKey, AccountRepository accountRepository)
        {
            var account = accountRepository.GetById(a => a.PasswordResetKey == forgotPasswordKey);

            if (account == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Reset Password change failed, user does not exists."));
            }
        }

        public void CreateCheck(AccountModel accountModel, AccountRepository accountRepository)
        {
            if (accountModel == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("The account entry you trying to create does not exist."));
            }

            if (accountRepository.GetById(a => a.Username.Equals(accountModel.Username)) != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Username", "Username is currently being used another user."));
            }

            if (accountRepository.GetById(a => a.EmailAddress.Equals(accountModel.EmailAddress)) != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("EmailAddress", "Email address is currently being used another user."));
            }
        }

        public void UpdateCheck(AccountModel accountModel, AccountRepository accountRepository)
        {
            if (accountModel == null || accountModel.Id == null || accountModel.Id.Value == Guid.Empty ||
                accountRepository.GetById(a => a.Guid == accountModel.Id.Value && a.DisableDate == null) == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("The account entry you trying to update does not exist."));
            }

            if (accountRepository.GetById(a => a.Guid != accountModel.Id.Value && a.Username.Equals(accountModel.Username)) != null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Username", "Username is currently being used another account."));
            }
        }

    }
}
