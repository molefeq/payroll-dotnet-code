//using iTextSharp.text;
//using iTextSharp.text.pdf;

//using DotNetCorePayroll.PdfWriter.Models;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Components
//{
//    public class AddressWriter
//    {
//        private static AddressWriter _instance;

//        public static AddressWriter Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new AddressWriter();
//                }

//                return _instance;
//            }
//        }

//        public PdfPTable WriteTable(PdfPCellModel pdfPCellModel, PdfPAddress pdfPAddress)
//        {
//            PdfPTable addressPdfPTable = new PdfPTable(1);

//            WriteToTable(pdfPCellModel, addressPdfPTable, pdfPAddress);

//            return addressPdfPTable;
//        }

//        public void WriteToTable(PdfPCellModel pdfPCellModel, PdfPTable addressPdfPTable, PdfPAddress pdfPAddress)
//        {
//            var pdfPCell = new PdfPCell();

//            pdfPCell.Border = pdfPCellModel.Borders.HasValue ? pdfPCellModel.Borders.Value : Rectangle.NO_BORDER;
//            pdfPCell.HorizontalAlignment = Rectangle.ALIGN_RIGHT;
//            pdfPCell.PaddingLeft = 5f;

//            if (!string.IsNullOrEmpty(pdfPAddress.AddressLine1))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.AddressLine1.ToUpper(), pdfPCellModel.Font));
//            }

//            if (!string.IsNullOrEmpty(pdfPAddress.AddressLine2))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.AddressLine2.ToUpper(), pdfPCellModel.Font));
//            }

//            if (!string.IsNullOrEmpty(pdfPAddress.Suburb))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.Suburb.ToUpper(), pdfPCellModel.Font));
//            }

//            if (!string.IsNullOrEmpty(pdfPAddress.City))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.City.ToUpper(), pdfPCellModel.Font));
//            }

//            if (!string.IsNullOrEmpty(pdfPAddress.PostalCode))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.PostalCode.ToUpper(), pdfPCellModel.Font));
//            }

//            if (!string.IsNullOrEmpty(pdfPAddress.Province))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.Province.ToUpper(), pdfPCellModel.Font));
//            }

//            if (!string.IsNullOrEmpty(pdfPAddress.Country))
//            {
//                pdfPCell.AddElement(ParagraphWriter.Instance.Write(pdfPAddress.Country.ToUpper(), pdfPCellModel.Font));
//            }

//            addressPdfPTable.AddCell(pdfPCell);
//        }
//    }
//}
