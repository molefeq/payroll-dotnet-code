using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels.Company;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using System;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class CompanyAdapter
    {
        private AddressBuilder addressBuilder;
        private AddressAdapter addressAdapter;

        public CompanyAdapter(AddressBuilder addressBuilder, AddressAdapter addressAdapter)
        {
            this.addressBuilder = addressBuilder;
            this.addressAdapter = addressAdapter;
        }

        public void Update(Company company, CompanyModel companyModel)
        {
            company.Name = companyModel.Name;
            company.OrganisationId = companyModel.OrganisationId;
            company.RegisteredName = companyModel.RegisteredName;
            company.TradingName = companyModel.TradingName;
            company.NatureOfBusiness = companyModel.NatureOfBusiness;
            company.CompanyRegistrationNumber = companyModel.CompanyRegistrationNumber;
            company.TaxNumber = companyModel.TaxNumber;
            company.UifReferenceNumber = companyModel.UifReferenceNumber;
            company.PayeReferenceNumber = companyModel.PayeReferenceNumber;
            company.UifCompanyReferenceNumber = companyModel.UifCompanyReferenceNumber;
            company.SarsUifNumber = companyModel.SarsUifNumber;
            company.PaysdlInd = companyModel.PaysdlInd;
            company.FaxNumber = companyModel.FaxNumber;
            company.EmailAddress = companyModel.EmailAddress;
            company.ContactNumber = companyModel.ContactNumber;
            company.LogoFileName = companyModel.LogoFileName;
        }

        public void UpdateAddressDetails(Company company, CompanyAddressModel addressModel)
        {

            if (company.PostalAddressId == null)
            {
                company.PostalAddress = addressBuilder.Build(addressModel.PostalAddress);
            }
            else
            {
                addressAdapter.Update(company.PostalAddress, addressModel.PostalAddress);
            }

            if (company.PhysicalAddress == null)
            {
                company.PhysicalAddress = addressBuilder.Build(addressModel.PhysicalAddress);
            }
            else
            {
                addressAdapter.Update(company.PhysicalAddress, addressModel.PhysicalAddress);
            }
        }
    }
}
