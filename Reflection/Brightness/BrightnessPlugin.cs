using PluginInterface;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Brightness
{
    public class BrightnessPlugin : IPlugin
    {
        public string Name
        {
            get
            {
                return "Измение яркости";
            }

        }
        public string Author
        {
            get
            {
                return "Andrew Nikitin";
            }
        }

        public void Transform(PictureBox box)
        {
            BrightnessForm form = new BrightnessForm();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var image = new Bitmap(box.Image);

                ImageAttributes imageAttributes = new ImageAttributes();
                int width = image.Width;
                int height = image.Height;
                float brightness = form.brightness;

                float[][] colorMatrixElements = {
                                                new float[] {brightness, 0, 0, 0, 0},
                                                new float[] {0, brightness, 0, 0, 0},
                                                new float[] {0, 0, brightness, 0, 0},
                                                new float[] {0, 0, 0, 1, 0},
                                                new float[] {0, 0, 0, 0, 1}
                                            };

                ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

                imageAttributes.SetColorMatrix(
                    colorMatrix,
                    ColorMatrixFlag.Default,
                    ColorAdjustType.Bitmap);
                Graphics graphics = Graphics.FromImage(image);
                graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, width,
                                   height,
                                   GraphicsUnit.Pixel,
                                   imageAttributes);

                box.Image = image;
            }
            else
            {
                
            }
        }
    }
}
