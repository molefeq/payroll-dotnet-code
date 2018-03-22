using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.Console.Service
{
    public class AccountServiceInvoker
    {
        private IAccountService accountService;

        public AccountServiceInvoker(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        
        #region Service Methods

        public void CreateAccount()
        {
            var response = this.accountService.Create(CreateAccountModel(), null);
        }

        public void Login()
        {
            var response = this.accountService.Login(new LoginModel { Username = "molefeq@gmail.com", Password = "-eFjiLcL" });
        }


        #endregion

        #region Create Test Objects

        private AccountModel CreateAccountModel()
        {
            return new AccountModel
            {
                Username = "molefeq",
                Firstname = "Elvis",
                Lastname = "Molefe",
                EmailAddress = "molefeq@hotmail.com",
                ContactNumber = "0846750090",
                OrganisationId = 2,
                RoleId = 1,
                CreateUserId = 2
            };
        }
        #endregion
    }
}
