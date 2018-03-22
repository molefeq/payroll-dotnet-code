using DotNetCorePayroll.Data;
using SqsLibraries.Common.Utilities;
using SqsLibraries.Common.Utilities.ResponseObjects;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class AccountRepository : GenericRepository<Account>
    {
        public AccountRepository(PayrollContext context) : base(context) { }

        public Response<Account> Login(string username, string password)
        {
            Response<Account> response = new Response<Account>();

            Account account = GetById(a => a.Username == username, "Company, Organisation, Role");

            response.Item = account;

            return response;
        }
    }
}
