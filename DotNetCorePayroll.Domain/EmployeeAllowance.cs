using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class EmployeeAllowance
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public int AllowanceTypeId { get; set; }
        public double Amount { get; set; }
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual AllowanceType AllowanceType { get; set; }
        public virtual Account CreateUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Account ModifiedUser { get; set; }
    }
}
