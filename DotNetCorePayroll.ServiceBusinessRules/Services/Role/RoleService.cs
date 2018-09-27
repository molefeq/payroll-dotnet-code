using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Role
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork unitOfWork;
        private RoleBuilder roleBuilder;
        private RoleAdapter roleAdapter;
        private RoleBusinessRules roleBusinessRules;

        public RoleService(IUnitOfWork unitOfWork, RoleBuilder roleBuilder, RoleAdapter roleAdapter, RoleBusinessRules roleBusinessRules)
        {
            this.unitOfWork = unitOfWork;
            this.roleBuilder = roleBuilder;
            this.roleAdapter = roleAdapter;
            this.roleBusinessRules = roleBusinessRules;
        }

        public Result<RoleModel> Get(SearchFilter searchFilter)
        {            
            var result = unitOfWork.Role.Get(searchFilter);

            if (result == null)
            {
                return new Result<RoleModel>();
            }

            return new Result<RoleModel>
            {
                TotalItems = result.TotalItems,
                Items = result.Items.Select(a => roleBuilder.BuildModel(a)).ToList()
            };
        }

        public RoleModel Create(RoleModel roleModel)
        {
            roleBusinessRules.CreateCheck(roleModel, unitOfWork.Role);

            var role = roleBuilder.Build(roleModel);

            unitOfWork.Role.Insert(role);
            unitOfWork.Save();

            return roleBuilder.BuildModel(unitOfWork.Role.GetById(o => o.Id == role.Id));
        }

        public void Delete(long roleId)
        {
            roleBusinessRules.DeleteCheck(roleId, unitOfWork.Role);

            var role = unitOfWork.Role.GetById(o => o.Id == roleId);
            
            unitOfWork.Role.Delete(role);
            unitOfWork.Save();
        }

        public RoleModel Read(long roleId)
        {
            var role = unitOfWork.Role.GetById(o => o.Id == roleId);

            if (role == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Role you trying to fetch does not exist."));
            }

            return  roleBuilder.BuildModel(role);
        }

        public RoleModel Update(RoleModel roleModel)
        {
            roleBusinessRules.UpdateCheck(roleModel, unitOfWork.Role);

            var role = unitOfWork.Role.GetById(o => o.Id == roleModel.Id);
            
            roleAdapter.Update(role, roleModel);
            unitOfWork.Role.Update(role);
            unitOfWork.Save();

            return roleBuilder.BuildModel(unitOfWork.Role.GetById(o => o.Id == role.Id));
        }
    }
}
