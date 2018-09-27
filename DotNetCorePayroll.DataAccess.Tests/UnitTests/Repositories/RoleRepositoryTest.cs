using DotNetCorePayroll.DataAccess.Tests.Setup;
using DotNetCorePayroll.DataAccess.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetCorePayroll.DataAccess.Tests.IntergrationTests
{
    [TestClass]
    public class RoleRepositoryTest
    {
        private IntergrationTestsSetup IntergrationTestsSetup { get; set; }

        [TestInitialize]
        public void Before()
        {
            IntergrationTestsSetup = new IntergrationTestsSetup();
        }

        [TestMethod]
        public void Role_InitialCount_Should_Be_Two()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var roleCount = unitOfWork.Role.CountEntities();

                Assert.IsTrue(roleCount == 2);
            }
        }

        [TestMethod]
        public void Role_Add_Unique_Role_Should_Succeed()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetUserRole();

                unitOfWork.Role.Insert(role);
                unitOfWork.Save();

                Assert.IsTrue(role.Id > 0);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Role_Add_Null_Role_Should_Throw_Exception()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetNullRole();

                unitOfWork.Role.Insert(null);
                unitOfWork.Save();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [Ignore]
        public void Role_Add_Empty_Role_Should_Throw_Exception()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetEmptyRole();

                unitOfWork.Role.Insert(null);
                unitOfWork.Save();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Role_Add_Existing_Code_Role_Should_Throw_Exception()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetSuperAdminRole();

                unitOfWork.Role.Insert(role);
                unitOfWork.Save();
            }
        }

        [TestMethod]
        public void Role_Update_Existing_Role_Should_Succeed()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetAdminRole();

                role.Name = "Admin User";

                unitOfWork.Role.Update(role);
                unitOfWork.Save();

                Assert.IsTrue(role.Id == 2);
                Assert.IsTrue(role.Name.Equals("Admin User"));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Ignore]
        public void Role_Update_Existing_With_Existing_Code_Role_Should_Throw_Exception()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetAdminRole();

                role.Code = "Super_Admin";

                unitOfWork.Role.Update(role);
                unitOfWork.Save();
            }
        }

        [TestMethod]
        public void Role_Delete_Existing_Role_Should_Succeed()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var unitOfWork = new UnitOfWork(context);
                var role = RoleTestData.GetAdminRole();
                var roleCount = unitOfWork.Role.CountEntities();

                unitOfWork.Role.Delete(role);
                unitOfWork.Save();

                Assert.IsTrue(roleCount - 1 == unitOfWork.Role.CountEntities());
            }
        }
    }
}