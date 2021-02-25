using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabControls
{
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        private void сolorTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (decRadioButton.Checked)
                {
                    pictureBox.BackColor = Color.FromArgb(
                        int.Parse(redColorTextBox.Text),
                        int.Parse(greenColorTextBox.Text),
                        int.Parse(blueColorTextBox.Text)
                    );
                }
                else
                {
                    pictureBox.BackColor = Color.FromArgb(
                        Convert.ToInt32(redColorTextBox.Text, 16),
                        Convert.ToInt32(greenColorTextBox.Text, 16),
                        Convert.ToInt32(blueColorTextBox.Text, 16)
                    );
                }
            }
            catch (Exception) { }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            decRadioButton.Enabled = !decRadioButton.Checked;
            hexRadioButton.Enabled = !hexRadioButton.Checked;
            redColorTextBox.IsDecimal = decRadioButton.Checked;
            greenColorTextBox.IsDecimal = decRadioButton.Checked;
            blueColorTextBox.IsDecimal = decRadioButton.Checked;

            if (decRadioButton.Checked)
            {
                redColorTextBox.Text = redColorTextBox.Text != "" ? Convert.ToInt32(redColorTextBox.Text, 16).ToString() : "";
                greenColorTextBox.Text = greenColorTextBox.Text != "" ? Convert.ToInt32(greenColorTextBox.Text, 16).ToString() : "";
                blueColorTextBox.Text = blueColorTextBox.Text != "" ? Convert.ToInt32(blueColorTextBox.Text, 16).ToString() : "";
            }
            else
            {
                redColorTextBox.Text = redColorTextBox.Text != "" ? Convert.ToString(int.Parse(redColorTextBox.Text), 16) : "";
                greenColorTextBox.Text = greenColorTextBox.Text != "" ? Convert.ToString(int.Parse(greenColorTextBox.Text), 16) : "";
                blueColorTextBox.Text = blueColorTextBox.Text != "" ? Convert.ToString(int.Parse(blueColorTextBox.Text), 16) : "";
            }
        }
    }
}
