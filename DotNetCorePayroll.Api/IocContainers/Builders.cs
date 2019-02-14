using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCorePayroll.Api.IocContainers
{
    public class Builders
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddSingleton<OrganisationBuilder>();
            services.AddSingleton<AccountBuilder>();
            services.AddSingleton<RoleBuilder>();
            services.AddSingleton<AddressBuilder>();
            services.AddSingleton<CompanyBuilder>();
        }
    }
}
