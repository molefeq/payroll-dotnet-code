using DotNetCorePayroll.Api.ActionResultHelpers;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;

using Microsoft.AspNetCore.Mvc;

using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class RoleController : Controller
    {
        private IRoleService roleService;
        
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<RoleModel>), 200)]
        public IActionResult GetRoles([FromBody]SearchFilter searchFilter)
        {
            return Ok(roleService.Get(searchFilter));
        }

        [HttpPost]
        [ProducesResponseType(typeof(RoleModel), 200)]
        public IActionResult AddRole([FromBody]RoleModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }
            
            return Ok(roleService.Create(roleModel));
        }

        [HttpPost]
        [ProducesResponseType(typeof(RoleModel), 200)]
        public IActionResult UpdateRole([FromBody]RoleModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            return Ok(roleService.Update(roleModel));
        }

        [HttpPost]
        public IActionResult DeleteRole([FromBody]RoleModel roleModel)
        {
            roleService.Delete(roleModel.Id.Value);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(RoleModel), 200)]
        public IActionResult FetchRole(long roleId)
        {
            return Ok(roleService.Read(roleId));
        }
    }
}