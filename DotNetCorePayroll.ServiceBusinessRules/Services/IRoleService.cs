using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;

using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface IRoleService
    {
        Result<RoleModel> Get(SearchFilter searchFilter);
        RoleModel Create(RoleModel roleModel);
        RoleModel Read(long roleId);
        RoleModel Update(RoleModel roleModel);
        void Delete(long roleId);
    }
}
