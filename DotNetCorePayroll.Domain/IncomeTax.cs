using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class IncomeTax
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public double MinimumIncome { get; set; }
        public double MaximumIncome { get; set; }
        public double SlidingScale { get; set; }
        public double MinimumTaxableAmount { get; set; }
        public double TaxPercentage { get; set; }
    }
}
