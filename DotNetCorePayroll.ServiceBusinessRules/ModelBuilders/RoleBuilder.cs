using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class RoleBuilder
    {
        public virtual Role Build(RoleModel roleModel)
        {
            Role role = new Role
            {
                Name = roleModel.Name,
                Code = roleModel.Code
            };

            return role;
        }

        public virtual RoleModel BuildModel(Role role)
        {
            RoleModel roleModel = new RoleModel
            {
                Id = role.Id,
                Name = role.Name,
                Code = role.Code
            };

            return roleModel;
        }
    }
}
