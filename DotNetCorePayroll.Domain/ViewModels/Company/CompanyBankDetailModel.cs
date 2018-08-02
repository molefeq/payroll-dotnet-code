using System;
using System.Collections.Generic;
using System.Text;
using SqsLibraries.Common.Enums;

namespace DotNetCorePayroll.Data.ViewModels.Company
{
    public class CompanyBankDetailModel
    {
        public int? Id { get; set; }
        public int Companies_Id { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public CrudStatus CrudStatus { get; set; }
    }
}
