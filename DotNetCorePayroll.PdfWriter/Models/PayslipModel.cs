using System;
using System.Collections.Generic;

namespace DotNetCorePayroll.PdfWriter.Models
{
    public class PayslipModel
    {
        public int EmployeeId { get; set; }
        public string Period { get; set; }
        public string Date { get; set; }
        public decimal TotalGrossEarnings { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetPayAmount { get; set; }

        public PayslipCompanyModel Company { get; set; }
        public PayslipEmployeeModel Employee { get; set; }
        public List<IncomeDetailModel> IncomeDetails { get; set; }
        public List<CompanyContributionDetailModel> CompanyContributionDetails { get; set; }
        public List<DeductionDetailModel> DeductionDetails { get; set; }

        public PayslipModel()
        {
            IncomeDetails = new List<IncomeDetailModel>();
            CompanyContributionDetails = new List<CompanyContributionDetailModel>();
            DeductionDetails = new List<DeductionDetailModel>();
        }
    }
}
