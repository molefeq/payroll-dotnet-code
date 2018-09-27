using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.DataAccess.Repositories;
using DotNetCorePayroll.ServiceBusinessRules.Services.Role;
using DotNetCorePayroll.ServiceBusinessRules.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq.Expressions;

namespace DotNetCorePayroll.ServiceBusinessRules.Tests.UnitsTests.Services.Role
{
    [TestClass]
    public class RoleBusinessRulesTest
    {
        private RoleBusinessRules roleBusinessRules;
        private Mock<RoleRepository> roleRepository;


        [TestInitialize]
        public void Before()
        {
            roleBusinessRules = new RoleBusinessRules();
            roleRepository = new Mock<RoleRepository>();
        }

        [TestCategory("Create_Check"), TestMethod]
        public void Role_Create_Check_Should_Succeed()
        {
            var roleModel = RoleTestData.GetUserRoleModel();
            var role = RoleTestData.GetNullRole();

            roleRepository.Setup(r => r.GetById(a => a.Name == roleModel.Name)).Returns(role);
            roleRepository.Setup(r => r.GetById(a => a.Code == roleModel.Code)).Returns(role);

            roleBusinessRules.CreateCheck(roleModel, roleRepository.Object);
        }

        [TestCategory("Create_Check"), TestMethod]
        [ExpectedException(typeof(ResponseValidationException))]
        public void Role_Create_Check_Should_Fail_If_Role_Name_Already_Exist()
        {
            var roleModel = RoleTestData.GetUserRoleModel();
            var role = RoleTestData.GetUserRole();

            roleRepository.Setup(r => r.GetById(It.Is<Expression<Func<Data.Role, bool>>>(e => AreEqual(e, "roleModel.Name")))).Returns(role);

            roleBusinessRules.CreateCheck(roleModel, roleRepository.Object);
            roleRepository.Verify(r => r.GetById(It.IsAny<Expression<Func<Data.Role, bool>>>()), Times.Once);
        }

        [TestCategory("Create_Check"), TestMethod]
        [ExpectedException(typeof(ResponseValidationException))]
        public void Role_Create_Check_Should_Fail_If_Role_Code_Already_Exist()
        {
            var roleModel = RoleTestData.GetUserRoleModel();
            var role = RoleTestData.GetUserRole();

            roleRepository.Setup(r => r.GetById(It.Is<Expression<Func<Data.Role, bool>>>(e => AreEqual<Data.Role, bool>(e, "roleModel.Name")))).Returns(RoleTestData.GetNullRole());
            roleRepository.Setup(r => r.GetById(It.Is<Expression<Func<Data.Role, bool>>>(e => AreEqual<Data.Role, bool>(e, "roleModel.Code")))).Returns(role);

            roleBusinessRules.CreateCheck(roleModel, roleRepository.Object);
            roleRepository.Verify(r => r.GetById(It.IsAny<Expression<Func<Data.Role, bool>>>()), Times.Exactly(2));
        }

        [TestCategory("Update_Check"), TestMethod]
        public void Role_Update_Check_Should_Succeed()
        {
            var roleModel = RoleTestData.GetUserRoleModel();
            var role = RoleTestData.GetUserRole();

            roleRepository.Setup(r => r.GetById(It.Is<Expression<Func<Data.Role, bool>>>(e => AreEqual<Data.Role, bool>(e, "roleModel.Id")))).Returns(role);
            roleRepository.Setup(r => r.GetById(It.Is<Expression<Func<Data.Role, bool>>>(e => AreEqual<Data.Role, bool>(e, "roleModel.Code")))).Returns(RoleTestData.GetNullRole());
            roleRepository.Setup(r => r.GetById(It.Is<Expression<Func<Data.Role, bool>>>(e => AreEqual<Data.Role, bool>(e, "roleModel.Name")))).Returns(RoleTestData.GetNullRole());

            roleBusinessRules.UpdateCheck(roleModel, roleRepository.Object);
        }

        public static bool AreEqual<T, K>(Expression<Func<T, K>> expr, string value)
        {
            string exprText = expr.ToString();

            return exprText.Contains(value);
        }

    }
}
