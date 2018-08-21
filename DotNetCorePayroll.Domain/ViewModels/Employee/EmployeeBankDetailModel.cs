using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels.Employee
{
    public class EmployeeBankDetailModel 
    {
        public long? Id { get; set; }
        public Guid? EmployeeId { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }

        public CrudStatus CrudStatus { get; set; }
    }
}
