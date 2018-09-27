using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using DotNetCorePayroll.ServiceBusinessRules.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.ServiceBusinessRules.Tests.UnitsTests.ModelBuilders
{
    [TestClass]
    public class RoleBuilderTest
    {
        private RoleBuilder roleBuilder;

        [TestInitialize]
        public void Before()
        {
            roleBuilder = new RoleBuilder();
        }

        [TestMethod]
        public void Role_Should_Be_Created_By_RoleModel()
        {
            var roleModel = RoleTestData.GetUpdateUserRoleModel();

            var role = roleBuilder.Build(roleModel);

            Assert.AreEqual(role.Name, roleModel.Name);
            Assert.AreEqual(role.Code, roleModel.Code);
            Assert.AreEqual(role.Id, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Role_Create_Should_Throw_Exception_When_RoleModel_Null()
        {
            var role = roleBuilder.Build(null);
        }

        [TestMethod]
        public void RoleModel_Should_Be_Created_By_Role()
        {
            var role = RoleTestData.GetAdminRole();

            var roleModel = roleBuilder.BuildModel(role);

            Assert.AreEqual(role.Name, roleModel.Name);
            Assert.AreEqual(role.Code, roleModel.Code);
            Assert.AreEqual(role.Id, roleModel.Id);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void RoleModel_Create_Should_Throw_Exception_When_Role_Null()
        {
            var roleModel = roleBuilder.BuildModel(null);
        }
    }
}
