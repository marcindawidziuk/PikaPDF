using PikaPDF.DocumentObjectModel.Shapes;

namespace PikaPDF.DocumentObjectModel
{
    public interface IHasAddImage
    {
        Image AddImage(string fileName);
    }
}