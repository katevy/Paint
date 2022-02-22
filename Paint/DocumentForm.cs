using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Paint
{
    public partial class DocumentForm : Form
    {
        private int x, y;
        public Bitmap bitmap;
        public int SaveCount = 0;
        public string Name;
        public ImageFormat Format;
        public DocumentForm()
        {
            InitializeComponent();
            bitmap = new Bitmap(300, 200);
        }

        private void DocumentForm_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void DocumentForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawLine(new Pen(MainForm.Color, MainForm.Width), x, y, e.X, e.Y);
                Invalidate();
                x = e.X;
                y = e.Y;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void DocumentForm_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(bitmap);

            g.DrawLine(new Pen(MainForm.Color, MainForm.Width), x, y, e.X, e.Y);
            x = e.X;
            y = e.Y;
            Invalidate();
        }

        private void DocumentForm_Load(object sender, EventArgs e)
        {

        }

    }
}
