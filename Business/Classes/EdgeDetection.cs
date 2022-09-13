using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Testing_Project_Ferrari_Yergen
{
    /// <summary>
    /// This class contains methods for the EdgeDetection of an image
    /// </summary>
    public class EdgeDetection : IEdgeDetection
    {
        /// <summary>
        /// Variables used to filter
        /// </summary>
        double greenX;
        double greenY;
        double blueTotal;
        double greenTotal;
        double redTotal;
        readonly int filterOffset = 1;
        int calcOffset;
        int byteOffset;


        /// <summary>
        /// Return the matrix used for Laplacian3x3 algo
        /// </summary>
        public static double[,] Laplacian3x3
        {
            get
            {
                return new double[,]
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
            }
        }

        /// <summary>
        /// Return the matrix for Laplacian5x5 algo
        /// </summary>
        public static double[,] Laplacian5x5
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, 24, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1  }, };
            }
        }

        /// <summary>
        /// Return the matrix for Gaussian3x3 algo
        /// </summary>
        public static double[,] Gaussian3x3
        {
            get
            {
                return new double[,]
                { { 1, 2, 1, },
                  { 2, 4, 2, },
                  { 1, 2, 1, }, };
            }
        }

        /// <summary>
        /// Return the matrix related to the string passed in parameter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public double[,] ChooseAlgo(string filter)
        {
            double[,] filterMatrix = null;
            switch (filter)
            {
                case "Laplacian3x3":
                    filterMatrix = Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    filterMatrix = Laplacian5x5;
                    break;
                case "Gaussian3x3":
                    filterMatrix = Gaussian3x3;
                    break;
            }
            return filterMatrix;
        }

        /// <summary>
        /// Apply the chosen edge detection to the Image
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="image"></param>
        /// <param name="pictureBox"></param>
        /// <param name="labelInfo"></param>
        public Bitmap Filter(string filter, Image image)
        {

            double[,] xFilterMatrix = ChooseAlgo(filter);
            double[,] yFilterMatrix = ChooseAlgo(filter);


            Bitmap newbitmap = new(image);
            BitmapData newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

            byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
            byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

            Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
            newbitmap.UnlockBits(newbitmapData);


            for (int offsetY = filterOffset; offsetY <
                newbitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    newbitmap.Width - filterOffset; offsetX++)
                {

                    double blueX;
                    double redX;
                    double blueY;
                    double redY;
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;



                    byteOffset = offsetY *
                                 newbitmapData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * newbitmapData.Stride);

                            blueX += (double)(pixelbuff[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double)(pixelbuff[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double)(pixelbuff[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double)(pixelbuff[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double)(pixelbuff[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double)(pixelbuff[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }


                    blueTotal = 0;
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = 0;

                    if (greenTotal > 255)
                    { greenTotal = 255; }

                    resultbuff[byteOffset] = (byte)(blueTotal);
                    resultbuff[byteOffset + 1] = (byte)(greenTotal);
                    resultbuff[byteOffset + 2] = (byte)(redTotal);
                    resultbuff[byteOffset + 3] = 255;
                }
            }

            Bitmap resultbitmap = new(newbitmap.Width, newbitmap.Height);

            BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                     resultbitmap.Width, resultbitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
            resultbitmap.UnlockBits(resultData);

            return resultbitmap;
        }

    }
}

