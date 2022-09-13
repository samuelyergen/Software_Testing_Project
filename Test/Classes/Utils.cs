using System.Drawing;

namespace Test
{
    /// <summary>
    /// Class that contains utils method for the tests
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Method to compare pixels between two images
        /// </summary>
        /// <param name="bitmap">The bitmap we want to compare</param>
        /// <param name="result">The bitmap compared</param>
        /// <returns>Return true if the bitmap are the same</returns>
        public bool ComparePixels(Bitmap bitmap, Bitmap result)
        {
            if (!bitmap.Size.Equals(result.Size))
                return false;

            for (int y = 0; y < bitmap.Height - 1; y++)
            {
                for (int x = 0; x < bitmap.Width - 1; x++)
                {
                    if (!bitmap.GetPixel(x, y).Equals(result.GetPixel(x, y)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
