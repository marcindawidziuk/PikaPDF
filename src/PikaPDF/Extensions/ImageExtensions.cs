using System.Drawing;
using System.Drawing.Imaging;
using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel;
using Image = PikaPDF.DocumentObjectModel.Shapes.Image;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class ImageExtensions
    {
        public static Image AddImageFromMemory<T>(this T documentObject, Bitmap bitmap, ImageFormat imageFormat) where T : IHasAddImage
        {
            var base64Image = ImageHelper.ToBase64(bitmap, imageFormat);
            return documentObject.AddImage(base64Image);
        }
        
        public static Image AddImageFromMemory<T>(this T documentObject, Bitmap bitmap) where T : IHasAddImage
        {
            var base64Image = ImageHelper.ToBase64(bitmap, ImageFormat.Png);
            return documentObject.AddImage(base64Image);
        }
        
        public static Image AddImageFromMemory<T>(this T documentObject, System.Drawing.Image bitmap, ImageFormat imageFormat) where T : IHasAddImage
        {
            var base64Image = ImageHelper.ToBase64(bitmap, imageFormat);
            return documentObject.AddImage(base64Image);
        }
        
        public static Image AddImageFromMemory<T>(this T documentObject, System.Drawing.Image bitmap) where T : IHasAddImage
        {
            var base64Image = ImageHelper.ToBase64(bitmap, ImageFormat.Png);
            return documentObject.AddImage(base64Image);
        }
        
        public static T WithLockedAspectRatio<T>(this T shape) where T : Image
        {
            shape.LockAspectRatio = true;
            return shape;
        }
    }
}