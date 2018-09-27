using DotNetCorePayroll.Data;
using System.Collections.Generic;

namespace DotNetCorePayroll.DataAccess.Tests.TestData
{
    public class CountryTestData
    {
        public static List<Country> InitialCountries()
        {
            return new List<Country>
            {
                new Country{ Id = 1, Code = "ZAR", Name = "South Africa" }
            };
        }
    }
}
