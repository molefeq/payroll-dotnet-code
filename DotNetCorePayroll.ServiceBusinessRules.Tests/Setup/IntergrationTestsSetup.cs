using DotNetCorePayroll.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace DotNetCorePayroll.ServiceBusinessRules.Tests.Setup
{
    public class IntergrationTestsSetup
    {
        public IConfiguration Configuration { get; set; }
        public DbContextOptions<PayrollContext> ContextOptions { get; set; }

        public IntergrationTestsSetup()
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName)
                   .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            ContextOptions = new DbContextOptionsBuilder<PayrollContext>()
                   .UseNpgsql(Configuration.GetConnectionString("Payroll_DB_Local"))
                   .Options;
        }

    }
}
