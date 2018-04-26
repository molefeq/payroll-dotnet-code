using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Common.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SqsLibraries.Common.Utilities.ResponseObjects;
using System.Collections.Generic;

namespace DotNetCorePayroll.Api.ActionResultHelpers
{
    public class ValidationActionResult : ObjectResult
    {
        public ValidationActionResult(ModelStateDictionary modelState) : base(modelState.ToResponseMessages())
        {
            StatusCode = Constants.VALIDATION_HTTP_STATUS_CODE;
        }

        public ValidationActionResult(List<ResponseMessage> validationMessages) : base(validationMessages)
        {
            StatusCode = Constants.VALIDATION_HTTP_STATUS_CODE;
        }
    }
}
