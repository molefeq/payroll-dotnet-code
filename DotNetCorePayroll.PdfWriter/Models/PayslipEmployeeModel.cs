using System;

namespace DotNetCorePayroll.PdfWriter.Models
{
    public class PayslipEmployeeModel
    {
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Position { get; set; }
        public string IdOrPassportNumber { get; set; }
        public string DateOfEngagement { get; set; }
        public string TaxReferenceNumber { get; set; }
    }
}
