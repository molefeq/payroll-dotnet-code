using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.DataAccess;
using Payslip.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class SarsTaxIncomeBuilder
    {
        private List<SarsTaxIncome> sarsTaxIncomeTable = new List<SarsTaxIncome>();

        public SarsTaxIncomeBuilder() { }

        public void buildSarsTaxIncomeTable(IUnitOfWork unitOfWork)
        {
            var year = DateTime.Now.GetTaxYear();
            sarsTaxIncomeTable = unitOfWork.IncomeTax.GetEntities(i => year.Equals(i.Year))
                                           .ToList()
                                           .Select(item => new SarsTaxIncome
                                           {
                                               MaximumIncome = item.MaximumIncome,
                                               MinimumIncome = item.MinimumIncome,
                                               MinimumNonTaxableAmount = item.MinimumTaxableAmount,
                                               SlidingScale = item.SlidingScale
                                           }).ToList();
        }

        public List<SarsTaxIncome> GetSarsTaxIncomeTable()
        {
            return sarsTaxIncomeTable;
        }
    }
}
