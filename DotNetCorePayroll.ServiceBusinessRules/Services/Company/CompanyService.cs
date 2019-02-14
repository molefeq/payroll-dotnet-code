using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.ViewModels.Company;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using Microsoft.Extensions.Configuration;
using SqsLibraries.Common.Utilities.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCorePayroll.ServiceBusinessRules.Services.Company
{
    public class CompanyService : ICompanyService
    {
        private IUnitOfWork unitOfWork;
        private CompanyBuilder companyBuilder;
        private CompanyAdapter companyAdapter;

        public CompanyService(IUnitOfWork unitOfWork, CompanyBuilder companyBuilder, CompanyAdapter companyAdapter)
        {
            this.unitOfWork = unitOfWork;
            this.companyBuilder = companyBuilder;
            this.companyAdapter = companyAdapter;
        }
        
        public CompanyModel Add(CompanyModel companyModel)
        {
            var company = companyBuilder.Build(companyModel);

            unitOfWork.Company.Insert(company);
            unitOfWork.Save();

            return companyBuilder.BuildToCompanyModel(unitOfWork.Company.GetById(o => o.Id == company.Id));
        }

        public void Delete(long id)
        {
            var company = unitOfWork.Company.GetById(o => o.Id == id);

            if (company == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Company you trying to delete does not exist."));
            }

            unitOfWork.Company.Delete(company);
            unitOfWork.Save();
        }

        public CompanyModel Find(long id)
        {
            var company = unitOfWork.Company.GetById(o => o.Id == id);

            if (company == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Company you trying to update does not exist."));
            }

            return companyBuilder.BuildToCompanyModel(company);
        }

        public Result<CompanyModel> Get(long organisationId, string searchText, PageData pageData)
        {
            var results = unitOfWork.Company.Get(organisationId, searchText, pageData);

            return new Result<CompanyModel>
            {
                Items = results.Items.Select(o => companyBuilder.BuildToCompanyModel(o)).ToList(),
                TotalItems = results.TotalItems
            };
        }

        public void MapRelativeLogoPath(CompanyModel companyModel, IConfiguration configuration, string currentUrl)
        {
            if (string.IsNullOrEmpty(companyModel.LogoFileName))
            {
                return;
            }

            companyModel.LogoFileNamePath = FileHandler.GetRelativeFileName(new Uri(currentUrl + configuration.OrganisationPreviewDirectory()).AbsoluteUri, companyModel.LogoFileName);
        }

        public void MapRelativeLogoPaths(List<CompanyModel> companyModels, IConfiguration configuration, string currentUrl)
        {
            if (companyModels == null || companyModels.Count == 0)
            {
                return;
            }

            companyModels.ForEach(item => MapRelativeLogoPath(item, configuration, currentUrl));
        }

        public void ResizeLogos(CompanyModel companyModel, IConfiguration configuration, string rootPath, string currentUrl)
        {
            string tempPhysicalTempDirectory = rootPath + configuration.CompanyNormalTempDirectory();
            string logoFileName = FileHandler.GetPhysicalFileName(tempPhysicalTempDirectory, companyModel.LogoFileName);

            FileHandler.ResizeImage(logoFileName, companyModel.LogoFileName,
                new ImageModel
                {

                    Width = configuration.CompanyNormalImageWidth(),
                    Height = configuration.CompanyNormalImageHeight(),
                    PhysicalDirectory = rootPath + configuration.CompanyNormalDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.CompanyNormalDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, companyModel.LogoFileName,
                new ImageModel
                {
                    Width = configuration.CompanyThumbnailImageWidth(),
                    Height = configuration.CompanyThumbnailImageHeight(),
                    PhysicalDirectory = rootPath + configuration.CompanyThumbnailDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.CompanyThumbnailDirectory()).AbsoluteUri
                });

            FileHandler.ResizeImage(logoFileName, companyModel.LogoFileName,
                new ImageModel
                {
                    Width = configuration.CompanyPreviewImageWidth(),
                    Height = configuration.CompanyPreviewImageHeight(),
                    PhysicalDirectory = rootPath + configuration.CompanyPreviewDirectory(),
                    RelativeDirectory = new Uri(currentUrl + configuration.CompanyPreviewDirectory()).AbsoluteUri
                });
        }

        public CompanyModel Update(CompanyModel companyModel)
        {
            var company = unitOfWork.Company.GetById(o => o.Id == companyModel.Id.Value);

            if (company == null)
            {
                throw new ResponseValidationException(ResponseMessage.ToError("Company you trying to update does not exist."));
            }

            companyAdapter.Update(company, companyModel);
            unitOfWork.Company.Update(company);
            unitOfWork.Save();

            return companyBuilder.BuildToCompanyModel(unitOfWork.Company.GetById(o => o.Id == companyModel.Id));
        }
    }
}
