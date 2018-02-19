using DotNetCorePayroll.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.IO;

namespace DotNetCorePayroll.Console
{
    public class IntergrationTestsSetup
    {
        public IConfiguration Configuration { get; set; }
        public DbContextOptions<PayrollContext> ContextOptions { get; set; }

        public IntergrationTestsSetup()
        {
            string startupPath = System.IO.Directory.GetParent(@"./").FullName;
            var path = System.IO.Path.GetFullPath(@"..\..\..\");
            var currentPath = Directory.GetCurrentDirectory();

            Debug.WriteLine(System.IO.Path.GetFullPath(".\\"));
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json");


            Configuration = builder.Build();
            ContextOptions = new DbContextOptionsBuilder<PayrollContext>()
                   .UseNpgsql(Configuration.GetConnectionString("Payroll_DB_Local"))
                   .Options;
        }
    }
}
