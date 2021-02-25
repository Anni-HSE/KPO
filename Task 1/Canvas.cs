using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Canvas : Form
    {
        Point from;
        Point to;
        private Bitmap bmp;
        bool IsClicked = false;
        public string fileName = "";
        public bool IsChanged = false;
        string format;

        public Canvas()
        {
            InitializeComponent();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            pictureBox1.Image = bmp;
        }

        public Canvas(String FileName)
        {
            InitializeComponent();
            bmp = new Bitmap(FileName);
            fileName = FileName;
            Graphics g = Graphics.FromImage(bmp);
            pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;
            pictureBox1.Image = bmp;
            format = Path.GetExtension(FileName);
        }

        public int CanvasWidth
        {
            get
            {
                return pictureBox1.Width;
            }
            set
            {
                pictureBox1.Width = value;
                Bitmap tbmp = new Bitmap(value, pictureBox1.Width);
                Graphics g = Graphics.FromImage(tbmp);
                g.Clear(Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                bmp = tbmp;
                pictureBox1.Image = bmp;
            }
        }

        public int CanvasHeight
        {
            get
            {
                return pictureBox1.Height;
            }
            set
            {
                pictureBox1.Height = value;
                Bitmap tbmp = new Bitmap(pictureBox1.Width, value);
                Graphics g = Graphics.FromImage(tbmp);
                g.Clear(Color.White);
                g.DrawImage(bmp, new Point(0, 0));
                bmp = tbmp;
                pictureBox1.Image = bmp;
            }
        }

        public void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";

            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Bitmap blank = new Bitmap(bmp);
                Graphics g = Graphics.FromImage(blank);
                g.Clear(Color.White);
                g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);

                Bitmap output = new Bitmap(blank);
                blank.Dispose();
                bmp.Dispose();
                fileName = dlg.FileName;

                output.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);

                bmp = new Bitmap(output);
                pictureBox1.Image = bmp;
            }

            IsChanged = false;
        }

        public void Save()
        {
            if (fileName.Length > 0)
            {
                Bitmap blank = new Bitmap(bmp);
                Graphics g = Graphics.FromImage(blank);
                g.Clear(Color.White);
                g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);

                Bitmap output = new Bitmap(blank);
                blank.Dispose();
                bmp.Dispose();

                if (format == ".bmp")
                    output.Save(fileName, ImageFormat.Bmp);
                else
                    output.Save(fileName, ImageFormat.Jpeg);

                bmp = new Bitmap(output);
                pictureBox1.Image = bmp;
            }

            IsChanged = false;
        }

        public void PlusScale()
        {
            Image old = pictureBox1.Image;
            pictureBox1.Width *= 2;
            pictureBox1.Height *= 2;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(old, 0, 0, old.Width * 2, old.Height * 2);
            pictureBox1.Image = bmp;
        }

        public void MinusScale()
        {
            Image old = pictureBox1.Image;
            pictureBox1.Width /= 2;
            pictureBox1.Height /= 2;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(old, 0, 0, old.Width / 2, old.Height / 2);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmp);

                if (MainForm.typePen == "eraser")
                {
                    g.FillEllipse(new SolidBrush(pictureBox1.BackColor), e.X, e.Y, MainForm.CurrentWidth, MainForm.CurrentWidth);
                    from = e.Location;
                    IsChanged = true;
                }

                if (MainForm.typePen == "pen")
                {
                    Pen p = new Pen(MainForm.CurrentColor, MainForm.CurrentWidth);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(p, from, e.Location);
                    from = e.Location;
                    IsChanged = true;
                }

                if ((MainForm.typePen == "line" || MainForm.typePen == "ellipse" || MainForm.typePen == "star") && IsClicked)
                {
                    to = e.Location;
                    IsChanged = true;
                }

                pictureBox1.Invalidate();
            }

            MainForm parent = (MainForm)MdiParent;
            parent.SetStatusBarText($"X:{e.X}; Y:{e.Y}");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (MainForm.typePen != "pen")
            {
                IsClicked = true;
            }

            IsChanged = true;
            from = e.Location;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsClicked = false;
            Graphics g = Graphics.FromImage(bmp);

            if(MainForm.typePen == "line")
            {
                g.DrawLine(new Pen(MainForm.CurrentColor, MainForm.CurrentWidth), from, to);
                IsChanged = true;
                return;
            }

            if (MainForm.typePen == "ellipse")
            {
                g.DrawEllipse(new Pen(MainForm.CurrentColor, MainForm.CurrentWidth), from.X, from.Y, to.X - from.X, to.Y - from.Y);
                IsChanged = true;
                return;
            }

            if (MainForm.typePen == "star")
            {
                DrawStar(new Pen(MainForm.CurrentColor, MainForm.CurrentWidth), from, to, MainForm.NumberOfStarPeaks, g);
                IsChanged = true;
                return;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (MainForm.typePen == "line")
            {
                e.Graphics.DrawLine(new Pen(MainForm.CurrentColor, MainForm.CurrentWidth), from, to);
                IsChanged = true;
                return;
            }
            if (MainForm.typePen == "ellipse")
            {
                e.Graphics.DrawEllipse(new Pen(MainForm.CurrentColor, MainForm.CurrentWidth), from.X, from.Y, to.X - from.X, to.Y - from.Y);
                IsChanged = true;
                return;
            }
            if (MainForm.typePen == "star")
            {
                DrawStar(new Pen(MainForm.CurrentColor, MainForm.CurrentWidth), from, to, MainForm.NumberOfStarPeaks, e.Graphics);
                IsChanged = true;
                return;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            MainForm parent = (MainForm)MdiParent;
            parent.SetStatusBarText(string.Empty);
        }

        private void DrawStar(Pen pen, Point startPosition, Point endPosition, int numberPeaks, Graphics g)
        {
            int X = (startPosition.X + endPosition.X) / 2;
            int Y = (startPosition.Y + endPosition.Y) / 2;
            double r1 = Math.Abs(endPosition.X - startPosition.X);
            double r2 = Math.Abs(endPosition.Y - startPosition.Y);
            double alpha = 0;
            double r = r1 < r2 ? r2 / 2 : r1 / 2, R = r / 2;

            if(numberPeaks < 3)
            {
                numberPeaks = 3;
                MainForm.NumberOfStarPeaks = 3;
            }

            PointF[] points = new PointF[2 * numberPeaks + 1];
            double a = alpha, da = Math.PI / numberPeaks, l;
            for (int k = 0; k < 2 * numberPeaks + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                points[k] = new PointF((float)(X + l * Math.Cos(a)), (float)(Y + l * Math.Sin(a)));
                a += da;
            }

            g.DrawLines(pen, points);
        }

        private void Canvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsChanged)
            {
                DialogResult dialogResult = MessageBox.Show("Сохранить изменения?", "Закрытие документа", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveAs();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
