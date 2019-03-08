using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels.Employee
{
    public class EmployeeCompanyDetailModel
    {
        public int Id { get; set; }
        public long EmployeeId { get; set; }
        public DateTime DateOfEngagement { get; set; }
        public int PayrollDay { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public long? SupervisorId { get; set; }
        public string AnnualLeaveType { get; set; }
        public string EmployementType { get; set; }
        public string JobTitle { get; set; }
        public double BasicSalary { get; set; }
        public double? TravelAllowance { get; set; }
        public double? OtherAllowance { get; set; }
        public long CreateUserId { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifyUserId { get; set; }
        public string ModifyUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public CrudStatus CrudStatus { get; set; }
    }
}
