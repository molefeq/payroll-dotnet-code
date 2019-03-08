using DotNetCorePayroll.Data;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class TaxThresholdRepository : GenericRepository<TaxThreshold>
    {
        public TaxThresholdRepository() : base() { }
        public TaxThresholdRepository(PayrollContext context) : base(context) { }

        public TaxThreshold GetTaxThreshold(int age, string year)
        {
            return GetById(item => age >= item.MinimumAge && age <= item.MaximumAge && year.Equals(item.Year));
        }
    }
}

