using System.Drawing;

namespace Testing_Project_Ferrari_Yergen
{
    public interface IImageFilters
    {
        Bitmap ApplyFilter(Bitmap bmp, int alpha, int red, int blue, int green);
        Bitmap ApplyFilterSwap(Bitmap bmp);
        Bitmap BlackWhite(Bitmap bmp);
    }
}