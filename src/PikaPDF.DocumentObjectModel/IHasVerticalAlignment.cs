using PikaPDF.DocumentObjectModel.Tables.Enums;

namespace PikaPDF.DocumentObjectModel
{
    public interface IHasVerticalAlignment
    {
        VerticalAlignment VerticalAlignment { get; set; }
    }
}