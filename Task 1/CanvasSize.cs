using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class CanvasSize : Form
    {
        public int CanvasWidth;
        public int CanvasHeight;
        public CanvasSize()
        {
            InitializeComponent();
        }

        private void CanvasSize_Load(object sender, EventArgs e)
        {
            textBox_width.Text = CanvasWidth.ToString();
            textBox_high.Text = CanvasHeight.ToString();
        }

        private void textBox_width_TextChanged(object sender, EventArgs e)
        {
            if(textBox_width.Text.Length > 0)
                CanvasWidth = Convert.ToInt32(textBox_width.Text);
        }

        private void textBox_high_TextChanged(object sender, EventArgs e)
        {
            if (textBox_high.Text.Length > 0)
                CanvasHeight = Convert.ToInt32(textBox_high.Text);
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
