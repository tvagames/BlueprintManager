using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueprintManager
{
    public partial class FormBlueprintEditor : Form
    {
        private Point startPoint;
        private float length;
        private int zoom;
        public FormBlueprintEditor()
        {
            InitializeComponent();
            this.zoom = 5;
        }

        private void panel1_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            var size = this.length;
            var x = 0F;
            var y = 0F;

            while (x < this.panel1.Width)
            {
                g.DrawLine(Pens.Silver, x, 0, x, this.panel1.Height);
                x += this.zoom;
            }
            while (y < this.panel1.Height)
            {
                g.DrawLine(Pens.Silver, 0, y, this.panel1.Width, y);
                y += this.zoom;
            }

            if (length > 0)
            {
                x = 0F;
                y = 0F;

                var a = length;
                g.DrawEllipse(Pens.Black, this.startPoint.X - a, this.startPoint.Y - a, a * 2, a * 2);
                //while (x < this.panel1.Width)
                //{
                //    while (y < this.panel1.Height)
                //    {
                //        var cx = x - size / 2;
                //        var cy = y - size / 2;
                //        var cl = (float)Math.Sqrt(Math.Pow(cx - this.startPoint.X, 2) + Math.Pow(cy - this.startPoint.Y, 2));
                //        if (this.length > Math.Abs(cl))
                //        {
                //            g.FillRectangle(Brushes.Black, x, y, size, size);
                //        }
                //        y += this.zoom;
                //    }
                //    x += this.zoom;
                //}
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                double x = e.Location.X - this.startPoint.X;
                double y = e.Location.Y - this.startPoint.Y;
                length = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                this.panel1.Refresh();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void FormBlueprintEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
