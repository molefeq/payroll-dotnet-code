using DotNetCorePayroll.Data;
using DotNetCorePayroll.Data.ViewModels;
using DotNetCorePayroll.DataAccess;
using DotNetCorePayroll.ServiceBusinessRules.ModelAdapters;
using DotNetCorePayroll.ServiceBusinessRules.ModelBuilders;
using DotNetCorePayroll.ServiceBusinessRules.Services;
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
        private static IntergrationTestsSetup IntergrationTestsSetup = new IntergrationTestsSetup();
        private static ServiceProvider serviceProvider = new ServiceCollection().AddLogging()
                                                                                .AddDbContext<PayrollContext>(options => options.UseNpgsql(IntergrationTestsSetup.Configuration.GetConnectionString("Payroll_DB_Local")), ServiceLifetime.Scoped)
                                                                                .AddSingleton<OrganisationBuilder>()
                                                                                .AddSingleton<OrganisationAdapter>()
                                                                                .AddScoped<IOgranisationService, OgranisationService>()
                                                                                .BuildServiceProvider();

        static void Main(string[] args)
        {
            var ogranisationService = serviceProvider.GetService<IOgranisationService>();
            var organisations = ogranisationService.Get(null, new PageData { Skip = 0, Take = 10 });
            //var organisation = ogranisationService.Add(MockOrganisationModel());
            //var organisation = ogranisationService.Update(MockUpdateOrganisationModel());
            //ogranisationService.Delete(new Guid("5aa98f75-357b-4c44-ace1-dee96702afb4"));
        }

        static OrganisationModel MockUpdateOrganisationModel()
        {
            return new OrganisationModel
            {
                Id = new Guid("5aa98f75-357b-4c44-ace1-dee96702afb4"),
                Name = "Test Organisation 2",
                Description = "Test Organisation 2 Description",
                PhysicalAddressLine1 = "Unit 08 Sonwaba",
                PhysicalAddressLine2 = "South African Drive",
                PhysicalAddressSuburb = "Cosmo City",
                PhysicalAddressCity = "Randburg",
                EmailAddress = "molefeq@gmail.com",
                ContactNumber = "0114475309",
                LogoFileName = "/images/logo.gif",
                FaxNumber = "0117841256",
                PostalAddressLine1 = "Investec Building",
                PostalAddressLine2 = "120 Grayston Drive",
                PostalAddressSuburb = "Sandton",
                PostalAddressCity = "Sandton",
                PostalAddressPostalCode = "2189"
            };
        }

        static OrganisationModel MockOrganisationModel()
        {
            return new OrganisationModel
            {
                Name = "Organisation 2",
                Description = "My Organisation 2",
                PhysicalAddressLine1 = "Unit 03 Sonwaba",
                PhysicalAddressLine2 = "South African Drive",
                PhysicalAddressSuburb = "Cosmo City",
                PhysicalAddressCity = "Randburg",
                EmailAddress = "molefeq@gmail.com",
                ContactNumber = "0114475309",
                LogoFileName = "/images/logo.gif",
                FaxNumber = "0117841256",
                PostalAddressLine1 = "Investec",
                PostalAddressLine2 = "100 Grayston Drive",
                PostalAddressSuburb = "Sandton",
                PostalAddressCity = "Sandton",
                PostalAddressPostalCode = "2189"
            };
        }

        static void InsertCountry()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var country = new Country { Name = "South Africa", Code = "ZAR" };

                context.Country.Add(country);
                context.SaveChanges();
            }
        }

        static void FetchCountries()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var countries = context.Country.ToList();

                foreach (var country in countries)
                {
                    System.Console.WriteLine(string.Format("Country Id: {0} Code: {1} Name: {2}", country.Id, country.Code, country.Name));
                }

            }
        }

        static void InsertProvince()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var country = context.Country.Where(c => c.Code == "ZAR").FirstOrDefault();
                var province = new Province { Name = "Gauteng", Code = "GP", CountryId = country.Id };

                context.Province.Add(province);
                context.SaveChanges();
            }
        }

        static void FetchProvinces()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                foreach (var province in context.Province)
                {
                    System.Console.WriteLine(string.Format("Province Id: {0} Code: {1} Name: {2}", province.Id, province.Code, province.Name));
                }
            }
        }

        static void InsertOrganisation()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                var province = context.Province.Where(c => c.Code == "GP").FirstOrDefault();
                var organisation = new Organisation
                {
                    Name = "Organisation 1",
                    Description = "My Organisation 1",
                    PhysicalAddress = new Address
                    {
                        Line1 = "Unit 03 Sonwaba",
                        Line2 = "Oklahoma Avenue",
                        Suburb = "Cosmo City",
                        City = "Randburg",
                        ProvinceId = province.CountryId,
                        CountryId = province.Id
                    },
                    EmailAddress = "molefeq@gmail.com",
                    ContactNumber = "0114475206",
                    LogoFilename = "/images/logo.gif",
                    FaxNumber = "0117841256",
                    PostalAddress = new Address
                    {
                        Line1 = "Unit 03 Sonwaba",
                        Line2 = "Oklahoma Avenue",
                        Suburb = "Cosmo City",
                        City = "Randburg",
                        PostalCode = "2188",
                        ProvinceId = province.CountryId,
                        CountryId = province.Id
                    },
                };

                context.Organisation.Add(organisation);
                context.SaveChanges();
            }
        }

        static void FetchOrganisations()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                foreach (var organisation in context.Organisation.Include(o => o.PhysicalAddress).Include(o => o.PostalAddress))
                {
                    System.Console.WriteLine(string.Format("Organisation Id: {0} Description: {1} Name: {2} Physicaladdress.Id: {3} " +
                        "Physicaladdress.Line1: {4} Postaladdress.Id: {5} Postaladdress.Line1: {6}", organisation.Id, organisation.Description, organisation.Name,
                        organisation.PhysicalAddress.Id, organisation.PhysicalAddress.Line1, organisation.PostalAddress.Id,
                        organisation.PostalAddress.Line1));
                }
            }
        }

        static void UpdateOrganisation()
        {
            using (var context = new PayrollContext(IntergrationTestsSetup.ContextOptions))
            {
                var province = context.Province.Where(c => c.Code == "GP").FirstOrDefault();
                var organisation = new Organisation
                {
                    Id = 1,
                    Name = "Organisation 1",
                    Description = "My Organisation Update 1",
                    PhysicalAddress = new Address
                    {
                        Id = 1,
                        Line1 = "Unit 18 Sonwaba",
                        Line2 = "Oklahoma Avenue",
                        Suburb = "Cosmo City",
                        City = "Randburg",
                        ProvinceId = province.CountryId,
                        CountryId = province.Id
                    },
                    Guid = new System.Guid("56f420fa-c3b7-407d-a775-2efae3a379e3"),
                    EmailAddress = "molefeq@hotmail.com",
                    ContactNumber = "0114475206",
                    LogoFilename = "/images/logo.gif",
                    FaxNumber = "0117841256",
                    PostalAddress = new Address
                    {
                        Id = 2,
                        Line1 = "Unit 51 Sonwaba",
                        Line2 = "Oklahoma Avenue",
                        Suburb = "Cosmo City",
                        City = "Randburg",
                        PostalCode = "2188",
                        ProvinceId = province.CountryId,
                        CountryId = province.Id
                    },
                };

                context.Organisation.Update(organisation);
                context.SaveChanges();
            }
        }
    }
}
