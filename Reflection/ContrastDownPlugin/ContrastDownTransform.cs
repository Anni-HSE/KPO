﻿using PluginInterface;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ContrastDownPlugin
{
    [Version(1, 0)]
    public class ContrastDownTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Понизить контрастность";
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
            int threshold = -25;

            BitmapData sourceData = bitmap.LockBits(new Rectangle(0, 0,
                               bitmap.Width, bitmap.Height),
                               ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            bitmap.UnlockBits(sourceData);

            double contrastLevel = System.Math.Pow((100.0 + threshold) / 100.0, 2);

            double blue = 0;
            double green = 0;
            double red = 0;

            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                            contrastLevel) + 0.5) * 255.0;


                if (blue > 255)
                { blue = 255; }
                else if (blue < 0)
                { blue = 0; }


                if (green > 255)
                { green = 255; }
                else if (green < 0)
                { green = 0; }


                if (red > 255)
                { red = 255; }
                else if (red < 0)
                { red = 0; }


                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;
            }


            BitmapData resultData = bitmap.LockBits(new Rectangle(0, 0,
                                bitmap.Width, bitmap.Height),
                                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            bitmap.UnlockBits(resultData);
        }
    }
}
