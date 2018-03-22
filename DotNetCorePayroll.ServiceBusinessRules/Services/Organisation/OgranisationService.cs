using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;

using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;

using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.Collections.Generic;
using System.IO;
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

        public OrganisationModel Find(Guid Id)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork(context))
            {
                var organisation = unitOfWork.Organisation.GetById(o => o.Guid == Id, "PhysicalAddress, PostalAddress");

                if (organisation == null)
                {
                    throw new ResponseValidationException(ResponseMessage.ToError("Organisation you trying to update does not exist."));
                }

                return organisationBuilder.BuildToModel(organisation);
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

        public void ResizeLogos(OrganisationModel organisationModel, IConfiguration configuration, string rootPath, string currentUrl)
        {
            string tempPhysicalTempDirectory = Path.Combine(rootPath, configuration.OrganisationNormalTempDirectory());
            string logoFileName = FileHandler.GetPhysicalFileName(tempPhysicalTempDirectory, organisationModel.LogoFileName);

            FileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
                new ImageModel
                {

                    Width = configuration.OrganisationNormalImageWidth(),
                    Height = configuration.OrganisationNormalImageHeight(),
                    PhysicalDirectory = Path.Combine(rootPath, configuration.OrganisationNormalDirectory()),
                    RelativeDirectory = new Uri(currentUrl + configuration.OrganisationNormalDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
                new ImageModel
                {
                    Width = configuration.OrganisationThumbnailImageWidth(),
                    Height = configuration.OrganisationThumbnailImageHeight(),
                    PhysicalDirectory = Path.Combine(rootPath, configuration.OrganisationThumbnailDirectory()),
                    RelativeDirectory = new Uri(currentUrl + configuration.OrganisationThumbnailDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
                new ImageModel
                {
                    Width = configuration.OrganisationPreviewImageWidth(),
                    Height = configuration.OrganisationPreviewImageHeight(),
                    PhysicalDirectory = Path.Combine(rootPath, configuration.OrganisationPreviewDirectory()),
                    RelativeDirectory = new Uri(currentUrl + configuration.OrganisationPreviewDirectory()).AbsoluteUri
                });
        }

        public void MapRelativeLogoPaths(List<OrganisationModel> organisationModels, IConfiguration configuration, string currentUrl)
        {
            if (organisationModels == null || organisationModels.Count == 0)
            {
                return;
            }

            organisationModels.ForEach(item => MapRelativeLogoPath(item, configuration, currentUrl));
        }

        public void MapRelativeLogoPath(OrganisationModel organisationModel, IConfiguration configuration, string currentUrl)
        {
            if (string.IsNullOrEmpty(organisationModel.LogoFileName))
            {
                return;
            }

            organisationModel.LogoFileNamePath = FileHandler.GetRelativeFileName(new Uri(currentUrl + configuration.OrganisationPreviewDirectory()).AbsoluteUri, organisationModel.LogoFileName);
        }
    }
}
