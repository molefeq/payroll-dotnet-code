using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SqsLibraries.Common.Utilities.ResponseObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace DotNetCorePayroll.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Organisation")]
    public class OrganisationController : Controller
    {
        private IOgranisationService ogranisationService;

        public OrganisationController(IOgranisationService ogranisationService)
        {
            this.ogranisationService = ogranisationService;
        }

        [HttpPost]
        public Result<OrganisationModel> GetOrganisations(SearchFilter searchFilter)
        {
            Result<OrganisationModel> result = ogranisationService.Get(searchFilter.SearchText, searchFilter.PageData);

            MapRelativeLogoPaths(result.Items);

            return result;
        }

        [HttpPost]
        public Response<OrganisationModel> AddOrganisation(OrganisationModel organisationModel)
        {
            Response<OrganisationModel> response = ogranisationService.Add(organisationModel);

            ImageFixing(response.Item, organisationModel.LogoFileNamePath);

            return response; // Request.CreateResponse<Response<OrganisationModel>>(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public Response<OrganisationModel> UpdateOrganisation(OrganisationModel organisationModel)
        {
            Response<OrganisationModel> response = ogranisationService.Update(organisationModel);

            ImageFixing(response.Item, organisationModel.LogoFileNamePath);

            return response; //Request.CreateResponse<Response<OrganisationModel>>(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public Response<OrganisationModel> DeleteOrganisation(OrganisationModel organisationModel)
        {
            Response<OrganisationModel> response = ogranisationService.Delete(organisationModel.Id.Value);

            ImageFixing(response.Item, organisationModel.LogoFileNamePath);

            return response; //Request.CreateResponse<Response<OrganisationModel>>(HttpStatusCode.OK, response);
        }

        [HttpPost]
        public Response<OrganisationModel> FetchOrganisation(Guid organisationId)
        {
            Response<OrganisationModel> response = ogranisationService.Find(organisationId);

            MapRelativeLogoPath(response.Item);

            return response;
        }

        [HttpPost]
        public void SaveImage(ICollection<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
              // return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType);
            }

            //ImageInformation normalImageInformation = new ImageInformation
            //{
            //    Width = AppSettingsUtils.GetDimensionWidth("OrganisationImagesNormalDimension"),
            //    Height = AppSettingsUtils.GetDimensionHeight("OrganisationImagesNormalDimension"),
            //    PhysicalDirectory = AppSettingsUtils.GetAppSettingPhysicalPath("OrganisationImagesTempDirectory", HttpContext.Current.Server.MapPath),
            //    RelativeDirectory = AppSettingsUtils.GetAppSettingUri(HttpContext.Current.Request.Url, "OrganisationImagesTempDirectory", VirtualPathUtility.ToAbsolute)
            //};

            //string fileName = UploadFileHandler.SaveUploadedImage(httpRequest.Files[0], normalImageInformation);

            //return Request.CreateResponse<ImageModel>(HttpStatusCode.OK, new ImageModel { ImageFileNamePath = normalImageInformation.RelativeFileName, ImageFileName = fileName });

            return;
        }

        #region Private Methods

        private void ImageFixing(OrganisationModel organisationModel, string logoFileNamePath)
        {
            if (organisationModel == null || string.IsNullOrEmpty(logoFileNamePath))
            {
                return;
            }

            //if (logoFileNamePath.Contains("/Organisations/Temp/"))
            //{
            //    ResizeLogos(organisationModel);
            //}

            //MapRelativeLogoPath(organisationModel);
        }

        //private void ResizeLogos(OrganisationModel organisationModel)
        //{
        //    string logoFileName = UploadFileHandler.GetPhysicalFileName(AppSettingsUtils.GetAppSettingPhysicalPath("OrganisationImagesTempDirectory", HttpContext.Current.Server.MapPath), organisationDto.LogoFileName);

        //    UploadFileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
        //        new ImageInformation
        //        {

        //            Width = AppSettingsUtils.GetDimensionWidth("OrganisationImagesNormalDimension"),
        //            Height = AppSettingsUtils.GetDimensionHeight("OrganisationImagesNormalDimension"),
        //            PhysicalDirectory = AppSettingsUtils.GetAppSettingPhysicalPath("OrganisationImagesNormalDirectory", HttpContext.Current.Server.MapPath),
        //            RelativeDirectory = AppSettingsUtils.GetAppSettingUri(HttpContext.Current.Request.Url, "OrganisationImagesNormalDirectory", VirtualPathUtility.ToAbsolute)
        //        });

        //    UploadFileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
        //        new ImageInformation
        //        {

        //            Width = AppSettingsUtils.GetDimensionWidth("OrganisationImagesThumbnailsDimension"),
        //            Height = AppSettingsUtils.GetDimensionHeight("OrganisationImagesThumbnailsDimension"),
        //            PhysicalDirectory = AppSettingsUtils.GetAppSettingPhysicalPath("OrganisationImagesThumbnailsDirectory", HttpContext.Current.Server.MapPath),
        //            RelativeDirectory = AppSettingsUtils.GetAppSettingUri(HttpContext.Current.Request.Url, "OrganisationImagesThumbnailsDirectory", VirtualPathUtility.ToAbsolute)
        //        });

        //    UploadFileHandler.ResizeImage(logoFileName, organisationModel.LogoFileName,
        //        new ImageInformation
        //        {

        //            Width = AppSettingsUtils.GetDimensionWidth("OrganisationImagesPreviewDimension"),
        //            Height = AppSettingsUtils.GetDimensionHeight("OrganisationImagesPreviewDimension"),
        //            PhysicalDirectory = AppSettingsUtils.GetAppSettingPhysicalPath("OrganisationImagesPreviewDirectory", HttpContext.Current.Server.MapPath),
        //            RelativeDirectory = AppSettingsUtils.GetAppSettingUri(HttpContext.Current.Request.Url, "OrganisationImagesPreviewDirectory", VirtualPathUtility.ToAbsolute)
        //        });
        //}

        private void MapRelativeLogoPaths(List<OrganisationModel> organisationModels)
        {
            if (organisationModels == null || organisationModels.Count == 0)
            {
                return;
            }

            organisationModels.ForEach(item => MapRelativeLogoPath(item));
        }

        private void MapRelativeLogoPath(OrganisationModel organisationModel)
        {
            if (string.IsNullOrEmpty(organisationModel.LogoFileName))
            {
                return;
            }

            // organisationModel.LogoFileNamePath = AppSettingsUtils.GetStringAppSetting("SiteUrl") + UploadFileHandler.GetRelativeFileName(AppSettingsUtils.GetAppSettingPhysicalPath("OrganisationImagesNormalDirectory", VirtualPathUtility.ToAbsolute), organisationDto.LogoFileName);
        }

        #endregion
    }
}