using iTextSharp.text;

namespace DotNetCorePayroll.PdfWriter.Models
{
    public class PdfPCellModel
    {
        public string Value { get; set; }
        public bool IsBold { get; set; }
        public Font Font { get; set; }
        public int? Borders { get; set; }
        public float? Width { get; set; }
        public int? Alignment { get; set; }
        public int? Colspan { get; set; }
        public float? PaddingBottom { get; set; }
        public float? PaddingTop { get; set; }
        public float? PaddingLeft { get; set; }
        public float? PaddingRight { get; set; }
        public float? FixedHeight { get; set; }
    }
}
