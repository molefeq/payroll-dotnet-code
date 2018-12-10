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
        private IUnitOfWork unitOfWork;
        private OrganisationBuilder organisationBuilder;
        private OrganisationAdapter organisationAdapter;

        public OgranisationService(IUnitOfWork unitOfWork, OrganisationBuilder organisationBuilder, OrganisationAdapter organisationAdapter)
        {
            this.unitOfWork = unitOfWork;
            this.organisationBuilder = organisationBuilder;
            this.organisationAdapter = organisationAdapter;
        }

        public OrganisationModel Find(long Id)
        {
            var organisation = unitOfWork.Organisation.GetById(o => o.Id == Id, "PhysicalAddress, PostalAddress");

            if (organisation == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Organisation you trying to update does not exist."));
            }

            return organisationBuilder.BuildModel(organisation);
        }

        public Result<OrganisationModel> Get(string searchText, PageData pageData)
        {
            var results = unitOfWork.Organisation.Get(searchText, pageData);

            return new Result<OrganisationModel>
            {
                Items = results.Items.Select(o => organisationBuilder.BuildModel(o)).ToList(),
                TotalItems = results.TotalItems
            };
        }

        public OrganisationModel Add(OrganisationModel organisationModel)
        {
            var organisation = organisationBuilder.Build(organisationModel);

            unitOfWork.Organisation.Insert(organisation);
            unitOfWork.Save();

            return organisationBuilder.BuildModel(unitOfWork.Organisation.GetById(o => o.Id == organisation.Id, "PhysicalAddress, PostalAddress"));
        }

        public OrganisationModel Update(OrganisationModel organisationModel)
        {
            var organisation = unitOfWork.Organisation.GetById(o => o.Id == organisationModel.Id.Value, "PhysicalAddress, PostalAddress");

            if (organisation == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Organisation you trying to update does not exist."));
            }

            organisationAdapter.Update(organisation, organisationModel);
            unitOfWork.Organisation.Update(organisation);
            unitOfWork.Save();

            return organisationBuilder.BuildModel(unitOfWork.Organisation.GetById(o => o.Id == organisation.Id, "PhysicalAddress, PostalAddress"));
        }

        public void Delete(long id)
        {
            var organisation = unitOfWork.Organisation.GetById(o => o.Id == id);

            if (organisation == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Organisation you trying to delete does not exist."));
            }

            unitOfWork.Organisation.Delete(organisation);
            unitOfWork.Save();
        }

        public void ResizeLogos(OrganisationModel organisationModel, IConfiguration configuration, string rootPath, string currentUrl)
        {
            string tempPhysicalTempDirectory = rootPath + configuration.OrganisationNormalTempDirectory();
            string logoFileName = FileHandler.GetPhysicalFileName(tempPhysicalTempDirectory, organisationModel.LogoFileName);

            FileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
                new ImageModel
                {

                    Width = configuration.OrganisationNormalImageWidth(),
                    Height = configuration.OrganisationNormalImageHeight(),
                    PhysicalDirectory = rootPath + configuration.OrganisationNormalDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.OrganisationNormalDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
                new ImageModel
                {
                    Width = configuration.OrganisationThumbnailImageWidth(),
                    Height = configuration.OrganisationThumbnailImageHeight(),
                    PhysicalDirectory = rootPath + configuration.OrganisationThumbnailDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.OrganisationThumbnailDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
                new ImageModel
                {
                    Width = configuration.OrganisationPreviewImageWidth(),
                    Height = configuration.OrganisationPreviewImageHeight(),
                    PhysicalDirectory = rootPath + configuration.OrganisationPreviewDirectory(),
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
