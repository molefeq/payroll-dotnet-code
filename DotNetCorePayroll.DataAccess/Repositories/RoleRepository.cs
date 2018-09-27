using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.SearchFilters;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System.Linq;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository() : base() { }

        public RoleRepository(PayrollContext context) : base(context) { }

        public virtual Result<Role> Get(SearchFilter filter)
        {
            var query = from role in dbSet
                        select role; ;

            var searchText = filter.SearchText;

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = from role in query
                        where role.Name.Equals(searchText) ||
                              role.Code.Equals(searchText)
                        select role;
            }

            return GetPagedEntities(query, filter.PageData);
        }
    }
}
