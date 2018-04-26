using DotNetCorePayroll.Common.Exceptions;
using DotNetCorePayroll.Common.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DotNetCorePayroll.Api.Extensions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder UsePayrollExceptionHandler(this IApplicationBuilder app)
        {
            var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

            return app.UseExceptionHandler(HandleApiException(loggerFactory));
        }

        public static Action<IApplicationBuilder> HandleApiException(ILoggerFactory loggerFactory)
        {
            return appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    await HandleExceptionAsync(context, loggerFactory);
                });
            };
        }

        private static Task HandleExceptionAsync(HttpContext context, ILoggerFactory loggerFactory)
        {
            Exception exception = context.Features.Get<IExceptionHandlerFeature>().Error;

            context.Response.ContentType = "application/json";



            context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            if (exception is ResponseValidationException)
            {
                ResponseValidationException responseValidationException = exception as ResponseValidationException;

                context.Response.StatusCode = Constants.VALIDATION_HTTP_STATUS_CODE;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(responseValidationException.Messages, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }));
            }

            var logger = loggerFactory.CreateLogger("Serilog Global exception logger");
            logger.LogError((int)HttpStatusCode.InternalServerError, exception, exception.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = "Unexpected error has occurred please try again later." }));
        }
    }
}
