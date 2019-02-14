using DotNetCorePayroll.Data;
using SqsLibraries.Common.Utilities.ResponseObjects;
using System.Linq;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public CompanyRepository() : base() { }
        public CompanyRepository(PayrollContext context) : base(context) { }

        public Result<Company> Get(long organisationId, string searchText, PageData pageData)
        {
            IQueryable<Company> query = dbSet.Where(c=>c.OrganisationId == organisationId);

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(o => o.Name.Contains(searchText) || o.RegisteredName.Contains(searchText));
            }

            return GetPagedEntities(query, pageData, "PhysicalAddress, PostalAddress");
        }
    }
}
