using DotNetCorePayroll.Data.ViewModels;

using Microsoft.Extensions.Configuration;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface IAccountService
    {
        UserModel Login(LoginModel loginModel);
        UserModel ChangePassword(string username, string password);
        AccountModel PasswordResetRequest(string username, IConfiguration configuration);
        UserModel ResetPassword(Guid forgotPasswordKey, string password);
        AccountModel GetAccountByUsername(string username);

        AccountModel Create(AccountModel accountModel, IConfiguration configuration);
        AccountModel Read(long accountId);
        AccountModel Update(AccountModel accountModel);
        void Delete(AccountModel accountModel);
    }
}
