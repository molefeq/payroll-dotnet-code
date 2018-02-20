//using iTextSharp.text;

//namespace DotNetCorePayroll.PdfWriter.Payslip.Components
//{
//    public class ParagraphWriter
//    {
//        private static ParagraphWriter _instance;

//        public static ParagraphWriter Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new ParagraphWriter();
//                }

//                return _instance;
//            }
//        }

//        public Paragraph Write(string paragraphContent, Font paragraphFont)
//        {
//            return Write(paragraphContent, paragraphFont, true);
//        }

//        public Paragraph Write(string paragraphContent, Font paragraphFont, bool isLeftAligned)
//        {
//            var paragraph = new Paragraph(new Phrase(paragraphContent, paragraphFont));
//            paragraph.Alignment = isLeftAligned ? Rectangle.ALIGN_LEFT : Rectangle.ALIGN_RIGHT;

//            return paragraph;
//        }
//    }
//}
