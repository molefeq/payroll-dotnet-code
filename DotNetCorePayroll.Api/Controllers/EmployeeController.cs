using DotNetCorePayroll.Api.ActionResultHelpers;
using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Common.Extensions;
using DotNetCorePayroll.Common.Utilities;
using DotNetCorePayroll.Data.SearchFilters;
using DotNetCorePayroll.Data.ViewModels.Employee;
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
    public class EmployeeController : Controller
    {
        private IConfiguration configuration;
        private IWebHostEnvironment environment;

        public EmployeeController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Result<EmployeeModel>), 200)]
        public IActionResult GetEmployees([FromBody]EmployeeSearchFilter searchFilter)
        {
            //Result<OrganisationModel> result = ogranisationService.Get(searchFilter.SearchText, searchFilter.PageData);

            //ogranisationService.MapRelativeLogoPaths(result.Items, configuration, HttpContext.Request.CurrentUrl());

            return Ok(new Result<EmployeeModel>());
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), 200)]
        public IActionResult AddEmployee([FromBody]EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            // OrganisationModel model = ogranisationService.Add(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new EmployeeModel());
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), 200)]
        public IActionResult UpdateEmployee([FromBody]EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            //OrganisationModel model = ogranisationService.Update(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new EmployeeModel());
        }

        [HttpPost]
        public IActionResult DeleteEmployee([FromBody]EmployeeModel employeeModel)
        {
            //ogranisationService.Delete(organisationModel.Id.Value);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeModel), 200)]
        public IActionResult FetchEmployee(Guid employeeId)
        {
            //CompanyModel organisationModel = ogranisationService.Find(organisationId);

            //ogranisationService.MapRelativeLogoPath(organisationModel, configuration, HttpContext.Request.CurrentUrl());

            return Ok(new EmployeeModel());
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), 200)]
        public IActionResult SaveEmployeeContactDetails([FromBody]EmployeeAddressModel employeeContactDetail)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            //OrganisationModel model = ogranisationService.Update(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new EmployeeModel());
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), 200)]
        public IActionResult SaveEmployeeNextOfKin([FromBody]EmployeeNextOfKinDetailModel employeeNextOfKinModel)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            //OrganisationModel model = ogranisationService.Update(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new EmployeeModel());
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
                Width = configuration.CompanyNormalImageWidth(),
                Height = configuration.CompanyNormalImageHeight(),
                PhysicalDirectory = environment.WebRootPath + configuration.CompanyNormalTempDirectory(),
                RelativeDirectory = new Uri(HttpContext.Request.CurrentUrl() + configuration.CompanyNormalTempDirectory()).AbsoluteUri
            };
            string filename = FileHandler.SaveImage(image);

            return Ok(new { filename = filename, size = size, imageUrl = image.RelativeFileName });
        }

        #region Employee Bank Details

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), 200)]
        public IActionResult SaveEmployeeBankingDetails([FromBody]EmployeeBankDetailModel model)
        {
            if (!ModelState.IsValid)
            {
                return new ValidationActionResult(ModelState);
            }

            // OrganisationModel model = ogranisationService.Add(organisationModel);

            //ImageFixing(model, organisationModel.LogoFileNamePath);

            return Ok(new EmployeeModel());
        }

        #endregion

        #region Private Methods

        private void ImageFixing(EmployeeModel companyModel, string logoFileNamePath)
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