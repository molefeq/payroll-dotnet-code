using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.SearchFilters;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.Linq;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(PayrollContext context) : base(context) { }
        
        public Result<Account> Get(AccountSearchFilter filter)
        {
            var query = from account in dbSet
                        where account.DisableDate == null ||
                              account.DisableDate > DateTime.Now
                        select account;

            var searchText = filter.SearchText;

            if (filter.OrganisationId != null)
            {
                query = query.Where(a => a.OrganisationId == filter.OrganisationId);
            }

            if (filter.CompanyId != null)
            {
                query = query.Where(a => a.CompanyId == filter.CompanyId);
            }

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = from account in query
                        join organisation in context.Organisation on account.OrganisationId equals organisation.Id
                        where account.Firstname.Equals(searchText) ||
                              account.Lastname.Equals(searchText) ||
                              organisation.Name.Equals(searchText) ||
                              (account.Company == null || account.Company.Name.Equals(searchText))
                        select account;
            }

            return GetPagedEntities(query, filter.PageData, "Organisation,Company,Role");
        }
    }
}
