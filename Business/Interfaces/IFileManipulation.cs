using System.Drawing;

namespace Testing_Project_Ferrari_Yergen
{
    public interface IFileManipulation
    {
        Bitmap LoadImage(string path);
        void SaveImage(Image image, string name, string path);
    }
}