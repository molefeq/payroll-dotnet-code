using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels.Company;

namespace DotNetCorePayroll.ServiceBusinessRules.ModelBuilders
{
    public class CompanyBuilder
    {
        public Company Build(CompanyModel companyModel)
        {
            Company company = new Company
            {
                Name = companyModel.Name,
                OrganisationId = companyModel.OrganisationId,
                RegisteredName = companyModel.RegisteredName,
                TradingName = companyModel.TradingName,
                NatureOfBusiness = companyModel.NatureOfBusiness,
                CompanyRegistrationNumber = companyModel.CompanyRegistrationNumber,
                TaxNumber = companyModel.TaxNumber,
                UifReferenceNumber = companyModel.UifReferenceNumber,
                PayeReferenceNumber = companyModel.PayeReferenceNumber,
                UifCompanyReferenceNumber = companyModel.UifCompanyReferenceNumber,
                SarsUifNumber = companyModel.SarsUifNumber,
                PaysdlInd = companyModel.PaysdlInd,
                FaxNumber = companyModel.FaxNumber,
                EmailAddress = companyModel.EmailAddress,
                ContactNumber = companyModel.ContactNumber,
                LogoFileName = companyModel.LogoFileName
            };

            return company;
        }

        public CompanyModel BuildToCompanyModel(Company company)
        {
            CompanyModel companyModel = new CompanyModel
            {
                Id = company.Id,
                Guid = company.Guid,
                Name = company.Name,
                OrganisationId = company.OrganisationId,
                RegisteredName = company.RegisteredName,
                TradingName = company.TradingName,
                NatureOfBusiness = company.NatureOfBusiness,
                CompanyRegistrationNumber = company.CompanyRegistrationNumber,
                TaxNumber = company.TaxNumber,
                UifReferenceNumber = company.UifReferenceNumber,
                PayeReferenceNumber = company.PayeReferenceNumber,
                UifCompanyReferenceNumber = company.UifCompanyReferenceNumber,
                SarsUifNumber = company.SarsUifNumber,
                PaysdlInd = company.PaysdlInd,
                FaxNumber = company.FaxNumber,
                EmailAddress = company.EmailAddress,
                ContactNumber = company.ContactNumber,
                LogoFileName = company.LogoFileName
            };

            return companyModel;
        }
    }
}
