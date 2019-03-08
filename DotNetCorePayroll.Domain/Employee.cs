using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.Data
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeAllowance = new HashSet<EmployeeAllowance>();
            EmployeeBenefit = new HashSet<EmployeeBenefit>();
        }

        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string DisabilityDescription { get; set; }
        public string MaritalStatus { get; set; }
        public string HomeLanguage { get; set; }
        public string TaxReferenceNumber { get; set; }
        public string ImageFileName { get; set; }
        public int StatusId { get; set; }
        public string EthnicGroup { get; set; }
        public string EmployeeNumber { get; set; }
        public string IdOrPassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string WorkNumber { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public long? PhysicalAddressId { get; set; }
        public long? PostalAddressId { get; set; }
        public bool IsSouthAfricanCitizen { get; set; }
        public bool HasDisability { get; set; }
        public long CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public long? ModifiedUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Account CreateUser { get; set; }
        public virtual Account ModifiedUser { get; set; }
        public virtual Address PhysicalAddress { get; set; }
        public virtual Address PostalAddress { get; set; }
        public virtual ICollection<EmployeeAllowance> EmployeeAllowance { get; set; }
        public virtual ICollection<EmployeeBenefit> EmployeeBenefit { get; set; }
        public virtual EmployeeMedicalAid EmployeeMedicalAid { get; set; }
        public virtual EmployeePayroll EmployeePayrollEmployee { get; set; }
    }
}
