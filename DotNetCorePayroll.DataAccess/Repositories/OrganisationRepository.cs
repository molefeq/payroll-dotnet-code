using DotNetCorePayroll.Data;
using Microsoft.EntityFrameworkCore;
using SqsLibraries.Common.Utilities.ResponseObjects;

using System.Linq;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class OrganisationRepository : GenericRepository<Organisation>
    {
        public OrganisationRepository() : base() { }
        public OrganisationRepository(PayrollContext context) : base(context) { }

        public Result<Organisation> Get(string searchText, PageData pageData)
        {
            IQueryable<Organisation> query = dbSet;

            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(o => EF.Functions.Like(o.Name, $"%{searchText}%") ||
                                         EF.Functions.Like(o.Description, $"%{searchText}%")
                                   );
            }

            return GetPagedEntities(query, pageData, "PhysicalAddress, PostalAddress");
        }
    }
}
