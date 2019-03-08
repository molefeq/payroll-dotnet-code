using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class Uif
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public double UifPercent { get; set; }
        public double MaximumAmount { get; set; }
    }
}
