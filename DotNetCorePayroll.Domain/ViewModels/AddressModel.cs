namespace DotNetCorePayroll.Data.ViewModels
{
    public class AddressModel
    {
        public AddressModel() { }

        public long? Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public long? ProvinceId { get; set; }
        public long? CountryId { get; set; }
        public string PostalCode { get; set; }
        public string Location { get; set; }
    }
}
