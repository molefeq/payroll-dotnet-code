using DotNetCorePayroll.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotNetCorePayroll.Api.ActionResultHelpers
{
    public class ValidationActionResult : ObjectResult
    {
        public ValidationActionResult(ModelStateDictionary modelState) : base(modelState.ToResponseMessages())
        {
            StatusCode = 422;
        }
    }
}
