using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Drawing;
using Test;


namespace Testing_Project_Ferrari_Yergen.Tests
{
    /// <summary>
    /// This class contains the tests for the EdgeDetection
    /// </summary>
    [TestClass()]
    public class EdgeDetectionTests
    {
        /// <summary>
        /// This method test the Laplacian3x3 method
        /// </summary>
        [TestMethod()]
        public void FilterTestLaplacian3x3()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var edge = Substitute.For<IEdgeDetection>();
            EdgeDetection edgeDetection = new();

            Bitmap baseImage = new(path + @"base.png");
            Bitmap resultImage = new(path + @"L3.png");

            var filter = "Laplacian3x3";
            edge.Filter(filter, baseImage).Returns(resultImage);

            var imageToCompare = edgeDetection.Filter(filter, baseImage);

            var result = comparator.ComparePixels(edge.Filter(filter, baseImage), imageToCompare);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// This method test the Laplacian5x5 method
        /// </summary>
        [TestMethod()]
        public void FilterTestLaplacian5x5()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var edge = Substitute.For<IEdgeDetection>();
            EdgeDetection edgeDetection = new();

            Bitmap baseImage = new(path + @"base.png");
            Bitmap resultImage = new(path + @"L5.png");

            var filter = "Laplacian5x5";

            edge.Filter(filter, baseImage).Returns(resultImage);

            var imageToCompare = edgeDetection.Filter(filter, baseImage);

            var result = comparator.ComparePixels(edge.Filter(filter, baseImage), imageToCompare);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// This method test the Gaussian3x3 method
        /// </summary>
        [TestMethod()]
        public void FilterTestGaussian3x3()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var edge = Substitute.For<IEdgeDetection>();
            EdgeDetection edgeDetection = new();

            Bitmap baseImage = new(path + @"base.png");
            Bitmap resultImage = new(path + @"Gaussian3x3.png");

            var filter = "Gaussian3x3";

            edge.Filter(filter, baseImage).Returns(resultImage);

            var imageToCompare = edgeDetection.Filter(filter, baseImage);

            var result = comparator.ComparePixels(edge.Filter(filter, baseImage), imageToCompare);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// This method test the choose algo method when we pick Laplacian3x3
        /// </summary>
        [TestMethod()]
        public void ChooseAlgoTestLaplacian3x3()
        {
            var filter = "Laplacian3x3";
            var edge = Substitute.For<IEdgeDetection>();
            EdgeDetection edgeDetection = new();

            double[,] resultMatrix = new double[,]
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };

            edge.ChooseAlgo(filter).Returns(resultMatrix);

            var algoMatrix = edgeDetection.ChooseAlgo(filter);

            CollectionAssert.AreEqual(resultMatrix, algoMatrix);
        }

        /// <summary>
        /// This method test the choose algo method when we pick Laplacian5x5
        /// </summary>
        [TestMethod()]
        public void ChooseAlgoTestLaplacian5x5()
        {
            var filter = "Laplacian5x5";
            var edge = Substitute.For<IEdgeDetection>();
            EdgeDetection edgeDetection = new();

            double[,] resultMatrix = new double[,]
                { { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, 24, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1  }, };

            edge.ChooseAlgo(filter).Returns(resultMatrix);
            var algoMatrix = edgeDetection.ChooseAlgo(filter);

            CollectionAssert.AreEqual(resultMatrix, algoMatrix);
        }

        /// <summary>
        /// This method test the choose algo method when we pick Gaussian3x3
        /// </summary>
        [TestMethod()]
        public void ChooseAlgoTestGaussian3x3()
        {
            var filter = "Gaussian3x3";
            var edge = Substitute.For<IEdgeDetection>();
            EdgeDetection edgeDetection = new();

            double[,] resultMatrix = new double[,]
                { { 1, 2, 1, },
                  { 2, 4, 2, },
                  { 1, 2, 1, }, };

            edge.ChooseAlgo(filter).Returns(resultMatrix);
            var algoMatrix = edgeDetection.ChooseAlgo(filter);

            CollectionAssert.AreEqual(resultMatrix, algoMatrix);
        }
    }
}