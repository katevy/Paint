using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class DocumentForm1 : Form
    {
        private int x, y;
        private Bitmap bitmap;
        public DocumentForm1()
        {
            InitializeComponent();
            bitmap = new Bitmap(300, 200);
        }

        private void DocumentForm1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void DocumentForm1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Refresh();
                Graphics g = CreateGraphics();
                g.DrawLine(new Pen(MainForm.Color, MainForm.Width), x, y, e.X, e.Y);
            }
        }

        private void DocumentForm1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(bitmap);

            g.DrawLine(new Pen(MainForm.Color, MainForm.Width), x, y, e.X, e.Y);
            x = e.X;
            y = e.Y;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

    }
}                       
