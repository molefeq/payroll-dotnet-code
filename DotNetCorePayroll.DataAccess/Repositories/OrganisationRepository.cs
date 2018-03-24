using DotNetCorePayroll.Data;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System.Linq;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class OrganisationRepository : GenericRepository<Organisation>
    {
        public OrganisationRepository(PayrollContext context) : base(context) { }

        public Result<Organisation> Get(string searchText, PageData pageData)
        {
            IQueryable<Organisation> query = dbSet;

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(o => o.Name.Contains(searchText) || o.Description.Contains(searchText));
            }

            return GetPagedEntities(query, pageData, "PhysicalAddress, PostalAddress");
        }
    }
}
