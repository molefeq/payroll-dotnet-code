using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels.Company
{
    public class CompanyBankDetailModel
    {
        public Guid? CompanyId { get; set; }
        public long? BankId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public CrudStatus CrudStatus { get; set; }
    }
}
