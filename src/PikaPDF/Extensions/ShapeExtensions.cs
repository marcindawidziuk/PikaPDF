using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel.Shapes;
using PikaPDF.DocumentObjectModel.Shapes.Enums;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class ShapeExtensions
    {
        public static T WithWrapFormat<T>(this T shape, WrapFormat wrapFormat) where T : Shape
        {
            shape.WrapFormat = wrapFormat;
            return shape;
        }
        
        public static T WithRelativeVertical<T>(this T shape, RelativeVertical relativeVertical) where T : Shape
        {
            shape.RelativeVertical = relativeVertical;
            return shape;
        }
    }
}