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
using System.IO;

namespace Paint
{
    public partial class MainForm : Form
    {
        
        public static Color Color { get; set; }
        public static int Width { get; set; }

        public MainForm()
        {
            InitializeComponent();
            Color = Color.Black;
            Width = 3;
        }

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAbout = new AboutForm();
            frmAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DocumentForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void рисунокToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Blue;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color = Color.Green;
        }

        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                Color = cd.Color;
        }

        private void рисунокToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled =!(ActiveMdiChild==null);
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SizeForm = new CanvasSizeForm();
            SizeForm.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                DocumentForm Active = (DocumentForm)this.ActiveMdiChild;

                if (Active.SaveCount == 0)
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.AddExtension = true;
                    dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";
                    ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        Active.bitmap.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
                        Active.Format = ff[dlg.FilterIndex - 1];
                        Active.Name = dlg.FileName;
                        Active.SaveCount++;
                    }
                }
                else
                {
                    Active.bitmap.Save(Active.Name, Active.Format);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                DocumentForm Active = (DocumentForm)this.ActiveMdiChild;
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg";
                ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Active.bitmap.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
                    Active.Format = ff[dlg.FilterIndex - 1];
                    Active.Name = dlg.FileName;
                    Active.SaveCount++;
                }

            }
        }

        private void октрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpeg, *.jpg)|*.jpeg;*.jpg|Все файлы ()*.*|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var name = dlg.FileName;
                var bitmap = Bitmap.FromFile(name);

                var frm = new DocumentForm((Bitmap)bitmap);
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void слеваНаправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
