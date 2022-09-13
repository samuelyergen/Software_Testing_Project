using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Drawing;
using Test;

namespace Testing_Project_Ferrari_Yergen.Tests
{
    [TestClass()]
    public class ImageFiltersTests
    {
        [TestMethod()]
        public void BlackWhiteTest()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var filter = Substitute.For<IImageFilters>();
            ImageFilters imageFilters = new();

            Bitmap baseImage = new(path + @"base.png");
            Bitmap resultImage = new(path + @"BWImage.png");

            filter.BlackWhite(baseImage).Returns(resultImage);

            var imageToCompare = imageFilters.BlackWhite(baseImage);

            var result = comparator.ComparePixels(filter.BlackWhite(baseImage), imageToCompare);

            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void ApplyFilterSwapTest()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var filter = Substitute.For<IImageFilters>();
            ImageFilters imageFilters = new();

            Bitmap baseImage = new(path + @"base.png");
            Bitmap resultImage = new(path + @"SwapImage.png");

            filter.ApplyFilterSwap(baseImage).Returns(resultImage);

            var imageToCompare = imageFilters.ApplyFilterSwap(baseImage);

            var result = comparator.ComparePixels(filter.ApplyFilterSwap(baseImage), imageToCompare);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ApplyFilterTest()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var filter = Substitute.For<IImageFilters>();
            ImageFilters imageFilters = new();

            Bitmap baseImage = new(path + @"base.png");
            Bitmap resultImage = new(path + @"HellImage.png");

            filter.ApplyFilter(baseImage, 1, 1, 10, 15).Returns(resultImage);

            var imageToCompare = imageFilters.ApplyFilter(baseImage, 1, 1, 10, 15);

            var result = comparator.ComparePixels(filter.ApplyFilter(baseImage, 1, 1, 10, 15), imageToCompare);

            Assert.IsTrue(result);
        }
    }
}