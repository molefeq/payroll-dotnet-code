using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels.Company;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelAdapters
{
    public class CompanyAdapter
    {
        public CompanyAdapter() { }

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
    }
}
