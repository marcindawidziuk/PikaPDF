using System;
using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel;
using PikaPDF.DocumentObjectModel.Enums;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class ParagraphExtensions
    {
        public static T WithFormat<T>(this T paragraph, Action<ParagraphFormat> action) where T : IHasParagraphFormat
        {
            action(paragraph.Format);
            return paragraph;
        }
        
        public static T WithFontSize<T>(this T paragraph, Unit size) where T : IHasParagraphFormat
        {
            paragraph.Format.Font.Size = size;
            return paragraph;
        }
        
        public static T WithFontBold<T>(this T paragraph) where T : IHasParagraphFormat
        {
            paragraph.Format.Font.Bold = true;
            return paragraph;
        }
        
        public static T WithFontColour<T>(this T paragraph, Color color) where T : IHasParagraphFormat
        {
            paragraph.Format.Font.Color = color;
            return paragraph;
        }
        
        public static T WithParagraphAligment<T>(this T paragraph, ParagraphAlignment paragraphAlignment) where T : IHasParagraphFormat
        {
            paragraph.Format.Alignment = paragraphAlignment;
            return paragraph;
        }
    }
}