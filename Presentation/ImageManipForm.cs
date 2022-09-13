using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Testing_Project_Ferrari_Yergen;

namespace Presentation
{
    /// <summary>
    /// This class contains methods that are used for the application
    /// </summary>
    public partial class ImageManipForm : Form
    {

        private Image origin;
        private Image filteredImage;
        private readonly IFileManipulation fileManip;
        private readonly IImageFilters imageFilter;
        private readonly IEdgeDetection edgeDetection;

        /// <summary>
        /// Initialize the form
        /// </summary>
        public ImageManipForm()
        {
            InitializeComponent();
            fileManip = new FileManipulation();
            imageFilter = new ImageFilters();
            edgeDetection = new EdgeDetection();
            origin = null;
            DisplayMessage("load");
        }

        /// <summary>
        /// Open a file explorer and load the chosen file
        /// Display an error message is the selected file is in a wrong format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new();
            DialogResult dr = op.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string path = op.FileName;

                // catch if the file isn't in the right format
                // catch if the file doesn't exist
                try
                {
                    origin = fileManip.LoadImage(path);
                    Bitmap temp = new(origin,
                    new Size(image_pictureBox.Width, image_pictureBox.Height));

                    image_pictureBox.Image = temp;
                    origin = image_pictureBox.Image;
                    filteredImage = origin;

                    DisplayMessage("filter");
                }
                catch (ArgumentException)
                {
                    DisplayMessage("formatError");
                }
                catch (FileNotFoundException)
                {
                    DisplayMessage("nullFile");
                }
            }
        }

        /// <summary>
        /// Open a file explorer, the user can choose the path and the filename
        /// Then save the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_button_Click(object sender, EventArgs e)
        {
            // test if an image is loaded
            if (image_pictureBox.Image != null)
            {
                // test if the user wrote a name for the file
                if (save_textbox.Text == "")
                {
                    DisplayMessage("textError");
                    return;
                }

                FolderBrowserDialog fl = new();

                // test if the user cancelled the saving
                if (fl.ShowDialog() != DialogResult.Cancel)
                {
                    fileManip.SaveImage(image_pictureBox.Image, save_textbox.Text, fl.SelectedPath);
                    DisplayMessage("load");
                }

            }
            else
                DisplayMessage("nullError");
        }

        /// <summary>
        /// Apply black and white filter on the original image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BwFilter_button_Click(object sender, EventArgs e)
        {
            // test if the image is null
            if (origin != null)
            {
                image_pictureBox.Image = imageFilter.BlackWhite(new Bitmap(origin));
                filteredImage = image_pictureBox.Image;
                DisplayMessage("edge");
            }
            else
            {
                DisplayMessage("nullError");
            }



        }

        /// <summary>
        /// Apply swap filter on the original image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Swap_filter_button_Click(object sender, EventArgs e)
        {
            if (origin != null)
            {
                image_pictureBox.Image = imageFilter.ApplyFilterSwap(new Bitmap(origin));
                filteredImage = image_pictureBox.Image;
                DisplayMessage("edge");
            }
            else
            {
                DisplayMessage("nullError");
            }


        }

        /// <summary>
        /// Apply hell filter on the original image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hell_filter_button_Click(object sender, EventArgs e)
        {
            if (origin != null)
            {
                image_pictureBox.Image = imageFilter.ApplyFilter(new Bitmap(origin), 1, 1, 10, 15);
                filteredImage = image_pictureBox.Image;
                DisplayMessage("edge");
            }
            else
            {
                DisplayMessage("nullError");
            }
        }

        /// <summary>
        /// Reset the image to its initial state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_button_Click(object sender, EventArgs e)
        {
            if (origin != null)
            {
                image_pictureBox.Image = origin;
                DisplayMessage("filter");
            }
            else
                DisplayMessage("nullError");
        }

        /// <summary>
        /// Apply the edge detection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Apply_edge_button_Click(object sender, EventArgs e)
        {
            // test if the filtered image isn't null
            if (filteredImage != null)
            {
                // test if an edge detection item is chosen
                if (algo_listbox.SelectedItem != null)
                {
                    image_pictureBox.Image = edgeDetection.Filter(algo_listbox.SelectedItem.ToString(), filteredImage);
                    DisplayMessage("save");
                }
                else
                {
                    DisplayMessage("edgeError");
                }
            }
            else
            {
                DisplayMessage("nullError");
            }

        }

        /// <summary>
        /// Display messages to guide the user through the program
        /// </summary>
        /// <param name="step"></param>
        public void DisplayMessage(string step)
        {
            switch (step)
            {
                case "filter":
                    labelInfo.Text = "Apply a filter or edge detection directly";
                    break;
                case "formatError":
                    labelInfo.Text = "The selected file is not an image";
                    break;
                case "nullError":
                    labelInfo.Text = "You must load an image";
                    break;
                case "textError":
                    labelInfo.Text = "Write the name of your file before saving";
                    break;
                case "load":
                    labelInfo.Text = "Load an image";
                    break;
                case "edge":
                    labelInfo.Text = "Choose your edge detection and apply it";
                    break;
                case "edgeError":
                    labelInfo.Text = "Choose your edge detection before";
                    break;
                case "save":
                    labelInfo.Text = "You can reset or save your image";
                    break;
                case "nullFile":
                    labelInfo.Text = "The file doesn't exist";
                    break;
            }
        }
    }
}
