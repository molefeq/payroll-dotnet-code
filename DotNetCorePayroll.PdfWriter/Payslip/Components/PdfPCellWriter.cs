using iTextSharp.text;
using iTextSharp.text.pdf;
using DotNetCorePayroll.PdfWriter.Models;

namespace DotNetCorePayroll.PdfWriter.Payslip.Components
{
    public class PdfPCellWriter
    {
        private static PdfPCellWriter _instance;

        private PdfPCellWriter()
        {
        }

        public static PdfPCellWriter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PdfPCellWriter();
                }

                return _instance;
            }
        }

        public PdfPCell WriteHeader(PdfPCellModel pdfPCellModel)
        {
            Font cellFont = FontFactory.GetFont("Arial Bold", 11, BaseColor.DARK_GRAY);
            //Font cellFont = new Font(BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 15, Font.NORMAL);
            var pdfPCell = new PdfPCell(new Phrase(pdfPCellModel.Value, cellFont));

            pdfPCell.Border = pdfPCellModel.Borders.HasValue ? pdfPCellModel.Borders.Value : Rectangle.NO_BORDER;
            pdfPCell.HorizontalAlignment = pdfPCellModel.Alignment.HasValue ? pdfPCellModel.Alignment.Value : Rectangle.ALIGN_LEFT;

            if (pdfPCellModel.Colspan.HasValue)
            {
                pdfPCell.Colspan = pdfPCellModel.Colspan.Value;
            }

            pdfPCell.PaddingBottom = 10f;
            pdfPCell.PaddingTop = 10f;

            return pdfPCell;
        }

        public PdfPCell Write(PdfPCellModel pdfPCellModel)
        {
            Font cellFont = FontFactory.GetFont(pdfPCellModel.Font.Familyname, pdfPCellModel.Font.Size, pdfPCellModel.IsBold ? Font.BOLD : Font.NORMAL, pdfPCellModel.Font.Color);
            var pdfPCell = new PdfPCell(new Phrase(pdfPCellModel.Value, cellFont));

            pdfPCell.Border = pdfPCellModel.Borders.HasValue ? pdfPCellModel.Borders.Value : Rectangle.NO_BORDER;
            pdfPCell.HorizontalAlignment = pdfPCellModel.Alignment.HasValue ? pdfPCellModel.Alignment.Value : Rectangle.ALIGN_LEFT;

            if (pdfPCellModel.Colspan.HasValue)
            {
                pdfPCell.Colspan = pdfPCellModel.Colspan.Value;
            }

            pdfPCell.PaddingBottom = pdfPCellModel.PaddingBottom.HasValue ? pdfPCellModel.PaddingBottom.Value : 5f;
            pdfPCell.PaddingTop = pdfPCellModel.PaddingTop.HasValue ? pdfPCellModel.PaddingTop.Value : 5f;
            pdfPCell.PaddingLeft = 5f;
            pdfPCell.PaddingRight = 5f;

            if (pdfPCellModel.FixedHeight.HasValue)
            {
                pdfPCell.FixedHeight = pdfPCellModel.FixedHeight.Value;
            }

            return pdfPCell;
        }
    }
}
