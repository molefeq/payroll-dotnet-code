using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.DataAccess.Tests.UnitTests.Repositories
{
    [TestClass]
    public class CountryRepositoryTest
    {
        private IntergrationTestsSetup IntergrationTestsSetup { get; set; }

        [TestInitialize]
        public void Before()
        {
            IntergrationTestsSetup = new IntergrationTestsSetup();
        }

        [TestMethod]
        public void Test_Country_Insert()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var country = new Country { Name = "South Africa", Code = "ZA" };

                context.Country.Add(country);
                context.SaveChanges();

                Assert.IsTrue(country.Id > 0);
            }
        }
    }
}
