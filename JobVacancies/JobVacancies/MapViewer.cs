using System;
using System.Drawing;
using System.Windows.Forms;

namespace JobVacancies
{
    public partial class MapViewer : Form
    {
        private const string MAP_PATH = @"C:\Users\Lotte\Documents\01-Werk\09-3Mensio\Winform_JobVacancies\Data\Map\MapNL_01.jpg";

        private bool inPan = false;
        private Point panStart = Point.Empty;
        private Point imagePos = Point.Empty;
        private Image Image;

        public MapViewer()
        {
            Image = Image.FromFile(MAP_PATH);
            
            InitializeComponent();
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
                imagePos = new Point(MathBuddy.Clamp(e.Location.X - panStart.X, -Math.Max(Image.Width - ClientSize.Width, 0), 0),
                                     MathBuddy.Clamp(e.Location.Y - panStart.Y, -Math.Max(Image.Height - ClientSize.Height, 0), 0));
                pictureBox.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(Image, new Rectangle(imagePos, Image.PhysicalDimension.ToSize()));
            e.Dispose();
        }
    }
}
