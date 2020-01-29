using DotNetCorePayroll.Api.Extensions;
using DotNetCorePayroll.Api.IocContainers;
using DotNetCorePayroll.Api.Providers;
using DotNetCorePayroll.DataAccess;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Swagger;

using System;
using System.Text;
using Serilog;

namespace DotNetCorePayroll.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["token:issuer"],
                    ValidAudience = Configuration["token:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["token:key"])),
                    ClockSkew = TimeSpan.Zero // remove delay of token when expire
                };
            });

            services.AddAuthorization();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Zenit Payroll API V1",
                    Version = "v1",
                    Description = "Zenit Payroll Web API written in ASP.NET Core Web API",
                    Contact = new Contact { Name = "Qinisela Molefe", Email = "molefeq@gmail.com", Url = "https://www.codeassembly.co.za" },
                });

                //// Set the comments path for the Swagger JSON and UI.
                //var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                //var xmlPath = Path.Combine(basePath, "dotnetcore-file-upload.xml");
                //c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("all_origins", policy => policy.WithOrigins("http://localhost:4300")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        );
            });

            services.AddDbContext<PayrollContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Payroll_DB_Local")), ServiceLifetime.Transient);
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            Adapters.Initialise(services);
            Builders.Initialise(services);
            BusinessRules.Initialise(services);
            Services.Initialise(services);


            services.AddScoped<LoginProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UsePayrollExceptionHandler();
            app.UseSwagger();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zenit Payroll API V1");
            });
            app.UseCors("all_origins");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
