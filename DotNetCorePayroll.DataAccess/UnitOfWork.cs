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
        private EmployeeRepository employee;
        private IncomeTaxRepository incomeTax;
        private MedicalAidTaxCreditRepository medicalAidTaxCredit;
        private AllowanceRepository allowance;
        private TaxRebateRepository taxRebate;
        private TaxThresholdRepository taxThreshold;
        private UifRepository uif;
        private PensionFundRepository pensionFund;
        private GenericRepository<EmployeePayroll> employeePayroll;
        private GenericRepository<EmployeeMedicalAid> employeeMedicalAid;
        private GenericRepository<EmployeeBenefit> employeeBenefit;
        private GenericRepository<EmployeeAllowance> employeeAllowance;
        private GenericRepository<Benefit> benefit;
        private GenericRepository<AllowanceType> allowanceType;
        private GenericRepository<Lookup> lookup;

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

        public EmployeeRepository Employee
        {
            get
            {
                if (employee == null)
                {
                    employee = new EmployeeRepository(context);
                }

                return employee;
            }
        }

        public IncomeTaxRepository IncomeTax { get
            {
                if (incomeTax == null)
                {
                    incomeTax = new IncomeTaxRepository(context);
                }

                return incomeTax;
            }
        }

        public MedicalAidTaxCreditRepository MedicalAidTaxCredit {
            get
            {
                if (medicalAidTaxCredit == null)
                {
                    medicalAidTaxCredit = new MedicalAidTaxCreditRepository(context);
                }

                return medicalAidTaxCredit;
            }
        }

        public TaxRebateRepository TaxRebate
        {
            get
            {
                if (taxRebate == null)
                {
                    taxRebate = new TaxRebateRepository(context);
                }

                return taxRebate;
            }
        }

        public TaxThresholdRepository TaxThreshold
        {
            get
            {
                if (taxThreshold == null)
                {
                    taxThreshold = new TaxThresholdRepository(context);
                }

                return taxThreshold;
            }
        }

        public UifRepository Uif
        {
            get
            {
                if (uif == null)
                {
                    uif = new UifRepository(context);
                }

                return uif;
            }
        }

        public PensionFundRepository PensionFund
        {
            get
            {
                if (pensionFund == null)
                {
                    pensionFund = new PensionFundRepository(context);
                }

                return pensionFund;
            }
        }

        public AllowanceRepository Allowance
        {
            get
            {
                if (allowance == null)
                {
                    allowance = new AllowanceRepository(context);
                }

                return allowance;
            }
        }


        public GenericRepository<AllowanceType> AllowanceType
        {
            get
            {
                if (allowanceType == null)
                {
                    allowanceType = new GenericRepository<AllowanceType>(context);
                }

                return allowanceType;
            }
        }

        public GenericRepository<Benefit> Benefit
        {
            get
            {
                if (benefit == null)
                {
                    benefit = new GenericRepository<Benefit>(context);
                }

                return benefit;
            }
        }

        public GenericRepository<EmployeeAllowance> EmployeeAllowance
        {
            get
            {
                if (employeeAllowance == null)
                {
                    employeeAllowance = new GenericRepository<EmployeeAllowance>(context);
                }

                return employeeAllowance;
            }
        }

        public GenericRepository<EmployeeBenefit> EmployeeBenefit
        {
            get
            {
                if (employeeBenefit == null)
                {
                    employeeBenefit = new GenericRepository<EmployeeBenefit>(context);
                }

                return employeeBenefit;
            }
        }

        public GenericRepository<EmployeeMedicalAid> EmployeeMedicalAid
        {
            get
            {
                if (employeeMedicalAid == null)
                {
                    employeeMedicalAid = new GenericRepository<EmployeeMedicalAid>(context);
                }

                return employeeMedicalAid;
            }
        }

        public GenericRepository<EmployeePayroll> EmployeePayroll
        {
            get
            {
                if (employeePayroll == null)
                {
                    employeePayroll = new GenericRepository<EmployeePayroll>(context);
                }

                return employeePayroll;
            }
        }

        public GenericRepository<Lookup> Lookup
        {
            get
            {
                if (lookup == null)
                {
                    lookup = new GenericRepository<Lookup>(context);
                }

                return lookup;
            }
        }

        #endregion
    }
}
