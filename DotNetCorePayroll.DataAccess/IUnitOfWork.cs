using DotNetCorePayroll.Data;
using DotNetCorePayroll.DataAccess.Repositories;

using System.Threading.Tasks;

namespace DotNetCorePayroll.DataAccess
{
    public interface IUnitOfWork
    {
        #region Repositories Properties

        AccountRepository Account { get; }
        OrganisationRepository Organisation { get; }
        CompanyRepository Company { get; }
        RoleRepository Role { get; }
        GenericRepository<Country> Country { get; }
        GenericRepository<Province> Province { get; }
        EmployeeRepository Employee { get; }
        GenericRepository<EmployeeAllowance> EmployeeAllowance { get; }
        GenericRepository<EmployeeBenefit> EmployeeBenefit { get; }
        GenericRepository<EmployeeMedicalAid> EmployeeMedicalAid { get; }
        GenericRepository<EmployeePayroll> EmployeePayroll { get; }
        IncomeTaxRepository IncomeTax { get; }
        MedicalAidTaxCreditRepository MedicalAidTaxCredit { get; }
        TaxRebateRepository TaxRebate { get; }
        TaxThresholdRepository TaxThreshold { get; }
        UifRepository Uif { get; }
        PensionFundRepository PensionFund { get; }
        AllowanceRepository Allowance { get; }
        GenericRepository<AllowanceType> AllowanceType { get; }
        GenericRepository<Benefit> Benefit { get; }

        #endregion

        Task SaveAsync();
        void Save();
    }
}
