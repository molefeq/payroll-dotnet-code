using DotNetCorePayroll.Console.Service;
using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using DotNetCorePayroll.ServiceBusinessRules.Services;
using DotNetCorePayroll.ServiceBusinessRules.Services.Account;
using DotNetCorePayroll.ServiceBusinessRules.Services.Organisation;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SqsLibraries.Common.Utilities.ResponseObjects;
using System;
using System.Linq;

namespace DotNetCorePayroll.Console
{
    class Program
    {
       // private static IntergrationTestsSetup IntergrationTestsSetup = new IntergrationTestsSetup();
        private static ServiceProvider serviceProvider = new ServiceCollection().AddLogging()
                                                                                .AddDbContext<PayrollContext>(options => options.UseNpgsql("Server=46.101.0.74;Port=5432;User Id=payroll;Password=Manbehind5;Database=payroll_db;"), ServiceLifetime.Scoped)
                                                                                .AddSingleton<OrganisationBuilder>()
                                                                                .AddSingleton<OrganisationAdapter>()
                                                                                .AddScoped<IOgranisationService, OgranisationService>()
                                                                                .AddSingleton<AccountBuilder>()
                                                                                .AddSingleton<AccountBusinessRules>()
                                                                                .AddScoped<IAccountService, AccountService>()
                                                                                .AddScoped<AccountServiceInvoker>()
                                                                                .AddSingleton<AccountAdapter>()
                                                                                .AddTransient<IUnitOfWork, UnitOfWork>()
                                                                                .BuildServiceProvider();

        static void Main(string[] args)
        {

            var accountServiceInvoker = serviceProvider.GetService<AccountServiceInvoker>();


            accountServiceInvoker.Login();

            //var ogranisationService = serviceProvider.GetService<IOgranisationService>();
            //var organisations = ogranisationService.Get(null, new PageData { Skip = 0, Take = 10 });
            //var organisation = ogranisationService.Add(MockOrganisationModel());
            //var organisation = ogranisationService.Update(MockUpdateOrganisationModel());
            //ogranisationService.Delete(new Guid("5aa98f75-357b-4c44-ace1-dee96702afb4"));
        }

    }
}
