using DotNetCorePayroll.ServiceBusinessRules.Services;
using DotNetCorePayroll.ServiceBusinessRules.Services.Organisation;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCorePayroll.Api.IocContainers
{
    public class Services
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<IOgranisationService, OgranisationService>();
        }
    }
}
