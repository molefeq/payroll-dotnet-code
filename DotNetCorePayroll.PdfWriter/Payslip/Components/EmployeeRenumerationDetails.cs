////using iTextSharp.text;
//using iTextSharp.text.pdf;

//using DotNetCorePayroll.PdfWriter.Models;

//using System.Linq;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Components
//{
//    public class EmployeeRenumerationDetails
//    {
//        private static EmployeeRenumerationDetails _instance;

//        private EmployeeRenumerationDetails()
//        {
//        }

//        public static EmployeeRenumerationDetails Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new EmployeeRenumerationDetails();
//                }

//                return _instance;
//            }
//        }

//        public PdfPTable WriteIncome(PayslipModel payslipModel, Font font)
//        {
//            PdfPTable employeeDetails = new PdfPTable(new float[] { 45f, 20f, 15f, 20f });
//            float? fixedHeight = payslipModel.IncomeDetails.Count() == 0 ? 50f : payslipModel.CompanyContributionDetails.Count() * 10f - 100f;

//            if (fixedHeight < 40f)
//            {
//                fixedHeight = 40f;
//            }

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.BOTTOM_BORDER, Colspan = 4, Alignment = Rectangle.ALIGN_CENTER, FixedHeight = 30f }));            
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "INCOME", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER, Colspan = 4, Alignment = Rectangle.ALIGN_CENTER, IsBold = true }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "DESCRIPTION", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "QUANTITY", Font = font, Borders = Rectangle.BOTTOM_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "RATE", Font = font, Borders = Rectangle.BOTTOM_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "AMOUNT", Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER }));

//            foreach (var item in payslipModel.IncomeDetails)
//            {
//                employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = item.Description, Font = font, Borders = Rectangle.LEFT_BORDER, PaddingBottom = 2f, PaddingTop = 2f }));
//                employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "", Font = font, PaddingBottom = 2f, PaddingTop = 2f }));
//                employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "", Font = font, PaddingBottom = 2f, PaddingTop = 2f }));
//                employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("{0}", item.Amount.Value.ToString("# ###.00")), Alignment = Rectangle.ALIGN_RIGHT, Font = font, Borders = Rectangle.RIGHT_BORDER, PaddingBottom = 2f, PaddingTop = 2f }));
//            }
            
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER, Colspan = 4, Alignment = Rectangle.ALIGN_CENTER, FixedHeight = fixedHeight }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "GROSS EARNINGS", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER, Colspan = 3, Alignment = Rectangle.ALIGN_RIGHT, IsBold = true }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("{0}", payslipModel.TotalGrossEarnings.ToString("# ###.00")), Alignment = Rectangle.ALIGN_RIGHT, Font = font, Borders = Rectangle.RIGHT_BORDER }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, Colspan = 4, Alignment = Rectangle.ALIGN_CENTER }));

//            return employeeDetails;
//        }

//        public PdfPTable WriteBenefits(PayslipModel payslipModel, Font font)
//        {
//            PdfPTable employeeDetails = new PdfPTable(new float[] { 50f, 50f });
//            float? fixedHeight = payslipModel.CompanyContributionDetails.Count() == 0 ? 50f : payslipModel.CompanyContributionDetails.Count() * 10f - 100f;

//            if (fixedHeight < 40f)
//            {
//                fixedHeight = 40f;
//            }

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "BENEFITS", Font = font, Borders = Rectangle.BOX, Alignment = Rectangle.ALIGN_CENTER, IsBold = true }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "COMPANY CONTRIBUTIONS", Font = font, Borders = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, Alignment = Rectangle.ALIGN_CENTER, IsBold = true }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "", Font = font, Borders = Rectangle.LEFT_BORDER }));

//            PdfPTable companyContributions = new PdfPTable(new float[] { 70f, 30f });

//            foreach (var item in payslipModel.CompanyContributionDetails)
//            {
//                companyContributions.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = item.Description, Font = font, PaddingBottom = 2f, PaddingTop = 2f, Alignment = Rectangle.ALIGN_LEFT }));
//                companyContributions.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("{0}", item.Amount.Value.ToString("# ###.00")), Alignment = Rectangle.ALIGN_RIGHT, Font = font, PaddingBottom = 2f, PaddingTop = 2f }));
//            }

//            employeeDetails.AddCell(new PdfPCell(companyContributions) { Border = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER });

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER, Alignment = Rectangle.ALIGN_CENTER, FixedHeight = fixedHeight }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.RIGHT_BORDER, Alignment = Rectangle.ALIGN_CENTER, FixedHeight = fixedHeight }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, Colspan = 2, Alignment = Rectangle.ALIGN_CENTER }));

//            return employeeDetails;
//        }

//        public PdfPTable WriteDeductions(PayslipModel payslipModel, Font font)
//        {
//            PdfPTable employeeDetails = new PdfPTable(new float[] { 75f, 25f });
//            float? fixedHeight = payslipModel.DeductionDetails.Count() == 0 ? 50f : payslipModel.DeductionDetails.Count() * 10f - 100f;

//            if (fixedHeight < 40f)
//            {
//                fixedHeight = 40f;
//            }

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "DEDUCTIONS", Font = font, Borders = Rectangle.BOX, Colspan = 2, Alignment = Rectangle.ALIGN_CENTER, IsBold = true }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "DESCRIPTION", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER, Alignment = Rectangle.ALIGN_LEFT }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "AMOUNT", Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER, Alignment = Rectangle.ALIGN_CENTER }));

//            foreach (var item in payslipModel.DeductionDetails)
//            {
//                employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = item.Description, Borders = Rectangle.LEFT_BORDER, Font = font, PaddingBottom = 2f, PaddingTop = 2f, Alignment = Rectangle.ALIGN_LEFT }));
//                employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("{0}", item.Amount.Value.ToString("# ##0.00")), Borders = Rectangle.RIGHT_BORDER, Alignment = Rectangle.ALIGN_RIGHT, Font = font, PaddingBottom = 2f, PaddingTop = 2f }));
//            }

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = " ", Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER, Colspan = 2, Alignment = Rectangle.ALIGN_CENTER, FixedHeight = fixedHeight }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "TOTAL DEDUCTIONS", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER, Alignment = Rectangle.ALIGN_RIGHT, IsBold = true }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("{0}", payslipModel.TotalDeductions.ToString("# ##0.00")), Font = font, Borders = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER, Alignment = Rectangle.ALIGN_RIGHT }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "NETT PAY", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER, Alignment = Rectangle.ALIGN_RIGHT, IsBold = true }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("{0}", payslipModel.NetPayAmount.ToString("# ##0.00")), Font = font, Alignment = Rectangle.ALIGN_RIGHT, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER }));

//            return employeeDetails;
//        }
//    }
//}
