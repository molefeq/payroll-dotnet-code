//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using Libraries.Common.Email;
//using DotNetCorePayroll.Common.Utilities;
//using DotNetCorePayroll.PdfWriter.Models;
//using DotNetCorePayroll.PdfWriter.Payslip.Components;

//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Text;

//namespace DotNetCorePayroll.PdfWriter.Payslip
//{
//    public class PayslipPdfDocument
//    {
//        private static PayslipPdfDocument _instance;

//        public static PayslipPdfDocument Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new PayslipPdfDocument();
//                }

//                return _instance;
//            }
//        }
//        public void WriteBatch(string directoryName, List<PayslipModel> payslipModels)
//        {
//            if (!Directory.Exists(directoryName))
//            {
//                Directory.CreateDirectory(directoryName);
//            }

//            foreach (var payslipModel in payslipModels)
//            {
//                string fileName = Path.Combine(directoryName, payslipModel.Employee.EmployeeNumber + "_Payslip.pdf");
//                Write(fileName, payslipModel);
//            }
//        }

//        public void EmailBatch(string directoryName, List<PayslipModel> payslipModels, DateTime emailDate)
//        {
//            if (!Directory.Exists(directoryName))
//            {
//                Directory.CreateDirectory(directoryName);
//            }
            
//            foreach (var payslipModel in payslipModels)
//            {
//                string fileDirectory = Path.Combine(directoryName, payslipModel.EmployeeId.ToString());
//                if (!Directory.Exists(fileDirectory))
//                {
//                    Directory.CreateDirectory(fileDirectory);
//                }

//                string fileName = Path.Combine(fileDirectory, payslipModel.Employee.EmployeeNumber + "_Payslip.pdf");
//                string zippedFileName = Path.Combine(fileDirectory, string.Format("PasEmailDocument-{0}_{1}.zip", payslipModel.Employee.EmployeeNumber, "Payslip"));

//                Write(fileName, payslipModel);
//            }
//        }

//        public void Write(string fileName, PayslipModel payslipModel)
//        {
//            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                using (Document pdfDocument = new Document(iTextSharp.text.PageSize.A4, 0, 0, 10f, 50f))
//                {
//                    try
//                    {
//                        //pdfDocument.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
//                        iTextSharp.text.pdf.PdfWriter pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, fileStream);

//                        //pdfWriter.PageEvent = new HeaderFooter(string.Format("Last Modified By {0} On {1}", orderModel.EditUser, orderModel.EditDate.ToShortDateString()), "");
//                        pdfDocument.Open();

//                        WriteDocument(payslipModel, pdfDocument);

//                        pdfWriter.Flush();
//                        pdfWriter.CloseStream = true;


//                    }
//                    catch (Exception ex)
//                    {
//                        throw;
//                    }
//                    finally
//                    {
//                        pdfDocument.Close();
//                    }
//                }
//            }
//        }

//        #region Private Methods

//        private void WriteDocument(PayslipModel payslipModel, Document pdfDocument)
//        {
//            PdfPTable pdfPTable = new PdfPTable(new float[] { 100f });
//            Font font = FontFactory.GetFont("Arial", 8, BaseColor.DARK_GRAY);
//            //Font font = new Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12, Font.NORMAL);

//            //pdfPTable.AddCell(CompanyDetails.Instance.Write(payslipModel.Company, font));
//            //pdfPTable.AddCell(EmployeeDetails.Instance.Write(payslipModel.Employee, font));
//            //pdfPTable.AddCell(EmployeeRenumerationDetails.Instance.WriteIncome(payslipModel, font));
//            //pdfPTable.AddCell(EmployeeRenumerationDetails.Instance.WriteBenefits(payslipModel, font));
//            //pdfPTable.AddCell(EmployeeRenumerationDetails.Instance.WriteDeductions(payslipModel, font));

//            pdfDocument.Add(CompanyDetails.Instance.Write(payslipModel.Company, payslipModel.Period, payslipModel.Date, font));
//            pdfDocument.Add(EmployeeDetails.Instance.Write(payslipModel.Employee, font));

//            pdfDocument.Add(EmployeeRenumerationDetails.Instance.WriteIncome(payslipModel, font));
//            pdfDocument.Add(EmployeeRenumerationDetails.Instance.WriteBenefits(payslipModel, font));
//            pdfDocument.Add(EmployeeRenumerationDetails.Instance.WriteDeductions(payslipModel, font));

//            pdfDocument.Add(pdfPTable);
//        }

//        private void SendPayslipEmail(PayslipModel payslipModel, string fileName, DateTime emailDate)
//        {
//            using (MemoryStream zippedStream = new MemoryStream())
//            {

//                DirectoryZipper.Zip(new List<string> { fileName }, zippedStream, payslipModel.Employee.IdOrPassportNumber);
//                StringBuilder emailBody = new StringBuilder();
//                string smtpServerAddress = ConfigurationManager.AppSettings["SMTPAddress"];
//                int smtpPortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPortNumber"]);
//                string fromAddress = ConfigurationManager.AppSettings["FromAddress"];

//                emailBody.AppendLine("Hi");
//                emailBody.AppendLine("Please find attached payslip.Your ID number is your password.");
//                emailBody.AppendLine("Regards");
//            }
//        }

//        #endregion

//    }
//}
