using DotNetCorePayroll.Api.Controllers;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.Api.Tests.UnitTests
{
    [TestClass]
    public class RoleControllerTest
    {
        private RoleController roleController;
        private Mock<IRoleService> roleService;

        [TestInitialize]
        public void Before()
        {
            roleService = new Mock<IRoleService>();
            roleController = new RoleController(roleService.Object);
        }

        [TestCategory("GetRoles"), TestMethod]
        public void Should_Get_Roles()
        {
           
        }



    }
}
