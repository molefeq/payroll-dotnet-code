using DotNetCorePayroll.ServiceBusinessRules.Services;
using DotNetCorePayroll.ServiceBusinessRules.Services.Account;
using DotNetCorePayroll.ServiceBusinessRules.Services.Organisation;
using DotNetCorePayroll.ServiceBusinessRules.Services.Role;

using Microsoft.Extensions.DependencyInjection;
using SqsLibraries.Common.Email;

namespace DotNetCorePayroll.Api.IocContainers
{
    public class Services
    {
        public static void Initialise(IServiceCollection services)
        {
            services.AddScoped<IEmailHandler, SmtpMailGunEmailHandler>();
            services.AddScoped<IOgranisationService, OgranisationService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
