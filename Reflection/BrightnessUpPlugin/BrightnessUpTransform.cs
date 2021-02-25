using PluginInterface;
using System.Drawing;

namespace BrightnessDownPlugin
{
    [Version(1, 0)]
    public class BrightnessUpTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Повысить яркость";
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
            float factor = 1.5f;
            for (int x = 0; x < bitmap.Width; ++x)
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    Color curr = bitmap.GetPixel(x, y);
                    Color next = Color.FromArgb((byte)(factor * curr.R), (byte)(factor * curr.G), (byte)(factor * curr.B));
                    bitmap.SetPixel(x, y, next);
                }

        }
    }
}
