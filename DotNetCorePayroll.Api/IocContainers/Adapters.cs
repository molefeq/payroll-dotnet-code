using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCorePayroll.Api.IocContainers
{
    public class Adapters
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<OrganisationAdapter>();
            services.AddSingleton<AccountAdapter>();
            services.AddSingleton<RoleAdapter>();
            services.AddSingleton<AddressAdapter>();
        }
    }
}
