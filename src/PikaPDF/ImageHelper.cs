using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace PikaPDF
{
    internal static class ImageHelper
    {
        public static string ToBase64(Image image, ImageFormat imageFormat)
        {
            using MemoryStream m = new MemoryStream();
            image.Save(m, imageFormat);
            byte[] imageBytes = m.ToArray();

            // Convert byte[] to Base64 String
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("base64:");
            stringBuilder.Append(Convert.ToBase64String(imageBytes));
            return stringBuilder.ToString();
        }
        
        public static string ToBase64(Bitmap bitmap, ImageFormat imageFormat)
        {
            using MemoryStream m = new MemoryStream();
            bitmap.Save(m, imageFormat);
            byte[] imageBytes = m.ToArray();

            // Convert byte[] to Base64 String
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("base64:");
            stringBuilder.Append(Convert.ToBase64String(imageBytes));
            return stringBuilder.ToString();
        }
    }
}