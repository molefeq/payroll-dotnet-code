using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Tests.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetCorePayroll.DataAccess.Tests.IntergrationTests
{
    [TestClass]
    public class RoleTest
    {
        private IntergrationTestsSetup IntergrationTestsSetup { get; set; }

        [TestInitialize]
        public void Before()
        {
            IntergrationTestsSetup = new IntergrationTestsSetup();
        }

        [TestMethod]
        public void Test_Role_Fetch()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var roles = context.Role.ToList();

                Assert.IsTrue(roles.Count == 0);
            }
        }

        [TestMethod]
        public void Test_Role_Role_Insert()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var role = new Role
                {
                    Name = "Admin",
                    Code = "ADMIN"
                };

                context.Role.Add(role);
                context.SaveChanges();

                var roles = context.Role.ToList();
                Assert.IsTrue(roles.Count == 0);
            }
        }
    }
}