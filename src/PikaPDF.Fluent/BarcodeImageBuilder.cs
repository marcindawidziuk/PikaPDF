using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using PikaPDF.Barcodes;

namespace PikaPDF.Fluent
{
    public class BarcodeImageBuilder
    {
        private readonly string _text;
        private int _barWeight = 1;
        private bool _addQuietZone;
        
        private BarcodeImageBuilder(string content)
        {
            _text = content;
        }
        
        public static BarcodeImageBuilder FromString(string content)
        {
            return new BarcodeImageBuilder(content);
        }

        public BarcodeImageBuilder WithBarWeight(int weight)
        {
            _barWeight = weight;
            return this;
        }
        
        public BarcodeImageBuilder WithQuietZone()
        {
            _addQuietZone = true;
            return this;
        }
        
        public string ToBase64()
        {
            return ToBase64(ImageFormat.Png);
        }
        
        public string ToBase64(ImageFormat imageFormat)
        {
            var image = Code128Rendering.MakeBarcodeImage(_text, _barWeight, _addQuietZone);
            using MemoryStream m = new MemoryStream();
            image.Save(m, ImageFormat.Png);
            byte[] imageBytes = m.ToArray();

            // Convert byte[] to Base64 String
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("base64:");
            stringBuilder.Append(Convert.ToBase64String(imageBytes));
            return stringBuilder.ToString();
        }

        public System.Drawing.Image ToImage()
        {
            return Code128Rendering.MakeBarcodeImage(_text, _barWeight, _addQuietZone);
        }
        
    }
}