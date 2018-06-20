using DotNetCorePayroll.Api.ActionResultHelpers;
using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Api.Providers;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;

using DotNetCorePayroll.ServiceBusinessRules.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;

namespace DotNetCorePayroll.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : BaseController
    {
        private LoginProvider loginProvider;
        private IAccountService accountService;
        private IConfiguration configuration;

        public AccountController(LoginProvider loginProvider, IAccountService accountService, IConfiguration configuration)
        {
            this.loginProvider = loginProvider;
            this.accountService = accountService;
            this.configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 200)]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            var userModel = loginProvider.Login(model);

            return Ok(userModel);
        }

        [HttpPost("{username}")]
        public IActionResult ResetPasswordRequest([FromRoute] string username)
        {
            accountService.PasswordResetRequest(username, configuration);

            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 200)]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            var userModel = accountService.ResetPassword(model.ResetPasswordKey, model.Password);

            return Ok(userModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 200)]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            var userModel = accountService.ChangePassword(model.Username, model.Password);

            return Ok(userModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<AccountModel>), 200)]
        public IActionResult FetchAccounts([FromBody] AccountSearchFilter filter)
        {
            var results = accountService.Get(filter);

            return Ok(results);
        }


        [HttpPost]
        [ProducesResponseType(typeof(AccountModel), 200)]
        public IActionResult CreateAccount([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            model.CreateUserId = UserId;
            var accountModel = accountService.Create(model, configuration);

            return Ok(accountModel);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AccountModel), 200)]
        public IActionResult UpdateAccount([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }
            
            var accountModel = accountService.Update(model);

            return Ok(accountModel);
        }

        [HttpPost]
        public IActionResult DeleteAccount([FromBody] Guid accountId)
        {
            accountService.Delete(accountId);

            return Ok();
        }

        [HttpPost("{accountId}")]
        [ProducesResponseType(typeof(AccountModel), 200)]
        public IActionResult ReadAccount([FromRoute] Guid accountId)
        {
            var accountModel = accountService.Read(accountId);

            return Ok(accountModel);
        }
    }
}