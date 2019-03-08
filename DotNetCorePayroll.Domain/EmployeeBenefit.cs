using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public partial class EmployeeBenefit
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public int BenefitId { get; set; }
        public double EmployeeContribution { get; set; }
        public double EmployerContribution { get; set; }
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Benefit Benefit { get; set; }
        public virtual Account CreateUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Account ModifiedUser { get; set; }
    }
}
