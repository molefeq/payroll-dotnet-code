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
            AccountBuilder.Build(modelBuilder);
            AddressBuilder.Build(modelBuilder);
            CompanyBuilder.Build(modelBuilder);
            CountryBuilder.Build(modelBuilder);
            OrganisationBuilder.Build(modelBuilder);
            ProvinceBuilder.Build(modelBuilder);
            RoleBuilder.Build(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
