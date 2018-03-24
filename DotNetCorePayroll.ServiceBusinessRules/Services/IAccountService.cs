using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;

using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Utilities.ResponseObjects;

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

        Result<AccountModel> Get(AccountSearchFilter accountSearchFilter);
        AccountModel Create(AccountModel accountModel, IConfiguration configuration);
        AccountModel Read(Guid accountId);
        AccountModel Update(AccountModel accountModel);
        void Delete(Guid accountId);
    }
}
