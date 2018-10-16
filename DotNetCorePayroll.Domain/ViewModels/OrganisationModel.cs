using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class OrganisationModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string PhysicalAddressSuburb { get; set; }
        public string PhysicalAddressCity { get; set; }
        public string PhysicalAddressPostalCode { get; set; }
        public long PhysicalAddressId { get; set; }
        public long PhysicalAddressProvinceId { get; set; }
        public long PhysicalAddressCountryId { get; set; }
        public long? PostalAddressId { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalAddressSuburb { get; set; }
        public string PostalAddressCity { get; set; }
        public string PostalAddressPostalCode { get; set; }
        public long? PostalAddressProvinceId { get; set; }
        public long? PostalAddressCountryId { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string LogoFileName { get; set; }
        public string LogoFileNamePath { get; set; }
        public Guid? Guid { get; set; }
        public CrudStatus CrudStatus { get; set; }
    }
}
