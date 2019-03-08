namespace DotNetCorePayroll.Data
{
    public partial class PaymentFrequency
    {
        public int Id { get; set; }
        public int Frequency { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
