using DotNetCorePayroll.Data.ViewModels;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;

namespace DotNetCorePayroll.ServiceBusinessRules.Services
{
    public interface IOgranisationService
    {
        Response<OrganisationModel> Find(Guid id);

        Result<OrganisationModel> Get(string searchText, PageData pageData);

        Response<OrganisationModel> Add(OrganisationModel organisationModel);

        Response<OrganisationModel> Update(OrganisationModel organisationModel);

        Response<OrganisationModel> Delete(Guid id);
    }
}
