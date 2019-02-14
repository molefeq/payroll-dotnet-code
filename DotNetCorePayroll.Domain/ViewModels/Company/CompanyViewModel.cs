using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.Data.ViewModels.Company
{
    class CompanyViewModel
    {
        public Guid? Id { get; set; }
        public long OrganisationId { get; set; }
        public string OrganisationName { get; set; }
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
        public bool PaysdlInd { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public string LogoFileName { get; set; }
        public string LogoFileNamePath { get; set; }
    }
}
