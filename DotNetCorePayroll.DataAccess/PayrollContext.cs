using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.TableBuilders;

using Microsoft.EntityFrameworkCore;

namespace DotNetCorePayroll.DataAccess
{
    public class PayrollContext : DbContext
    {
        public PayrollContext(DbContextOptions<PayrollContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Data.Address> Address { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AccountTableBuilder.Build(modelBuilder);
            AddressTableBuilder.Build(modelBuilder);
            CompanyTableBuilder.Build(modelBuilder);
            CountryTableBuilder.Build(modelBuilder);
            OrganisationTableBuilder.Build(modelBuilder);
            ProvinceTableBuilder.Build(modelBuilder);
            RoleTableBuilder.Build(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
