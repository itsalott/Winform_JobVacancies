using System.Drawing;
using System;
using System.Windows.Forms;
using JobVacancies._99_Helpers;
using System.IO;

namespace JobVacancies._00_Map
{
    internal class MapBox
    {
        private const string MAP_PATH = @"Data\Map\MapNL_01.jpg";

        private bool inPan = false;
        private Point panStart = Point.Empty;
        private Point imagePos = Point.Empty;
        private Size clientSize;
        
        private Image Image;
        private PictureBox container;

        public MapBox(PictureBox pictureBox, Size clientSize)
        {
            // Don't start 2th path with '/', Path.Combine will consider it rooted,
            // and only return this path.
            Image = Image.FromFile(Path.Combine(ProjectRootPath.Value, MAP_PATH));
            this.clientSize = clientSize;

            container = pictureBox;

            container.Paint += new PaintEventHandler(Paint);
            container.MouseDown += new MouseEventHandler(OnMouseDown);
            container.MouseMove += new MouseEventHandler(OnMouseMove);
            container.MouseUp += new MouseEventHandler(OnMouseUp);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                inPan = true;
                panStart = new Point(e.Location.X - imagePos.X,
                                     e.Location.Y - imagePos.Y);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            inPan = false;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            inPan = false;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (inPan)
            {
                imagePos = new Point(MathBuddy.Clamp(e.Location.X - panStart.X, -Math.Max(Image.Width - clientSize.Width, 0), 0),
                                     MathBuddy.Clamp(e.Location.Y - panStart.Y, -Math.Max(Image.Height - clientSize.Height, 0), 0));
                container.Invalidate();
            }
        }

        private void Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(container.BackColor);
            e.Graphics.DrawImage(Image, new Rectangle(imagePos, Image.PhysicalDimension.ToSize()));
            e.Dispose();
        }
    }
}
