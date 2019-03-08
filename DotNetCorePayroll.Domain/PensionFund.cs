using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class PensionFund
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public double AnnualRemunerationPercent { get; set; }
        public double MaximumAmount { get; set; }
    }
}
