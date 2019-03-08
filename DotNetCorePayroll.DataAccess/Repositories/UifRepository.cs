using DotNetCorePayroll.Data;
using System;

namespace DotNetCorePayroll.DataAccess.Repositories
{
    public class UifRepository : GenericRepository<Uif>
    {
        public UifRepository() : base() { }
        public UifRepository(PayrollContext context) : base(context) { }

        public Uif GetUif(DateTime date)
        {
            return GetById(item => date >= item.DateFrom && (item.DateTo == null || date <= item.DateTo.Value));
        }
    }
}

