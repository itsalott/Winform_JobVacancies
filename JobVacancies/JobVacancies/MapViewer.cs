using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace JobVacancies
{
    public partial class MapViewer : Form
    {
        private bool inPan = false;
        private Point panStart = Point.Empty;
        private Point imagePos = Point.Empty;
        private Image Image;

        public MapViewer()
        {
            InitializeComponent();
            Image = pictureBox1.Image;
        }

        private void MapViewer_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Focus();
                inPan = true;
                panStart = new Point(e.Location.X - imagePos.X,
                                     e.Location.Y - imagePos.Y);
            }
        }

        private void pictureBox1_OnMouseUp(object sender, MouseEventArgs e)
        {
            inPan = false;
        }

        private void pictureBox1_OnMouseLeave(object sender, MouseEventArgs e)
        {
            inPan = false;
        }

        private void pictureBox1_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (inPan)
            {
                imagePos = new Point(e.Location.X - panStart.X,
                                     e.Location.Y - panStart.Y);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.Blue);
            var img = Image.FromFile(@"C:\Users\Lotte\Pictures\03-3D\download_20170803_142808.jpg");
            e.Graphics.DrawImage(img, imagePos);
            img.Dispose();
            e.Dispose();
            Debug.WriteLine($"new pos {imagePos}");
        }
    }
}
