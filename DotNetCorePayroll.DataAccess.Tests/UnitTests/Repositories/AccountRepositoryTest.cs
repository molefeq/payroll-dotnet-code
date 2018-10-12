using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Tests.Setup;
using DotNetCorePayroll.DataAccess.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DotNetCorePayroll.DataAccess.Tests.UnitTests.Repositories
{
    [TestClass]
    public class AccountRepositoryTest
    {
        private IntergrationTestsSetup IntergrationTestsSetup { get; set; }

        [TestInitialize]
        public void Before()
        {
            IntergrationTestsSetup = new IntergrationTestsSetup();
        }

        [TestMethod]
        public void Get_Accounts_Initial_Count_Should_Be_One()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var accountsCount = unitOfWork.Account.CountEntities();

                Assert.IsTrue(accountsCount == 1);
            }
        }

        [TestMethod]
        public void Should_Add_New_Account()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                Account account = AccountTestData.GetAddTestAccount();

                unitOfWork.Account.Insert(account);
                unitOfWork.Save();

                Assert.IsTrue(account.Id > 0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Account_Add_Existing_Username_Should_Throw_Exception()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var account = AccountTestData.GetTestAccount();

                unitOfWork.Account.Insert(account);
                unitOfWork.Save();
            }
        }
    }
}
