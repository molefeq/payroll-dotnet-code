using DotNetCorePayroll.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePayroll.DataAccess.Tests.TestData
{
    public class OrganisationTestData
    {
        public static List<Organisation> InitialOrganisations()
        {
            return new List<Organisation>
            {
                GetTestOrganisation()
            };
        }

        public static Organisation GetTestOrganisation()
        {
            return new Organisation
            {
                Id = 1,
                Name = "Test Organisation",
                Description = "This is a test organisation.",
                EmailAddress = "molefeq@gmail.com",
                ContactNumber = "0114478965",
                PhysicalAddressId = 1,
                Guid = Guid.NewGuid(),
            };
        }
    }
}
