using System;

namespace DotNetCorePayroll.Data
{
    public partial class EmployeeMedicalAid
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string MedicalAidName { get; set; }
        public string MedicalAidScheme { get; set; }
        public string MedicalAidNumber { get; set; }
        public int NumberOfDependants { get; set; }
        public bool IsMainMember { get; set; }
        public double EmployerContribution { get; set; }
        public double EmployeeContribution { get; set; }
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Account CreateUser { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Account ModifiedUser { get; set; }
    }
}
