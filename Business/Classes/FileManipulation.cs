using System.Drawing;
using System.IO;

namespace Testing_Project_Ferrari_Yergen
{
    /// <summary>
    /// This class contains methods used for file manipulation (load and save file)
    /// </summary>
    public class FileManipulation : IFileManipulation
    {
        /// <summary>
        /// Open a file explorer, let the user choose a file, load the file
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        public Bitmap LoadImage(string path)
        {
            try
            {
                StreamReader streamReader = new(path);
                Bitmap image = new(streamReader.BaseStream);
                streamReader.Close();

                return image;

            }
            catch (FileNotFoundException)
            {

                throw new FileNotFoundException();

            }

        }

        /// <summary>
        /// Open a file explorer and let the user choose a path and a name to save the image
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="save_textbox"></param>
        public void SaveImage(Image image, string name, string path)
        {
            image.Save(path + @"\" + name + @".png", System.Drawing.Imaging.ImageFormat.Png);

        }
    }
}
