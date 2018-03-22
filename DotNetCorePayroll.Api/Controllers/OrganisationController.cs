//using DotNetCorePayroll.Api.Extensions;
//using DotNetCorePayroll.Common.Utilities;
//using DotNetCorePayroll.Data.SearchFilters;
//using DotNetCorePayroll.Data.ViewModels;
//using DotNetCorePayroll.ServiceBusinessRules.Services;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

//using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.IO;

namespace DotNetCorePayroll.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrganisationController : Controller
    {
        //private IOgranisationService ogranisationService;
        //private IConfiguration configuration;
        //private IHostingEnvironment environment;

        //public OrganisationController(IOgranisationService ogranisationService, IConfiguration configuration, IHostingEnvironment environment)
        //{
        //    this.ogranisationService = ogranisationService;
        //    this.configuration = configuration;
        //    this.environment = environment;
        //}

        //[HttpPost]
        //public Result<OrganisationModel> GetOrganisations(SearchFilter searchFilter)
        //{
        //    Result<OrganisationModel> result = ogranisationService.Get(searchFilter.SearchText, searchFilter.PageData);

        //    ogranisationService.MapRelativeLogoPaths(result.Items, configuration, HttpContext.Request.CurrentUrl());

        //    return result;
        //}

        //[HttpPost]
        //public Response<OrganisationModel> AddOrganisation(OrganisationModel organisationModel)
        //{
        //    Response<OrganisationModel> response = ogranisationService.Add(organisationModel);

        //    ImageFixing(response.Item, organisationModel.LogoFileNamePath);

        //    return response;
        //}

        //[HttpPost]
        //public Response<OrganisationModel> UpdateOrganisation(OrganisationModel organisationModel)
        //{
        //    Response<OrganisationModel> response = ogranisationService.Update(organisationModel);

        //    ImageFixing(response.Item, organisationModel.LogoFileNamePath);

        //    return response;
        //}

        //[HttpPost]
        //public Response<OrganisationModel> DeleteOrganisation(OrganisationModel organisationModel)
        //{
        //    Response<OrganisationModel> response = ogranisationService.Delete(organisationModel.Id.Value);

        //    ImageFixing(response.Item, organisationModel.LogoFileNamePath);

        //    return response;
        //}

        //[HttpPost]
        //public Response<OrganisationModel> FetchOrganisation(Guid organisationId)
        //{
        //    Response<OrganisationModel> response = ogranisationService.Find(organisationId);

        //    ogranisationService.MapRelativeLogoPath(response.Item, configuration, HttpContext.Request.CurrentUrl());

        //    return response;
        //}

        //[HttpPost]
        //public IActionResult SaveImage(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest(new { message = "Image upload failed, file is required and must not be null." });
        //    }

        //    long size = file.Length;

        //    string filename = FileHandler.SaveImage(new ImageModel
        //    {
        //        File = file.OpenReadStream(),
        //        OriginalFileName = file.FileName,
        //        Width = configuration.OrganisationNormalImageWidth(),
        //        Height = configuration.OrganisationNormalImageHeight(),
        //        PhysicalDirectory = Path.Combine(environment.WebRootPath, configuration.OrganisationNormalTempDirectory()),
        //        RelativeDirectory = new Uri(HttpContext.Request.CurrentUrl() + configuration.OrganisationNormalTempDirectory()).AbsoluteUri
        //    });

        //    return Ok(new { filename, size });
        //}

        //#region Private Methods

        //private void ImageFixing(OrganisationModel organisationModel, string logoFileNamePath)
        //{
        //    if (organisationModel == null || string.IsNullOrEmpty(logoFileNamePath))
        //    {
        //        return;
        //    }

        //    if (logoFileNamePath.Contains(configuration.OrganisationNormalTempDirectory()))
        //    {
        //        ogranisationService.ResizeLogos(organisationModel, configuration, environment.WebRootPath, HttpContext.Request.CurrentUrl());
        //    }

        //    ogranisationService.MapRelativeLogoPath(organisationModel, configuration, HttpContext.Request.CurrentUrl());
        //}

        //#endregion
    }
}