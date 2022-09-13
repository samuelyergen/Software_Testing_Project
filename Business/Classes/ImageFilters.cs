using System.Drawing;

namespace Testing_Project_Ferrari_Yergen
{
    /// <summary>
    /// This class contains methods for the filter of an image
    /// </summary>
    public class ImageFilters : IImageFilters
    {

        /// <summary>
        /// Transform a Bitmap in black and white
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public Bitmap BlackWhite(Bitmap bmp)
        {


            int rgb;
            Color c;

            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return bmp;

        }

        /// <summary>
        /// Transform a Bitmap with swap filter
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public Bitmap ApplyFilterSwap(Bitmap bmp)
        {

            Bitmap temp = new(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        /// <summary>
        /// Transform a Bitmap 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="alpha"></param>
        /// <param name="red"></param>
        /// <param name="blue"></param>
        /// <param name="green"></param>
        /// <returns></returns>
        public Bitmap ApplyFilter(Bitmap bmp, int alpha, int red, int blue, int green)
        {

            Bitmap temp = new(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.G / green, c.B / blue);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }
    }
}
