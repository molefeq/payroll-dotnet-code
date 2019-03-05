using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.Data
{
    public partial class CompanyBankDetail
    {
        public int Id { get; set; }
        public long CompanyId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }

        public virtual Company Company { get; set; }
    }
}
