using DotNetCorePayroll.Common.Exceptions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

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

            if (exception is ResponseValidationException)
            {
                ResponseValidationException responseValidationException = exception as ResponseValidationException;

                context.Response.StatusCode = 442;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(responseValidationException.Messages));
            }

            var logger = loggerFactory.CreateLogger("Serilog Global exception logger");
            logger.LogError((int)HttpStatusCode.InternalServerError, exception, exception.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = "Unexpected error has occurred please try again later." }));
        }
    }
}
