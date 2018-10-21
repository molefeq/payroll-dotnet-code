using SqsLibraries.Common.Enums;
using System;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class OrganisationModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AddressModel PhysicalAddress { get; set; }
        public AddressModel PostalAddress { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string LogoFileName { get; set; }
        public string LogoFileNamePath { get; set; }
        public Guid? Guid { get; set; }
        public CrudStatus CrudStatus { get; set; }
    }
}
