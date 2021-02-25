using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextPlugin
{
    public class TextTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Добавить текующую дату";
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
            Image img = bitmap;
            string date = DateTime.Now.ToString();
            Graphics g = Graphics.FromImage(img);
            g.DrawString(date, new Font("Arial", 14), Brushes.Black, new Point(bitmap.Width - 50, bitmap.Height - 50));
        }
    }
}
