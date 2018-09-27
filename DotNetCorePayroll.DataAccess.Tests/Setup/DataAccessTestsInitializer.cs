using DotNetCorePayroll.DataAccess.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetCorePayroll.DataAccess.Tests.Setup
{
    /// <summary>
    /// Assembly Initialize and cleanup methods
    /// </summary>
    [TestClass]
    public class DataAccessTestsInitializer
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            IntergrationTestsSetup dbSetup = new IntergrationTestsSetup();

            using (var context = new PayrollContext(dbSetup.ContextOptions))
            {
                context.Country.AddRange(CountryTestData.InitialCountries());
                context.Province.AddRange(ProvinceTestData.InitialProvinces());
                context.Role.AddRange(RoleTestData.InitialRoles());

                context.SaveChanges();
            }

            //using (var context = new PayrollContext(dbSetup.ContextOptions))
            //{
            //    context.Database.ExecuteSqlCommand("INSERT INTO role(code, name)VALUES('ADMIN', 'Admin');");
            //}
        }

        
        [AssemblyCleanup]
        public static void CleanUp()
        {
            // TODO: Clean resources used by your tests.
        }


    }
}
