using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Repositories;

using System;
using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private PayrollContext context;
        private bool disposed;

        #region Private Repositories Fields

        private OrganisationRepository organisation;
        private AccountRepository account;

        #endregion

        public UnitOfWork(PayrollContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        #region Repositories Properties

        public OrganisationRepository Organisation
        {
            get
            {
                if (organisation == null)
                {
                    organisation = new OrganisationRepository(context);
                }

                return organisation;
            }
        }

        public AccountRepository Account
        {
            get
            {
                if (account == null)
                {
                    account = new AccountRepository(context);
                }

                return account;
            }
        }

        #endregion
    }
}
