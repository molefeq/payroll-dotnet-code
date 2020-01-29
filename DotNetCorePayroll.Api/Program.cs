using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Serilog;

using System;
using System.IO;

namespace DotNetCorePayroll.Api
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json").Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                   .ReadFrom.Configuration(Configuration)
                   .CreateLogger();
            try
            {
                Log.Information("Host starting...");

                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               })
               .UseSerilog();
    }
}
