using System;
using SqsLibraries.Common.Enums;

namespace DotNetCorePayroll.Data.ViewModels.Company
{
    public class CompanyAddressModel
    {
        public long CompanyId { get; set; }

        public AddressModel PhysicalAddress { get; set; } = new AddressModel();
        public AddressModel PostalAddress { get; set; } = new AddressModel();
    }
}
