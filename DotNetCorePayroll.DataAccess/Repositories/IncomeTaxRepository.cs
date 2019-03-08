using System;
using DotNetCorePayroll.Data;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class IncomeTaxRepository : GenericRepository<IncomeTax>
    {
        public IncomeTaxRepository() : base() { }
        public IncomeTaxRepository(PayrollContext context) : base(context) { }

        public IncomeTax GetIncomeTax(double annaulGrossRenumeration, string year)
        {
            return GetById(item => annaulGrossRenumeration >= item.MinimumIncome && annaulGrossRenumeration <= item.MaximumIncome && year.Equals(item.Year));
        }

        public object Where(string year)
        {
            throw new NotImplementedException();
        }
    }
}
