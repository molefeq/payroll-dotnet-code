using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.Tests.UnitsTests.ModelAdapters
{
    [TestClass]
    public class RoleAdapterTest
    {
        private RoleAdapter roleAdapter;
        
        [TestInitialize]
        public void Before()
        {
            roleAdapter = new RoleAdapter();
        }

        [TestMethod]
        public void Role_Should_Be_Updated_By_RoleModel()
        {
            var role = RoleTestData.GetUserRole();
            var roleModel = RoleTestData.GetUpdateUserRoleModel();

            roleAdapter.Update(role, roleModel);

            Assert.AreEqual(role.Name, roleModel.Name);
            Assert.AreEqual(role.Code, roleModel.Code);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Role_Update_Should_Throw_Exception_When_RoleModel_Null()
        {
            var role = RoleTestData.GetUserRole();

            roleAdapter.Update(role, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Role_Update_Should_Throw_Exception_When_Role_Null()
        {
            var roleModel = RoleTestData.GetUpdateUserRoleModel();

            roleAdapter.Update(null, roleModel);
        }

    }
}
