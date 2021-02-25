using PluginInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Task_1
{
    public partial class MainForm : Form
    {
        protected static int width;
        protected static int numberOfStarPeaks;
        private int documentCounter = 1;

        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();

        public static Color CurrentColor { get; set; }
        public static int CurrentWidth 
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
            }
        }
        public static int NumberOfStarPeaks
        {
            get
            {
                return numberOfStarPeaks;
            }
            set
            {
                if(value > 0)
                {
                    numberOfStarPeaks = value;
                }
            }
        }

        public static string typePen = "pen";

        public MainForm()
        {
            InitializeComponent();

            FindPlugins();
            CreateMenu();

            CurrentColor = Color.Black;
            CurrentWidth = 3;
            NumberOfStarPeaks = 5;
        }

        public void SetStatusBarText(string Text)
        {
            toolStripStatusLabel1.Text = Text;
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas d = new Canvas();
            d.Text = $"Документ {documentCounter++}";
            d.MdiParent = this;
            d.Show();
            сохранитьToolStripMenuItem.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frmAbout = new AboutBox();
            frmAbout.ShowDialog();
        }
   
        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();

            if (d.ShowDialog() == DialogResult.OK)
            {
                CurrentColor = d.Color;
            }
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Blue;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentColor = Color.Green;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void рисунокToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSize cs = new CanvasSize();
            cs.CanvasWidth = ((Canvas)ActiveMdiChild).CanvasWidth;
            cs.CanvasHeight = ((Canvas)ActiveMdiChild).CanvasHeight;
            if (cs.ShowDialog() == DialogResult.OK)
            {
                ((Canvas)ActiveMdiChild).CanvasWidth = cs.CanvasWidth;
                ((Canvas)ActiveMdiChild).CanvasHeight = cs.CanvasHeight;
                ((Canvas)ActiveMdiChild).Height = cs.CanvasHeight + 5;
                ((Canvas)ActiveMdiChild).Width = cs.CanvasWidth + 5;
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (width_TextBox.Text.Length > 0)
            {
                width = Convert.ToInt32(width_TextBox.Text);
            }
        }

        private void width_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            width_TextBox.Text = width.ToString();
            toolStripTextBox_TopStar.Text = numberOfStarPeaks.ToString();
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void toolStripButton_pen_Click(object sender, EventArgs e)
        {
            typePen = "pen";
            toolStripStatusLabel_Tool.Text = "Инструмент: Карандаш";
            StarSettings(false);
        }

        private void toolStripButton_drawLine_Click(object sender, EventArgs e)
        {
            typePen = "line";
            toolStripStatusLabel_Tool.Text = "Инструмент: Линия";
            StarSettings(false);
        }

        private void toolStripButton_drawEllyps_Click(object sender, EventArgs e)
        {
            typePen = "ellipse";
            toolStripStatusLabel_Tool.Text = "Инструмент: Эллипс";
            StarSettings(false);
        }

        private void toolStripButton_Ereser_Click(object sender, EventArgs e)
        {
            typePen = "eraser";
            toolStripStatusLabel_Tool.Text = "Инструмент: Ластик";
            StarSettings(false);
        }

        private void toolStripButton_drawStar_Click(object sender, EventArgs e)
        {
            typePen = "star";
            toolStripStatusLabel_Tool.Text = "Инструмент: Звезда";
            StarSettings(true);
        }

        void StarSettings(bool check)
        {
            if (check)
            {
                toolStripLabel_CountTopStar.Visible = true;
                toolStripTextBox_TopStar.Visible = true;
            }
            else
            {
                toolStripLabel_CountTopStar.Visible = false;
                toolStripTextBox_TopStar.Visible = false;
            }
        }

        private void toolStripTextBox_TopStar_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox_TopStar.Text.Length > 0)
            {
                numberOfStarPeaks = Convert.ToInt32(toolStripTextBox_TopStar.Text);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Все файлы ()*.*|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Canvas frmChild = new Canvas(dlg.FileName);
                frmChild.MdiParent = this;
                frmChild.Show();
            }

            сохранитьToolStripMenuItem.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).SaveAs();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Canvas canvas = (Canvas)ActiveMdiChild;
            if (canvas.fileName.Length > 0)
            {
                canvas.Save();
            }
            else
            {
                canvas.SaveAs();
            }
        }

        private void toolStripButton_PlusScale_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).PlusScale();
        }

        private void toolStripButton_MinusScale_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).MinusScale();
        }

        void FindPlugins()
        {
            // папка с плагинами
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            // dll-файлы в этой папке
            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        Type iface = type.GetInterface("PluginInterface.IPlugin");

                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
        }

        void CreateMenu()
        {
            foreach (IPlugin plugin in plugins.Values)
            {
                var menuItem = new ToolStripMenuItem(plugin.Name);
                menuItem.Click += OnPluginClick;
                VersionAttribute MyAttribute = (VersionAttribute)Attribute.GetCustomAttribute(plugin.GetType(), typeof(VersionAttribute));
                menuItem.ToolTipText = $"Автор: {plugin.Author}\nВерсия: {MyAttribute.Major}.{MyAttribute.Minor}";
                фильтрыToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform((Bitmap)((Canvas)ActiveMdiChild).pictureBox1.Image);
            ((Canvas)ActiveMdiChild).pictureBox1.Refresh();
        }

        private void добавитьФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Dll файл (*.dll)|*.dll";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Canvas frmChild = new Canvas(dlg.FileName);
                frmChild.MdiParent = this;
                frmChild.Show();
            }

            сохранитьToolStripMenuItem.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
        }
    }
}