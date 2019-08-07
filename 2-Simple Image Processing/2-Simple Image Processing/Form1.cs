using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; // 2.4 importing System.Threading library for using ThreadPool Class
using _2_Simple_Image_Processing.Filters; // importing Filters folder to use AllFilters class


namespace _2_Simple_Image_Processing
{
    public partial class Form1 : Form
    {

        // 2.1 Open the project

        // 2.1 Red Filter , 2.2 Greyscale Filter and 2.3 Moving average filter is on the AllFilters class

        Bitmap image; // image is a variable that is used to apply a filter on it.
        AllFilters allFilters; // this class is consists of filters
        public Form1()
        {
            InitializeComponent();
            PopulateListBox(); // adding filter names to filterBox on start
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            image = new Bitmap(originalImage.Image); // create an image same size with the original image
            allFilters = new AllFilters();  // creating a new class to use for applying filters
        }

        // 2.4 Paralellize the filters
        private void convertButton_Click(object sender, EventArgs e)
        {
            // Applying filters when the convertButton is clicked.
            if (filterBox.SelectedIndex == 0)
            {
                // if Filter red component is selected
                ThreadPool.QueueUserWorkItem(new WaitCallback(redFilter)); // using thread pooling for redFilter
            }
            else if (filterBox.SelectedIndex == 1)
            {
                // if Grayscale filter is selected
                ThreadPool.QueueUserWorkItem(new WaitCallback(greyscaleFilter)); // using thread pooling for grescaleFilter
            }
            else if (filterBox.SelectedIndex == 2)
            {
                // if Moving average filter is selected
                ThreadPool.QueueUserWorkItem(new WaitCallback(movingAverageFilter)); // using thread pooling for movingAverageFilter
            }
        }



        // 2.4 voids for applying Filters with ThreadPool
        private void redFilter(object callback)
        {
            // void for redFilter
            filteredImage.Image = allFilters.redFilterComponent(image); // it applies red filter to the original image and shows the filtered image in filteredImage(PictureBox).
        }

        private void greyscaleFilter(object callback)
        {
            // void for greyscaleFilter
            filteredImage.Image = allFilters.greyscaleFilter(image); // it applies greyscale filter to the original image and shows the filtered image in filteredImage(PictureBox).
        }

        private void movingAverageFilter(object callback)
        {
            // void for movingAverageFilter
            filteredImage.Image = allFilters.movingAverageFilter(image); // it applies moving average filter to the original image and shows the filtered image in filteredImage(PictureBox).
        }

        // 2.5 Extracting the filters is on AllFilter.cs

        // 2.6 PopulateListBox method to fill combobox
        private void PopulateListBox()
        {
            filterBox.Items.Add("Filter red component"); // adding filter names to filterBox
            filterBox.Items.Add("Grayscale filter"); // adding filter names to filterBox
            filterBox.Items.Add("Moving average filter"); // adding filter names to filterBox
            filterBox.SelectedIndex = 0; // set selected index 0
        }

       

    }
}
