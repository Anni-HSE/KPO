using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brightness
{
    public partial class BrightnessForm : Form
    {
        public float brightness;
        public BrightnessForm()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            brightness = trackBar1.Value / trackBar1.Maximum;         
        }
    }
}
