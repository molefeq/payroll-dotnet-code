﻿using DotNetCorePayroll.Api.ActionResultHelpers;
using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using SqsLibraries.Common.Utilities.ResponseObjects;

using System;
using System.IO;

namespace DotNetCorePayroll.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class OrganisationController : Controller
    {
        private IOgranisationService ogranisationService;
        private IConfiguration configuration;
        private IWebHostEnvironment environment;

        public OrganisationController(IOgranisationService ogranisationService, IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.ogranisationService = ogranisationService;
            this.configuration = configuration;
            this.environment = environment;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<OrganisationModel>), 200)]
        public IActionResult GetOrganisations([FromBody]SearchFilter searchFilter)
        {
            Result<OrganisationModel> result = ogranisationService.Get(searchFilter.SearchText, searchFilter.PageData);

            ogranisationService.MapRelativeLogoPaths(result.Items, configuration, HttpContext.Request.CurrentUrl());

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrganisationModel), 200)]
        public IActionResult AddOrganisation([FromBody]OrganisationModel organisationModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            OrganisationModel model = ogranisationService.Add(organisationModel);

            ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrganisationModel), 200)]
        public IActionResult UpdateOrganisation([FromBody]OrganisationModel organisationModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }
            OrganisationModel model = ogranisationService.Update(organisationModel);

            ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult DeleteOrganisation([FromBody]OrganisationModel organisationModel)
        {
            ogranisationService.Delete(organisationModel.Id.Value);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(OrganisationModel), 200)]
        public IActionResult FetchOrganisation(long organisationId)
        {
            OrganisationModel organisationModel = ogranisationService.Find(organisationId);

            ogranisationService.MapRelativeLogoPath(organisationModel, configuration, HttpContext.Request.CurrentUrl());

            return Ok(organisationModel);
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult SaveImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "Image upload failed, file is required and must not be null." });
            }

            long size = file.Length;

            if (string.IsNullOrWhiteSpace(environment.WebRootPath))
            {
                environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "");
            }

            ImageModel image = new ImageModel
            {
                File = file.OpenReadStream(),
                OriginalFileName = file.FileName,
                Width = configuration.OrganisationNormalImageWidth(),
                Height = configuration.OrganisationNormalImageHeight(),
                PhysicalDirectory = environment.WebRootPath + configuration.OrganisationNormalTempDirectory(),
                RelativeDirectory = new Uri(HttpContext.Request.CurrentUrl() + configuration.OrganisationNormalTempDirectory()).AbsoluteUri
            };
            string filename = FileHandler.SaveImage(image);

            return Ok(new { filename = filename, size = size, imageUrl = image.RelativeFileName });
        }

        #region Private Methods

        private void ImageFixing(OrganisationModel organisationModel, string logoFileNamePath)
        {
            if (organisationModel == null || string.IsNullOrEmpty(logoFileNamePath))
            {
                return;
            }

            if (logoFileNamePath.Contains(configuration.OrganisationNormalTempDirectory()))
            {
                ogranisationService.ResizeLogos(organisationModel, configuration, environment.WebRootPath, HttpContext.Request.CurrentUrl());
            }

            ogranisationService.MapRelativeLogoPath(organisationModel, configuration, HttpContext.Request.CurrentUrl());
        }

        #endregion
    }
}