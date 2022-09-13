using System.Drawing;

namespace Testing_Project_Ferrari_Yergen
{
    public interface IEdgeDetection
    {
        double[,] ChooseAlgo(string filter);
        Bitmap Filter(string filter, Image image);
    }
}