namespace DotNetCorePayroll.Data
{
    public class Province
    {
        public Province() { }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long CountryId { get; set; }
    }
}
