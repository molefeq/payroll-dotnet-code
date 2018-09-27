using DotNetCorePayroll.Data;
using System.Collections.Generic;

namespace DotNetCorePayroll.DataAccess.Tests.TestData
{
    class ProvinceTestData
    {
        public static List<Province> InitialProvinces()
        {
            return new List<Province>
            {
                new Province{ Id = 1, CountryId=1, Code = "KZN", Name = "KwaZulu Natal" }
            };
        }
    }
}
