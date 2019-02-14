using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Repositories;

using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private PayrollContext context;

        #region Private Repositories Fields

        private OrganisationRepository organisation;
        private CompanyRepository company;
        private AccountRepository account;
        private RoleRepository role;
        private GenericRepository<Country> country;
        private GenericRepository<Province> province;

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


        public CompanyRepository Company
        {
            get
            {
                if (company == null)
                {
                    company = new CompanyRepository(context);
                }

                return company;
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
        
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                {
                    role = new RoleRepository(context);
                }

                return role;
            }
        }

        public GenericRepository<Country> Country
        {
            get
            {
                if (country == null)
                {
                    country = new GenericRepository<Country>(context);
                }

                return country;
            }
        }


        public GenericRepository<Province> Province
        {
            get
            {
                if (province == null)
                {
                    province = new GenericRepository<Province>(context);
                }

                return province;
            }
        }
        #endregion
    }
}
