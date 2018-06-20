using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class RoleAdapter
    {
        public void Update(Role role, RoleModel roleModel)
        {
            role.Name = roleModel.Name;
            role.Code = roleModel.Code;
        }
    }
}
