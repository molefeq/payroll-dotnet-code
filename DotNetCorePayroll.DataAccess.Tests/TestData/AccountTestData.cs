using DotNetCorePayroll.Data;
using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.DataAccess.Tests.TestData
{
    public class AccountTestData
    {
        public static List<Account> InitialAccounts()
        {
            return new List<Account>
            {
                GetTestAccount()
            };
        }

        public static Account GetTestAccount()
        {
            return new Account
            {
                Id = 10,
                OrganisationId = 1,
                Username = "TestUser",
                Lastname = "Molefe",
                EmailAddress = "molefeq@gmail.com",
                ContactNumber = "0114478965",
                RoleId = 1,
                Guid = Guid.NewGuid(),
                IsFirstTimeLogin = false
            };
        }

        public static Account GetAddTestAccount()
        {
            return new Account
            {
                OrganisationId = 1,
                Username = "AddTestUser",
                Lastname = "Molefe",
                EmailAddress = "molefeq@gmail.com",
                ContactNumber = "0114478965",
                RoleId = 1,
                Guid = Guid.NewGuid(),
                IsFirstTimeLogin = false
            };
        }
    }
}
