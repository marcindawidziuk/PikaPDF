using System.Drawing.Imaging;
using JetBrains.Annotations;

namespace PikaPDF.Barcodes
{
    [PublicAPI]
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
            return ImageHelper.ToBase64(ToImage(), imageFormat);
        }

        public System.Drawing.Image ToImage()
        {
            return Code128Rendering.MakeBarcodeImage(_text, _barWeight, _addQuietZone);
        }
        
    }
}