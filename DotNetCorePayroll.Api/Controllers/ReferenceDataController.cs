using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.ServiceBusinessRules.Services;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace DotNetCorePayroll.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ReferenceDataController : Controller
    {
        private IReferenceDataService referenceDataService;

        public ReferenceDataController(IReferenceDataService referenceDataService)
        {
            this.referenceDataService = referenceDataService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(StaticDataModel), 200)]
        public IActionResult GetStaticData()
        {
            return Ok(referenceDataService.GetStaticData());
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReferenceDataModel>), 200)]
        public IActionResult GetCountries()
        {
            return Ok(referenceDataService.GetCountries());
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ReferenceDataModel>), 200)]
        public IActionResult GetProvinces()
        {
            return Ok(referenceDataService.GetProvinces());
        }

    }
}