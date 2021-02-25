using PluginInterface;
using System;
using System.Drawing;

namespace BlurPlugin
{
    public class BlurTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Размытие";
            }

        }
        public string Author
        {
            get
            {
                return "Andrew Nikitin";
            }
        }

        public void Transform(Bitmap bitmap)
        {

            Int32 avgR = 0, avgG = 0, avgB = 0;
            Int32 blurPixelCount = 0;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    avgR += pixel.R;
                    avgG += pixel.G;
                    avgB += pixel.B;

                    blurPixelCount++;
                }
            }

            avgR = avgR / blurPixelCount;
            avgG = avgG / blurPixelCount;
            avgB = avgB / blurPixelCount;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }
        }
    }
}
