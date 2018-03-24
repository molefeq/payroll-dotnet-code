using DotNetCorePayroll.Api.ActionResultHelpers;
using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Api.Providers;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System;

namespace DotNetCorePayroll.Api.Controllers
{
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
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            var userModel = loginProvider.Login(model);

            return new JsonResult(new { data = userModel });
        }

        [HttpPost("{username}")]
        public IActionResult ResetPasswordRequest([FromRoute] string username)
        {
            accountService.PasswordResetRequest(username, configuration);

            return Ok();
        }

        [HttpPost]
        public IActionResult ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            var userModel = accountService.ResetPassword(model.ResetPasswordKey, model.Password);

            return new JsonResult(new { data = userModel });
        }

        [HttpPost]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            var userModel = accountService.ChangePassword(model.Username, model.Password);

            return new JsonResult(new { data = userModel });
        }

        [HttpPost]
        public IActionResult FetchAccounts([FromBody] AccountSearchFilter filter)
        {
            var results = accountService.Get(filter);

            return new JsonResult(new { data = results });
        }


        [HttpPost]
        public IActionResult CreateAccount([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            model.CreateUserId = UserId;
            var accountModel = accountService.Create(model, configuration);

            return new JsonResult(new { data = accountModel });
        }

        [HttpPost]
        public IActionResult UpdateAccount([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }
            
            var accountModel = accountService.Update(model);

            return new JsonResult(new { data = accountModel });
        }

        [HttpPost]
        public IActionResult DeleteAccount([FromBody] Guid accountId)
        {
            accountService.Delete(accountId);

            return new JsonResult(new { ok = true });
        }

        [HttpPost("{accountId}")]
        public IActionResult ReadAccount([FromRoute] Guid accountId)
        {
            var accountModel = accountService.Read(accountId);

            return new JsonResult(new { data = accountModel });
        }
    }
}