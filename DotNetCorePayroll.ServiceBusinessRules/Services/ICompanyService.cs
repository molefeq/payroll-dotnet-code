using DotNetCorePayroll.Data.ViewModels.Company;

using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System.Collections.Generic;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface ICompanyService
    {
        CompanyModel Find(long id);

        Result<CompanyModel> Get(long organisationId, string searchText, PageData pageData);

        CompanyModel Add(CompanyModel companyModel);

        CompanyModel Update(CompanyModel companyModel);

        void Delete(long id);

        void ResizeLogos(CompanyModel companyModel, IConfiguration configuration, string rootPath, string currentUrl);

        void MapRelativeLogoPaths(List<CompanyModel> companyModels, IConfiguration configuration, string currentUrl);

        void MapRelativeLogoPath(CompanyModel companyModel, IConfiguration configuration, string currentUrl);
    }
}
