using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Repositories;

using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public interface IUnitOfWork
    {
        #region Repositories Properties

        AccountRepository Account { get; }
        OrganisationRepository Organisation { get; }
        CompanyRepository Company { get; }
        RoleRepository Role { get; }
        GenericRepository<Country> Country { get; }
        GenericRepository<Province> Province { get; }
        EmployeeRepository Employee { get; }

        #endregion

        Task SaveAsync();
        void Save();
    }
}
