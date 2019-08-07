using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Simple_Image_Processing.Filters
{
    public class AllFilters
    {
        // Functions of All Filters are here. The functions are returned as the Bitmap type.

        // 2.1 Implementing red filter component
        public Bitmap redFilterComponent(Bitmap originalImage)
        {
            Bitmap out_bmp = new Bitmap(originalImage.Width, originalImage.Height); // create an empty image that has same size with originalImage
            // Reading each pixels to apply filter
            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j); // getting color of pixel from the original image to apply the new color
                    Color converted = Color.FromArgb(0, originalColor.G, originalColor.B); // removing red channel from the color of pixel. 
                    out_bmp.SetPixel(i, j, converted); // applying new color on the selected pixel
                }
            }
            return out_bmp; // returning the filtered image as a Bitmap
        }

        // 2.2 Implement a greyscale filter
        public Bitmap greyscaleFilter(Bitmap originalImage)
        {
            Bitmap out_bmp = new Bitmap(originalImage.Width, originalImage.Height); // create an empty image that has same size with originalImage
            // Reading each pixels to apply filter
            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j); // getting color of pixel from the original image to apply the new color
                    float bt709_val = (originalColor.R * 0.2125f) + (originalColor.G * 0.7154f) + (originalColor.B * 0.072f); // calculating bt709 greyscale value for the selected pixel
                    int bt709 = Convert.ToInt32(bt709_val); // converting float value to int
                    Color converted = Color.FromArgb(bt709, bt709, bt709); // creating greyscale color for pixel
                    out_bmp.SetPixel(i, j, converted); // applying new color on the selected pixel
                }
            }
            return out_bmp; // returning the filtered image as a Bitmap
        }

        // 2.3 Implement a moving average filter
        public Bitmap movingAverageFilter(Bitmap originalImage)
        {
            Bitmap out_bmp = new Bitmap(originalImage.Width, originalImage.Height); // create an empty image that has same size with originalImage
            // Reading each pixels to apply filter
            for (int i = 0; i < originalImage.Width; i++)
            {
                for (int j = 0; j < originalImage.Height; j++)
                {
                    Color originalColor = originalImage.GetPixel(i, j); // getting color of pixel from the original image to apply the new color
                    if ((i >= 0 && j == 0) || (i == 0 && j >= 0) || (i == (originalImage.Width - 1) && j >= 0) || (i >= 0 && (j == originalImage.Height - 1))) // if the pixel lies at the border
                    {
                        out_bmp.SetPixel(i, j, originalColor); // its value remain same
                    }
                    else
                    {
                        // in other pixels, calculating the average value 
                        Color left = originalImage.GetPixel(i - 1, j); // getting color from the left side of the selected pixel
                        Color right = originalImage.GetPixel(i + 1, j); // getting color from the right side of the selected pixel
                        Color above = originalImage.GetPixel(i, j - 1);  // getting color from the above of the selected pixel
                        Color below = originalImage.GetPixel(i, j + 1);  // getting color from the below of the selected pixel
                        Color input = originalImage.GetPixel(i, j);  // getting color from the selected pixel
                        int average_R = (left.R + right.R + above.R + below.R + input.R) / 5; // calculating average value for Red Channel
                        int average_G = (left.G + right.G + above.G + below.G + input.G) / 5; // calculating average value for Green Channel
                        int average_B = (left.B + right.B + above.B + below.B + input.B) / 5; // calculating average value for Blue Channel
                        Color converted = Color.FromArgb(average_R, average_G, average_B); // generated average color of the selected pixel 
                        out_bmp.SetPixel(i, j, converted); // applying average color on the selected pixel
                    }
                }
            }
            return out_bmp; // returning the filtered image as a Bitmap
        }


    }
}
