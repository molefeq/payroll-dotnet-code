using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Repositories;

using System;
using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private PayrollContext context;
        private bool disposed;

        #region Private Repositories Fields

        private OrganisationRepository organisation;

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

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
