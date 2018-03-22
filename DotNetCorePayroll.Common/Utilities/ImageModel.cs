using System.IO;

namespace DotNetCorePayroll.Common.Utilities
{
    public class ImageModel
    {
        public Stream File { get; set; }
        public string OriginalFileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string PhysicalDirectory { get; set; }
        public string RelativeDirectory { get; set; }
        public string RelativeFileName { get; set; }
        public string PhysicalFileName { get; set; }
    }
}