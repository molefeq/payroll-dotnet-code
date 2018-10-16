using DotNetCorePayroll.Data.ViewModels;

using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface IOgranisationService
    {
        OrganisationModel Find(long id);

        Result<OrganisationModel> Get(string searchText, PageData pageData);

        OrganisationModel Add(OrganisationModel organisationModel);

        OrganisationModel Update(OrganisationModel organisationModel);

        void Delete(long id);

        void ResizeLogos(OrganisationModel organisationModel, IConfiguration configuration, string rootPath, string currentUrl);

        void MapRelativeLogoPaths(List<OrganisationModel> organisationModels, IConfiguration configuration, string currentUrl);

        void MapRelativeLogoPath(OrganisationModel organisationModel, IConfiguration configuration, string currentUrl);
    }
}
