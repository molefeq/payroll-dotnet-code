using DotNetCorePayroll.Data;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class OrganisationRepository : GenericRepository<Organisation>
    {
        public OrganisationRepository(PayrollContext context) : base(context) { }

        public Result<Organisation> GetOrganisations(string searchText, PageData pageData)
        {
            Expression<Func<Organisation, bool>> filter = null;

            if (!string.IsNullOrEmpty(searchText))
            {
                filter = o => o.Name.Contains(searchText) || o.Description.Contains(searchText);
            }

            return new Result<Organisation>
            {
                Items = GetEntities(filter, o => o.OrderBy(t => t.Name), pageData, "PhysicalAddress, PostalAddress").ToList(),
                TotalItems = CountEntities(filter)
            };
        }
    }
}
