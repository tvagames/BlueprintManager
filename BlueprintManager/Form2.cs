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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public BlueprintFile Blueprint { get; set; }
        private Bitmap bmp;
        public Dictionary<string, BlockDefinition> BlockIdList { get; set; }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.Blueprint.LoadBlocks();
            this.BlockIdList = BlockDefinitionStore.LoadBlockDefinitions();
            
        }

        private void DrawSrope(float zoom, float offsetX, float offsetY, Graphics g, BlockInfo item, float x, float y, int srope, Direction direct, Direction top)
        {
            if (direct == Direction.Right)
            {
                if (top == Direction.Bottom)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX + srope) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
                else if (top == Direction.Top)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX + srope) * zoom, (y + offsetY + 1) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
            }
            else if (direct == Direction.Left)
            {
                if (top == Direction.Bottom)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1 - srope) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
                else if (top == Direction.Top)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1 - srope) * zoom, (y + offsetY + 1) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY + 1) * zoom),
                    });
                }
            }
            else if (direct == Direction.Top)
            {
                if (top == Direction.Right)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY+1) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY+1-srope) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY+1) * zoom),
                    });
                }
                else if (top == Direction.Left)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY+1) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY+1-srope) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY+1) * zoom),
                    });
                }
            }
            else if (direct == Direction.Bottom)
            {
                if (top == Direction.Right)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY-srope) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                    });
                }
                else if (top == Direction.Left)
                {
                    g.FillPolygon(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), new PointF[]
                    {
                            new PointF((x + offsetX+1) * zoom, (y + offsetY) * zoom),
                            new PointF((x + offsetX+1) * zoom, (y + offsetY-srope) * zoom),
                            new PointF((x + offsetX) * zoom, (y + offsetY) * zoom),
                    });
                }
            }
        }

        private enum Direction
        {
            Top,
            Left,
            Right,
            Bottom,
            Other,
        }


        private void DrawBeam(float zoom, float offsetX, float offsetY, Graphics g, BlockInfo item, float x, float y, float beam, Direction direct)
        {
            if (direct == Direction.Right)
            {
                var r = new RectangleF((x + offsetX) * zoom, (y + offsetY) * zoom, zoom * beam, zoom);
                g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
            }
            else if (direct == Direction.Left)
            {
                var r = new RectangleF((x + offsetX - beam) * zoom, (y + offsetY) * zoom, zoom * beam, zoom);
                g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
            }
            else if (direct == Direction.Bottom)
            {
                var r = new RectangleF((x + offsetX) * zoom, (y + offsetY) * zoom, zoom * beam, zoom * beam);
                g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
            }
            else if (direct == Direction.Top)
            {
                var r = new RectangleF((x + offsetX - beam) * zoom, (y + offsetY) * zoom, zoom * beam, zoom * beam);
                g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
            }
            else
            {
                var r = new RectangleF((x + offsetX) * zoom, (y + offsetY) * zoom, zoom, zoom);
                g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.Blueprint.Draw3d(e.Graphics, 10, degree, offset, this.BlockIdList, null);
        }




        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private PointF lastPoint = new PointF();
        private Vector3 degree = new Vector3();
        private PointF offset = new PointF();
        private PointF offsetBuffer = new PointF();
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            offsetBuffer.X = offset.X;
            offsetBuffer.Y = offset.Y;

            lastPoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                offset.X = (e.Location.X - lastPoint.X) + offsetBuffer.X;
                offset.Y = (e.Location.Y - lastPoint.Y) + offsetBuffer.Y;
                this.pictureBox1.Refresh();
            }
            if (e.Button.HasFlag(MouseButtons.Right))
            {
                degree.Y += (e.Location.X - lastPoint.X) / 50;
                degree.X += (e.Location.Y - lastPoint.Y) / 50;
                this.pictureBox1.Refresh();
            }
        }
    }
}
