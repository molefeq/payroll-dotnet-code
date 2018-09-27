using DotNetCorePayroll.DataAccess.Tests.Setup;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

namespace DotNetCorePayroll.DataAccess.Tests.UnitTests.Repositories
{
    [TestClass]
    public class AddressRepositoryTest
    {
        private IntergrationTestsSetup IntergrationTestsSetup { get; set; }


        [TestInitialize]
        public void Before()
        {
            IntergrationTestsSetup = new IntergrationTestsSetup();
        }

        [TestMethod]
        public void Test_Address_Fetch()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var addresses = context.Address.ToList();

                Assert.IsTrue(addresses.Count == 0);
            }
        }
    }
}
