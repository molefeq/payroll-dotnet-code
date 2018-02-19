using iTextSharp.text;
using iTextSharp.text.pdf;
using DotNetCorePayroll.PdfWriter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCorePayroll.PdfWriter.Payslip.Components
{
    public class CompanyDetails
    {
        private static CompanyDetails _instance;

        private CompanyDetails()
        {
        }

        public static CompanyDetails Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompanyDetails();
                }

                return _instance;
            }
        }

        public PdfPTable Write(PayslipCompanyModel payslipCompanyModel, string period, string date, Font font)
        {
            PdfPTable employeeDetails = new PdfPTable(new float[] { 60f, 20f, 20f });
            employeeDetails.AddCell(PdfPCellWriter.Instance.WriteHeader(new PdfPCellModel { Value = payslipCompanyModel.Name.ToUpper(), Colspan = 3, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, Alignment = Rectangle.ALIGN_CENTER }));

            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("REGISTRATION NO: {0}", payslipCompanyModel.RegistrationNumber.ToUpper()), Font = font, Borders = Rectangle.BOX, Alignment = Rectangle.ALIGN_CENTER, PaddingBottom = 5f, PaddingTop = 5f, Colspan = 3 }));

            AddressWriter.Instance.WriteToTable(new PdfPCellModel { Font = font, Borders = Rectangle.LEFT_BORDER }, employeeDetails, payslipCompanyModel.Address);
            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER, Colspan = 2 }));

            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("OFFICE TEL: {0}", payslipCompanyModel.TelephoneNumber.ToUpper()), Font = font, Borders = Rectangle.LEFT_BORDER, PaddingBottom = 2f }));
            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "PERIOD", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, PaddingBottom = 2f }));
            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = period, Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, PaddingBottom = 2f }));

            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = string.Format("EMAIL: {0}", payslipCompanyModel.EmailAddress.ToUpper()), Font = font, Borders = Rectangle.LEFT_BORDER, PaddingTop = 2f }));
            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = "DATE", Font = font, Borders = Rectangle.LEFT_BORDER | Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, PaddingBottom = 2f }));
            employeeDetails.AddCell(PdfPCellWriter.Instance.Write(new PdfPCellModel { Value = date, Font = font, Borders = Rectangle.RIGHT_BORDER | Rectangle.TOP_BORDER, PaddingBottom = 2f }));

            return employeeDetails;
        }

    }
}
