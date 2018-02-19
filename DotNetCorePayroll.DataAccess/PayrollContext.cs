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

        public virtual DbSet<Data.Address> Address { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<Province> Province { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AddressBuilder.Build(modelBuilder);
            CountryBuilder.Build(modelBuilder);
            OrganisationBuilder.Build(modelBuilder);
            ProvinceBuilder.Build(modelBuilder);
        }
    }
}
