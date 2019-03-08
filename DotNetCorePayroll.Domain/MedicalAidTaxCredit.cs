using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class MedicalAidTaxCredit
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string MemberType { get; set; }
        public double CreditAmount { get; set; }
    }
}
