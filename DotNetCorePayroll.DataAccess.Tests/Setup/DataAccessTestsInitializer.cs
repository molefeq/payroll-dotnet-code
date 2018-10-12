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
                context.Address.AddRange(AddressTestData.InitialAddresses());
                context.Organisation.AddRange(OrganisationTestData.InitialOrganisations());
                context.Account.AddRange(AccountTestData.InitialAccounts());

                context.SaveChanges();
            }
        }

        
        [AssemblyCleanup]
        public static void CleanUp()
        {
            // TODO: Clean resources used by your tests.
        }


    }
}
