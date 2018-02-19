
namespace DotNetCorePayroll.PdfWriter.Models
{
    public class PayslipCompanyModel
    {
        public PdfPAddress Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
    }
}
