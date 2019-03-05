using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.SearchFilters;
using SqsLibraries.Common.Utilities.ResponseObjects;
using System.Linq;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository() : base() { }
        public EmployeeRepository(PayrollContext context) : base(context) { }


        public Result<Employee> Get(EmployeeSearchFilter filter)
        {
            IQueryable<Employee> query = dbSet.Where(c => c.CompanyId == filter.CompanyId);

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(o => o.FirstName.Contains(filter.SearchText) || o.LastName.Contains(filter.SearchText));
            }

            return GetPagedEntities(query, filter.PageData, "PhysicalAddress, PostalAddress, CreateUser, ModifyUser, EmployeeCompanyDetailEmployee");
        }
    }
}
