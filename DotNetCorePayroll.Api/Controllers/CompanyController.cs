using DotNetCorePayroll.Api.ActionResultHelpers;
using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.Data.ViewModels.Company;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SqsLibraries.Common.Utilities.ResponseObjects;
using System;
using System.IO;

namespace DotNetCorePayroll.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class CompanyController : Controller
    {
        private IConfiguration configuration;
        private IHostingEnvironment environment;

        public CompanyController(IConfiguration configuration, IHostingEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<CompanyModel>), 200)]
        public IActionResult GetCompanies([FromBody]CompanySearchFilter searchFilter)
        {
            //Result<OrganisationModel> result = ogranisationService.Get(searchFilter.SearchText, searchFilter.PageData);

            //ogranisationService.MapRelativeLogoPaths(result.Items, configuration, HttpContext.Request.CurrentUrl());

            return Ok(new Result<CompanyModel>());
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyModel), 200)]
        public IActionResult AddCompany([FromBody]CompanyModel companyModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            // OrganisationModel model = ogranisationService.Add(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new CompanyModel());
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyModel), 200)]
        public IActionResult UpdateCompany([FromBody]CompanyModel companyModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            //OrganisationModel model = ogranisationService.Update(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new CompanyModel());
        }

        [HttpPost]
        public IActionResult DeleteCompany([FromBody]CompanyModel companyModel)
        {
            //ogranisationService.Delete(organisationModel.Id.Value);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(CompanyModel), 200)]
        public IActionResult FetchCompany(Guid companyId)
        {
            //CompanyModel organisationModel = ogranisationService.Find(organisationId);

            //ogranisationService.MapRelativeLogoPath(organisationModel, configuration, HttpContext.Request.CurrentUrl());

            return Ok(new CompanyModel());
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CompanyModel), 200)]
        public IActionResult SaveCompanyContactDetails([FromBody]CompanyContactDetailModel companyContactDetail)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            //OrganisationModel model = ogranisationService.Update(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new CompanyModel());
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyModel), 200)]
        public IActionResult SaveCompanyPayrollSettings([FromBody]CompanyPayrollSettingModel companyPayrollSettingModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            //OrganisationModel model = ogranisationService.Update(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new CompanyModel());
        }

        [HttpPost]
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
                Width = configuration.CompanyNormalImageWidth(),
                Height = configuration.CompanyNormalImageHeight(),
                PhysicalDirectory = environment.WebRootPath + configuration.CompanyNormalTempDirectory(),
                RelativeDirectory = new Uri(HttpContext.Request.CurrentUrl() + configuration.CompanyNormalTempDirectory()).AbsoluteUri
            };
            string filename = FileHandler.SaveImage(image);

            return Ok(new { filename = filename, size = size, imageUrl = image.RelativeFileName });
        }

        #region Company Bank Details
        
        [HttpPost]
        [ProducesResponseType(typeof(CompanyModel), 200)]
        public IActionResult SaveBankingDetails([FromBody]CompanyBankDetailModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            // OrganisationModel model = ogranisationService.Add(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new CompanyModel());
        }

        #endregion

        #region Private Methods

        private void ImageFixing(CompanyModel companyModel, string logoFileNamePath)
        {
            if (companyModel == null || string.IsNullOrEmpty(logoFileNamePath))
            {
                return;
            }

            /*if (logoFileNamePath.Contains(configuration.OrganisationNormalTempDirectory()))
            {
                ogranisationService.ResizeLogos(organisationModel, configuration, environment.WebRootPath, HttpContext.Request.CurrentUrl());
            }

            ogranisationService.MapRelativeLogoPath(organisationModel, configuration, HttpContext.Request.CurrentUrl());*/
        }

        #endregion
    }
}
