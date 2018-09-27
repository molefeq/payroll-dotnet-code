using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.DataAccess.Repositories;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using DotNetCorePayroll.ServiceBusinessRules.Services.Role;
using DotNetCorePayroll.ServiceBusinessRules.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq.Expressions;

namespace DotNetCorePayroll.ServiceBusinessRules.Tests.UnitsTests.Services.Role
{
    [TestClass]
    public class RoleServiceTest
    {
        private RoleService roleService;
        private Mock<RoleBusinessRules> roleBusinessRules;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<RoleBuilder> roleBuilder;
        private Mock<RoleAdapter> roleAdapter;

        [TestInitialize]
        public void Before()
        {
            roleBusinessRules = new Mock<RoleBusinessRules>();
            unitOfWork = new Mock<IUnitOfWork>();
            roleBuilder = new Mock<RoleBuilder>();
            roleAdapter = new Mock<RoleAdapter>();
            roleService = new RoleService(unitOfWork.Object, roleBuilder.Object, roleAdapter.Object, roleBusinessRules.Object);
        }

        [TestMethod]
        public void Should_GetRoles()
        {
            // Arrange
            unitOfWork.Setup(x => x.Role.Get(It.IsAny<SearchFilter>())).Returns(RoleTestData.GetRoleResult());
            roleBuilder.Setup(x => x.BuildModel(It.IsAny<Data.Role>())).Returns(new RoleModel());

            // Act
            var result = roleService.Get(It.IsAny<SearchFilter>());

            // Assert
            unitOfWork.Verify(x => x.Role.Get(It.IsAny<SearchFilter>()), Times.Once);
            roleBuilder.Verify(x => x.BuildModel(It.IsAny<Data.Role>()), Times.Once);
        }

        [TestMethod]
        public void Should_GetRoles_Empty_Roles_When_Repo_Is_Empty()
        {
            // Arrange
            unitOfWork.Setup(x => x.Role.Get(It.IsAny<SearchFilter>())).Returns(RoleTestData.GetNullRoleResult());

            // Act
            var result = roleService.Get(It.IsAny<SearchFilter>());

            // Assert
            unitOfWork.Verify(x => x.Role.Get(It.IsAny<SearchFilter>()), Times.Once);
            roleBuilder.Verify(x => x.BuildModel(It.IsAny<Data.Role>()), Times.Never);
        }

        [TestMethod]
        public void Should_Create_Role()
        {
            // Arrange
            unitOfWork.Setup(x => x.Save()).Verifiable();
            unitOfWork.Setup(x => x.Role.Insert(It.IsAny<Data.Role>())).Verifiable();
            roleBusinessRules.Setup(x => x.CreateCheck(It.IsAny<RoleModel>(), It.IsAny<RoleRepository>())).Verifiable();
            roleBuilder.Setup(x => x.Build(It.IsAny<RoleModel>())).Returns(RoleTestData.GetEmptyRole());
            roleBuilder.Setup(x => x.BuildModel(It.IsAny<Data.Role>())).Returns(new RoleModel());
            unitOfWork.Setup(x => x.Role.GetById(It.IsAny<Expression<Func<Data.Role, bool>>>())).Returns(RoleTestData.GetUserRole());

            // Act
            var result = roleService.Create(RoleTestData.GetUserRoleModel());

            // Assert
            roleBusinessRules.Verify(x => x.CreateCheck(It.IsAny<RoleModel>(), It.IsAny<RoleRepository>()), Times.Once);
            roleBuilder.Verify(x => x.Build(It.IsAny<RoleModel>()), Times.Once);
            unitOfWork.Verify(x => x.Role.GetById(It.IsAny<Expression<Func<Data.Role, bool>>>()), Times.Once);
            roleBuilder.Verify(x => x.BuildModel(It.IsAny<Data.Role>()), Times.Once);
        }
    }
}
