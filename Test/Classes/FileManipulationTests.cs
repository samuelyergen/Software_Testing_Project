using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Drawing;
using System.IO;
using Test;

namespace Testing_Project_Ferrari_Yergen.Tests
{
    /// <summary>
    /// This class contains the tests for the FileManipulation (load/test)
    /// </summary>
    [TestClass()]
    public class FileManipulationTests
    {
        /// <summary>
        /// This method test the loading of an image
        /// </summary>
        [TestMethod()]
        public void LoadImageTest()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\base.png";
            var fileManip = Substitute.For<IFileManipulation>();
            var fm = new FileManipulation();
            Bitmap image = new(path);


            fileManip.LoadImage(path).Returns(image);

            var testLoad = fm.LoadImage(path);

            Assert.IsTrue(comparator.ComparePixels(fileManip.LoadImage(path), testLoad));

        }

        /// <summary>
        /// This method test the error when we are loading an image
        /// </summary>
        [TestMethod()]
        public void LoadImageErrorTest()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\baseNotFound.png";
            var fileManip = Substitute.For<IFileManipulation>();
            var fm = new FileManipulation();

            fileManip.LoadImage(path).Returns(e => { throw new FileNotFoundException(); });

            Assert.ThrowsException<FileNotFoundException>(() => fileManip.LoadImage(path));

            Assert.ThrowsException<FileNotFoundException>(() => fm.LoadImage(path));

        }

        /// <summary>
        /// This method test the saving of an image
        /// </summary>
        [TestMethod()]
        public void SaveImageTest()
        {
            var comparator = new Utils();
            var path = @"..\..\..\Ressources\";
            var pathImage = @"..\..\..\Ressources\base.png";
            var pathSavedImage = @"..\..\..\Ressources\saveImage.png";
            FileManipulation fileManip = new();

            Image image = Image.FromFile(pathImage);
            Image imageSaved = null;

            fileManip.SaveImage(image, "saveImage", path);

            try
            {
                imageSaved = Image.FromFile(pathSavedImage);
            }
            catch (FileNotFoundException)
            {
                Assert.Fail("save failed");
            }

            Bitmap bitmapImage = new(image);
            Bitmap bitmapImageSaved = new(imageSaved);

            var result = comparator.ComparePixels(bitmapImage, bitmapImageSaved);

            Assert.IsTrue(result);

        }

        /// <summary>
        /// This method test the saving of an image with NSubstitute
        /// </summary>
        [TestMethod()]
        public void SaveImageCallTest()
        {
            var path = @"..\..\..\Ressources\";
            var pathImage = @"..\..\..\Ressources\base.png";
            var fileManip = Substitute.For<IFileManipulation>();


            Image image = Image.FromFile(pathImage);


            fileManip.SaveImage(image, "saveImageCount", path);

            fileManip.Received(1).SaveImage(image, "saveImageCount", path);

            fileManip.SaveImage(image, "saveImageCount", path);

            fileManip.Received(2).SaveImage(image, "saveImageCount", path);

        }
    }
}