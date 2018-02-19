using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;

using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Organisation
{
    public class OgranisationService : IOgranisationService
    {
        private PayrollContext context;
        private OrganisationBuilder organisationBuilder;
        private OrganisationAdapter organisationAdapter;

        public OgranisationService(PayrollContext context, OrganisationBuilder organisationBuilder, OrganisationAdapter organisationAdapter)
        {
            this.context = context;
            this.organisationBuilder = organisationBuilder;
            this.organisationAdapter = organisationAdapter;
        }

        public Response<OrganisationModel> Find(Guid Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var organisation = unitOfWork.Organisation.GetById(o => o.Guid == Id, "PhysicalAddress, PostalAddress");

                if (organisation == null)
                {
                    return new Response<OrganisationModel>
                    {
                        Messages = new List<ResponseMessage> { ResponseMessage.ToError("Organisation you trying to update does not exist.") }
                    };
                }

                return new Response<OrganisationModel>
                {
                    Item = organisationBuilder.BuildToModel(organisation)
                };
            }
        }

        public Result<OrganisationModel> Get(string searchText, PageData pageData)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var results = unitOfWork.Organisation.GetOrganisations(searchText, pageData);

                return new Result<OrganisationModel>
                {
                    Items = results.Items.Select(o => organisationBuilder.BuildToModel(o)).ToList(),
                    TotalItems = results.TotalItems
                };
            }
        }

        public Response<OrganisationModel> Add(OrganisationModel organisationModel)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var organisation = organisationBuilder.Build(organisationModel);

                unitOfWork.Organisation.Insert(organisation);
                unitOfWork.Save();

                return new Response<OrganisationModel>
                {
                    Item = organisationBuilder.BuildToModel(unitOfWork.Organisation.GetById(o => o.Guid == organisation.Guid, "PhysicalAddress, PostalAddress"))
                };

            }
        }

        public Response<OrganisationModel> Update(OrganisationModel organisationModel)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var organisation = unitOfWork.Organisation.GetById(o => o.Guid == organisationModel.Id.Value, "PhysicalAddress, PostalAddress");

                if (organisation == null)
                {
                    return new Response<OrganisationModel>
                    {
                        Messages = new List<ResponseMessage> { ResponseMessage.ToError("Organisation you trying to update does not exist.") }
                    };
                }

                organisationAdapter.Update(organisation, organisationModel);
                unitOfWork.Organisation.Update(organisation);
                unitOfWork.Save();

                return new Response<OrganisationModel>
                {
                    Item = organisationBuilder.BuildToModel(unitOfWork.Organisation.GetById(o => o.Guid == organisation.Guid, "PhysicalAddress, PostalAddress"))
                };
            }
        }

        public Response<OrganisationModel> Delete(Guid id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var organisation = unitOfWork.Organisation.GetById(o => o.Guid == id);

                if (organisation == null)
                {
                    return new Response<OrganisationModel>
                    {
                        Messages = new List<ResponseMessage> { ResponseMessage.ToError("Organisation you trying to delete does not exist.") }
                    };
                }

                unitOfWork.Organisation.Delete(organisation);
                unitOfWork.Save();

                return new Response<OrganisationModel>();
            }
        }
    }
}
