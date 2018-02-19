using System;

namespace DotNetCorePayroll.Data
{
    public class Organisation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PhysicalAddressId { get; set; }
        public long? PostalAddressId { get; set; }
        public string FaxNumber { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LogoFilename { get; set; }
        public Guid Guid { get; set; }

        public Address PhysicalAddress { get; set; }
        public Address PostalAddress { get; set; }
    }
}
