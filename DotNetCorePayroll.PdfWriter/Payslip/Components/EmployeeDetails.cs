//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using DotNetCorePayroll.PdfWriter.Models;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Components
//{
//    public class EmployeeDetails
//    {
//        private static EmployeeDetails _instance;

//        public static EmployeeDetails Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new EmployeeDetails();
//                }

//                return _instance;
//            }
//        }

//        public PdfPTable Write(PayslipEmployeeModel payslipEmployeeModel, Font font)
//        {
//            PdfPTable employeeDetails = new PdfPTable(new float[] { 18f, 25f, 17f, 40f });
            
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "EMPLOYEE CODE", Font = font, Borders = Rectangle.BOX}));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = payslipEmployeeModel.EmployeeNumber.ToUpper(), Font = font, Borders = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "EMPLOYEE NAME", Font = font, Borders = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = payslipEmployeeModel.Name.ToUpper(), Font = font, Borders = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "POSITION", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = payslipEmployeeModel.Position.ToUpper(), Font = font, Borders = Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "ID NUMBER", Font = font, Borders = Rectangle.TOP_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = payslipEmployeeModel.IdOrPassportNumber.ToUpper(), Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER }));

//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "START DATE", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER | Rectangle.RIGHT_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = payslipEmployeeModel.DateOfEngagement.ToUpper(), Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "TAX NUMBER", Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER }));
//            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = payslipEmployeeModel.TaxReferenceNumber.ToUpper(), Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER }));

//            return employeeDetails;
//        }
//    }
//}
