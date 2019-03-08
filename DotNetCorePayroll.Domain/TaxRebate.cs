using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class TaxRebate
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public double RebateAmount { get; set; }
        public string RebateDescription { get; set; }
    }
}
