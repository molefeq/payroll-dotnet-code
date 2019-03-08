using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class EmployeePayroll
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public DateTime DateOfEngagement { get; set; }
        public int PaymentFrequencyId { get; set; }
        public int PayrollDay { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public long? SupervisorId { get; set; }
        public string AnnualLeaveType { get; set; }
        public string EmployementType { get; set; }
        public string JobTitle { get; set; }
        public double BasicSalary { get; set; }
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Account CreateUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Account ModifiedUser { get; set; }
        public virtual PaymentFrequency PaymentFrequency { get; set; }
        public virtual Employee Supervisor { get; set; }
    }
}
