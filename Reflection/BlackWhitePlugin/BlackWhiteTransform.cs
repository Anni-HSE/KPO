using PluginInterface;
using System.Drawing;

namespace BlackWhitePlugin
{
    [Version(1, 0)]
    public class BlackWhiteTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Оттенки серого";
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
            for (int i = 0; i < bitmap.Width; ++i)
                for (int j = 0; j < bitmap.Height; ++j)
                {
                    Color color = bitmap.GetPixel(i, j);
                    int avarage = (color.R + color.G + color.B) / 3;
                    bitmap.SetPixel(i, j, Color.FromArgb(avarage, avarage, avarage));
                }

        }
    }
}
