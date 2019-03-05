using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.Data
{
    public class Company
    {
        public Company()
        {
            CompanyBankDetails = new HashSet<CompanyBankDetail>();
            CompanyPayrollSettings = new HashSet<CompanyPayrollSetting>();
            Employees = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public long OrganisationId { get; set; }
        public string Name { get; set; }
        public string RegisteredName { get; set; }
        public string TradingName { get; set; }
        public string NatureOfBusiness { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string TaxNumber { get; set; }
        public string UifReferenceNumber { get; set; }
        public string PayeReferenceNumber { get; set; }
        public string UifCompanyReferenceNumber { get; set; }
        public string SarsUifNumber { get; set; }
        public string LogoFileName { get; set; }
        public Guid Guid { get; set; }
        public long? PhysicalAddressId { get; set; }
        public long? PostalAddressId { get; set; }
        public bool PaysdlInd { get; set; }
        public string ContactNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }

        public Organisation Organisation { get; set; }
        public virtual Address PhysicalAddress { get; set; }
        public virtual Address PostalAddress { get; set; }
        public virtual ICollection<CompanyBankDetail> CompanyBankDetails { get; set; }
        public virtual ICollection<CompanyPayrollSetting> CompanyPayrollSettings { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
