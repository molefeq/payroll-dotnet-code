using DotNetCorePayroll.Data;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class PensionFundRepository : GenericRepository<PensionFund>
    {
        public PensionFundRepository() : base() { }
        public PensionFundRepository(PayrollContext context) : base(context) { }

        public PensionFund GetPensionFund(string year)
        {
            return GetById(item => year.Equals(item.Year));
        }
    }
}

