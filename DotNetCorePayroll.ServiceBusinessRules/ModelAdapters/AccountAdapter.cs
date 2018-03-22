using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class AccountAdapter
    {
        public void Update(Account account, AccountModel accountModel)
        {
            account.Firstname = accountModel.Firstname;
            account.Lastname = accountModel.Lastname;
            account.EmailAddress = accountModel.EmailAddress;
            account.ContactNumber = accountModel.ContactNumber;
            account.RoleId = accountModel.RoleId;
            account.OrganisationId = accountModel.OrganisationId;
            account.CompanyId = accountModel.CompanyId;
        }
    }
}
