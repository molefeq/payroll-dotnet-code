using DotNetCorePayroll.Data;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class TaxRebateRepository : GenericRepository<TaxRebate>
    {
        public TaxRebateRepository() : base() { }
        public TaxRebateRepository(PayrollContext context) : base(context) { }

        public TaxRebate GetTaxRebate(int age, string year)
        {
            return GetById(item => age >= item.MinimumAge && age <= item.MaximumAge && year.Equals(item.Year));
        }
    }
}

