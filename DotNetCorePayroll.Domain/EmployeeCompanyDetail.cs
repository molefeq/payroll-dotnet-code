﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.Data
{
    public partial class EmployeeCompanyDetail
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
        public decimal BasicSalary { get; set; }
        public decimal? TravelAllowance { get; set; }
        public decimal? OtherAllowance { get; set; }
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifyUserId { get; set; }
        public DateTime? ModifyDate { get; set; }

        public virtual Account CreateUser { get; set; }
        public virtual Account ModifyUser { get; set; }
    }
}
