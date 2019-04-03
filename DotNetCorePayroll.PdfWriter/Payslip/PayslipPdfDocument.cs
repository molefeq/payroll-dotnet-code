using iTextSharp.text;
using iTextSharp.text.pdf;
using DotNetCorePayroll.PdfWriter.Models;
using DotNetCorePayroll.PdfWriter.Payslip.Components;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace DotNetCorePayroll.PdfWriter.Payslip
{
    public class PayslipPdfDocument
    {
        private static PayslipPdfDocument _instance;

        public static PayslipPdfDocument Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PayslipPdfDocument();
                }

                return _instance;
            }
        }
        public void WriteBatch(string directoryName, List<PayslipPdfModel> payslipModels)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            foreach (var payslipModel in payslipModels)
            {
                string fileName = Path.Combine(directoryName, $"{payslipModel.Employee.EmployeeNumber}_Payslip.pdf");
                Write(fileName, payslipModel);
            }
        }

        public void EmailBatch(string directoryName, List<PayslipPdfModel> payslipModels, DateTime emailDate)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            foreach (var payslipModel in payslipModels)
            {
                string fileDirectory = Path.Combine(directoryName, payslipModel.EmployeeId.ToString());
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                string fileName = Path.Combine(fileDirectory, payslipModel.Employee.EmployeeNumber + "_Payslip.pdf");
                string zippedFileName = Path.Combine(fileDirectory, string.Format("PasEmailDocument-{0}_{1}.zip", payslipModel.Employee.EmployeeNumber, "Payslip"));

                Write(fileName, payslipModel);
            }
        }

        public void Write(string fileName, PayslipPdfModel payslipModel)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Document pdfDocument = new Document(iTextSharp.text.PageSize.A4, 0, 0, 10f, 50f);

                try
                {
                    //pdfDocument.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
                    iTextSharp.text.pdf.PdfWriter pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDocument, fileStream);

                    //pdfWriter.PageEvent = new HeaderFooter(string.Format("Last Modified By {0} On {1}", orderModel.EditUser, orderModel.EditDate.ToShortDateString()), "");
                    pdfDocument.Open();

                    WriteDocument(payslipModel, pdfDocument);

                    pdfWriter.Flush();
                    pdfWriter.CloseStream = true;


                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    pdfDocument.Close();
                }

            }
        }

        #region Private Methods

        private void WriteDocument(PayslipPdfModel payslipModel, Document pdfDocument)
        {
            PdfPTable pdfPTable = new PdfPTable(new float[] { 100f });
            Font font = FontFactory.GetFont("Arial", 8, BaseColor.DarkGray);

            pdfDocument.Add(CompanyDetailWriter.Instance.Write(payslipModel.Company, payslipModel.Period, payslipModel.Date, font));
            pdfDocument.Add(EmployeeDetailWriter.Instance.Write(payslipModel.Employee, font));

            pdfDocument.Add(EmployeeRenumerationDetails.Instance.WriteIncome(payslipModel, font));
            pdfDocument.Add(EmployeeRenumerationDetails.Instance.WriteBenefits(payslipModel, font));
            pdfDocument.Add(EmployeeRenumerationDetails.Instance.WriteDeductions(payslipModel, font));

            pdfDocument.Add(pdfPTable);
        }

        private void SendPayslipEmail(PayslipPdfModel payslipModel, string fileName, DateTime emailDate)
        {
            using (MemoryStream zippedStream = new MemoryStream())
            {

                /*DirectoryZipper.Zip(new List<string> { fileName }, zippedStream, payslipModel.Employee.IdOrPassportNumber);
                StringBuilder emailBody = new StringBuilder();
                string smtpServerAddress = ConfigurationManager.AppSettings["SMTPAddress"];
                int smtpPortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPortNumber"]);
                string fromAddress = ConfigurationManager.AppSettings["FromAddress"];

                emailBody.AppendLine("Hi");
                emailBody.AppendLine("Please find attached payslip.Your ID number is your password.");
                emailBody.AppendLine("Regards");*/
            }
        }

        #endregion

    }
}
