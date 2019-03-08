namespace DotNetCorePayroll.Data
{
    public partial class Allowance
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public double TaxPercentage { get; set; }
    }
}
