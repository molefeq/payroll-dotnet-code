using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels.Employee
{
    public class EmployeeModel
    {
        public Guid? Id { get; set; }
        public Guid CompanyId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EthnicGroup { get; set; }
        public bool IsSouthAfricanCitizen { get; set; }
        public string IdOrPassportNumber { get; set; }
        public string Gender { get; set; }
        public bool HasDisability { get; set; }
        public string DisabilityDescription { get; set; }
        public string MaritalStatus { get; set; }
        public string HomeLanguage { get; set; }
        public string TaxReferenceNumber { get; set; }
        public string ImageFileName { get; set; }
        public string ImageFileNamePath { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsSystemUser { get; set; }
        public string EmailAddress { get; set; }
        public string WorkNumber { get; set; }
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public CrudStatus CrudStatus { get; set; }

        public EmployeeContactDetailModel ContactDetail { get; set; }
        public EmployeeNextOfKinDetailModel NextOfKinDetail { get; set; }
        public EmployeeBankDetailModel BankDetail { get; set; }
    }
}
