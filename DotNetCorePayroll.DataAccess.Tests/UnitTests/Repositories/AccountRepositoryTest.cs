using DotNetCorePayroll.DataAccess.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void Get_Returns_Accounts()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var accounts = context.Account.ToList();

                Assert.IsTrue(accounts.Count == 0);
            }
        }
    }
}
