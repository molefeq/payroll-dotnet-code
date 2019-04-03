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
        public virtual DbSet<CompanyBankDetail> CompanyBankDetail { get; set; }
        public virtual DbSet<CompanyPayrollSetting> CompanyPayrollSetting { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAllowance> EmployeeAllowance { get; set; }
        public virtual DbSet<EmployeeBenefit> EmployeeBenefit { get; set; }
        public virtual DbSet<EmployeeMedicalAid> EmployeeMedicalAid { get; set; }
        public virtual DbSet<EmployeePayroll> EmployeePayroll { get; set; }
        public virtual DbSet<IncomeTax> IncomeTax { get; set; }
        public virtual DbSet<MedicalAidTaxCredit> MedicalAidTaxCredit { get; set; }
        public virtual DbSet<TaxRebate> TaxRebate { get; set; }
        public virtual DbSet<TaxThreshold> TaxThreshold { get; set; }
        public virtual DbSet<Uif> Uif { get; set; }
        public virtual DbSet<PensionFund> PensionFund { get; set; }
        public virtual DbSet<Allowance> Allowance { get; set; }
        public virtual DbSet<AllowanceType> AllowanceType { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<PaymentFrequency> PaymentFrequency { get; set; }
        public virtual DbSet<Lookup> Lookup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            BenefitTableBuilder.Build(modelBuilder);
            AllowanceTypeTableBuilder.Build(modelBuilder);
            CountryTableBuilder.Build(modelBuilder);
            OrganisationTableBuilder.Build(modelBuilder);
            ProvinceTableBuilder.Build(modelBuilder);
            PaymentFrequencyTableBuilder.Build(modelBuilder);

            AddressTableBuilder.Build(modelBuilder);

            RoleTableBuilder.Build(modelBuilder);

            AccountTableBuilder.Build(modelBuilder);

            CompanyTableBuilder.Build(modelBuilder);
            CompanyBankDetailTableBuilder.Build(modelBuilder);
            CompanyPayrollSettingTableBuilder.Build(modelBuilder);

            EmployeeTableBuilder.Build(modelBuilder);
            EmployeePayrollTableBuilder.Build(modelBuilder);
            EmployeeAllowanceTableBuilder.Build(modelBuilder);
            EmployeeBenefitTableBuilder.Build(modelBuilder);
            EmployeeMedicalAidTableBuilder.Build(modelBuilder);

            IncomeTaxTableBuilder.Build(modelBuilder);
            MedicalAidTaxCreditTableBuilder.Build(modelBuilder);
            PensionFundTableBuilder.Build(modelBuilder);
            TaxRebateTableBuilder.Build(modelBuilder);
            TaxThresholdTableBuilder.Build(modelBuilder);
            UifTableBuilder.Build(modelBuilder);
            AllowanceTableBuilder.Build(modelBuilder);
            LookupTableBuilder.Build(modelBuilder);

        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
