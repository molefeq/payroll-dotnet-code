using DotNetCorePayroll.ServiceBusinessRules.Services.Account;
using DotNetCorePayroll.ServiceBusinessRules.Services.Role;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCorePayroll.Api.IocContainers
{
    public class BusinessRules
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<AccountBusinessRules>();
            services.AddSingleton<RoleBusinessRules>();
        }
    }
}
