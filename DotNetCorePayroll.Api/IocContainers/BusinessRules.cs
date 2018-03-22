using DotNetCorePayroll.ServiceBusinessRules.Services.Account;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCorePayroll.Api.IocContainers
{
    public class BusinessRules
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<AccountBusinessRules>();
        }
    }
}
