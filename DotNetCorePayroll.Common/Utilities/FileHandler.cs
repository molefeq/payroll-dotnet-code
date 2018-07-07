using System;
using System.IO;

namespace DotNetCorePayroll.Common.Utilities
{
    public class FileHandler
    {
        public static string SaveImage(ImageModel imageModel)
        {
            if (imageModel == null)
            {
                return null;
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageModel.OriginalFileName);

            imageModel.PhysicalFileName = GetPhysicalFileName(imageModel.PhysicalDirectory, fileName);
            imageModel.RelativeFileName = GetRelativeFileName(imageModel.RelativeDirectory, fileName);

            if (imageModel.File.Length > 0)
            {
                using (var stream = new FileStream(imageModel.PhysicalFileName, FileMode.Create))
                {
                    imageModel.File.CopyTo(stream);
                }
            }

            ResizeImage(imageModel);

            return fileName;
        }

        public static void ResizeImage(ImageModel imageModel)
        {
            ImageResizer imageResizer = new ImageResizer(imageModel.PhysicalFileName, imageModel.PhysicalFileName, imageModel.Width, imageModel.Height);
            imageResizer.ResizeImage();
        }

        public static void ResizeImage(string imageFileName, string fileName, ImageModel imageModel)
        {
            imageModel.PhysicalFileName = GetPhysicalFileName(imageModel.PhysicalDirectory, fileName);
            ImageResizer imageResizer = new ImageResizer(imageFileName, imageModel.PhysicalFileName, imageModel.Width, imageModel.Height);
            imageResizer.ResizeImage();
        }

        public static string GetPhysicalFileName(string directory, string fileName, string fileSuffix = "")
        {
            if (string.IsNullOrEmpty(fileSuffix))
            {
                return Path.Combine(directory, fileName);
            }

            return Path.Combine(directory, Path.GetFileNameWithoutExtension(fileName) + "_" + fileSuffix + Path.GetExtension(fileName));
        }

        public static string GetRelativeFileName(string virtualDirectory, string fileName, string fileSuffix = "")
        {
            if (string.IsNullOrEmpty(fileSuffix))
            {
                return Path.Combine(virtualDirectory, fileName);
            }

            return Path.Combine(virtualDirectory, Path.GetFileNameWithoutExtension(fileName) + "_" + fileSuffix + Path.GetExtension(fileName));
        }
    }
}
