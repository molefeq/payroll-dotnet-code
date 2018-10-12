using DotNetCorePayroll.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.DataAccess.Tests.TestData
{
    public class AddressTestData
    {
        public static List<Address> InitialAddresses()
        {
            return new List<Address>
            {
                GetTestAddress()
            };
        }

        public static Address GetTestAddress()
        {
            return new Address
            {
                Id = 1,
                Line1 = "Unit 03 Sownaba",
                Line2 = "Oklahoma Avenue",
                Suburb = "Cosmo City",
                City = "Randburg",
                CountryId = 1,
                ProvinceId = 1,
                PostalCode = "2001",
                Location = "13.45,25.96"
            };
        }
    }
}
