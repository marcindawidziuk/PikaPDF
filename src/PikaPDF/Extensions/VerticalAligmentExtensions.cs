using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel;
using PikaPDF.DocumentObjectModel.Tables.Enums;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class VerticalAlignmentExtensions
    {
        public static T WithVerticalAlignment<T>(this T obj, VerticalAlignment verticalAlignment) where T : IHasVerticalAlignment
        {
            obj.VerticalAlignment = verticalAlignment;
            return obj;
        }
        
    }
}