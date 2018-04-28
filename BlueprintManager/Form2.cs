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

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Blueprint.LoadBlocks();
            this.Text = this.Blueprint.Name;
            var orderedList = this.Blueprint.Blocks.OrderBy(item => item.y);
            float zoom = 3;
            float offsetX = this.Blueprint.MinCord[2] * -1;
            float offsetY = this.Blueprint.MaxCord[1] * 1;
            offsetX += 10;
            offsetY += 10;

            this.bmp = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(this.bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (var item in orderedList)
            {
                if (item.id == 609 
                    || item.id == 608
                    || item.id == 607
                    || item.id == 498
                    || item.id == 497
                    || item.id == 496)
                {
                    float beam = 1;
                    if (item.id == 609 || item.id == 498) // 4m beam
                    {
                        beam = 4;
                    }
                    else if (item.id == 608 || item.id == 497) // 3m beam
                    {
                        beam = 3;
                    }
                    else if (item.id == 607 || item.id == 496) // 3m beam
                    {
                        beam = 2;
                    }

                    Direction d = Direction.Other;
                    if (item.IsForward())
                    {
                        d = Direction.Right;
                    }
                    else if (item.IsBack())
                    {
                        d = Direction.Left;
                    }
                    else if (item.IsRight())
                    {
                        d = Direction.Bottom;
                    }
                    else if (item.IsLeft())
                    {
                        d = Direction.Top;
                    }

                    this.DrawBeam(zoom, offsetX, offsetY, g, item, item.z, item.x, beam, d);
                }
                else if (item.id == 503 || item.id == 614 
                    || item.id == 504 || item.id == 615
                    || item.id == 502 || item.id == 613)
                {
                    var srope = 4;
                    if (item.id == 503 || item.id == 614)
                    {
                        srope = 4;
                    }
                    else if (item.id == 504 || item.id == 615)
                    {
                        srope = 3;
                    }
                    else if (item.id == 502 || item.id == 613)
                    {
                        srope = 2;
                    }

                    if (item.rotation == Rotation.ForwardRight)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Right, Direction.Bottom);
                    }
                    else if (item.rotation == Rotation.ForwardLeft)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Right, Direction.Top);
                    }
                    else if (item.rotation == Rotation.BackRight)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Left, Direction.Bottom);
                    }
                    else if (item.rotation == Rotation.BackLeft)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Left, Direction.Top);
                    }
                    else if (item.rotation == Rotation.RightForward)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Bottom, Direction.Right);
                    }
                    else if (item.rotation == Rotation.RightBack)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Bottom, Direction.Left);
                    }
                    else if (item.rotation == Rotation.LeftForward)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Top, Direction.Right);
                    }
                    else if (item.rotation == Rotation.LeftBack)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, Direction.Top, Direction.Left);
                    }
                    else
                    {
                        Direction d = Direction.Other;
                        if (item.IsForward())
                        {
                            d = Direction.Right;
                        }
                        else if (item.IsBack())
                        {
                            d = Direction.Left;
                        }
                        else if (item.IsRight())
                        {
                            d = Direction.Bottom;
                        }
                        else if (item.IsLeft())
                        {
                            d = Direction.Top;
                        }
                        this.DrawBeam(zoom, offsetX, offsetY, g, item, item.z, item.x, srope, d);

                    }
                }
                else
                {
                    var r = new RectangleF((item.z + offsetX) * zoom, (item.x + offsetY) * zoom, zoom, zoom);
                    g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
                }
            }
            offsetY += 50;
            offsetY += this.Blueprint.MinCord[1] * -1;
            offsetY += this.Blueprint.MaxCord[0] * 1;

            foreach (var item in this.Blueprint.Blocks.OrderBy(item => item.x))
            {
                if (item.id == 609
                    || item.id == 608
                    || item.id == 607
                    || item.id == 498
                    || item.id == 497
                    || item.id == 496)
                {
                    float beam = 1;
                    if (item.id == 609 || item.id == 498) // 4m beam
                    {
                        beam = 4;
                    }
                    else if (item.id == 608 || item.id == 497) // 3m beam
                    {
                        beam = 3;
                    }
                    else if (item.id == 607 || item.id == 496) // 3m beam
                    {
                        beam = 2;
                    }

                    Direction d = Direction.Other;
                    if (item.IsForward())
                    {
                        d = Direction.Right;
                    }
                    else if (item.IsBack())
                    {
                        d = Direction.Left;
                    }
                    else if (item.IsDown())
                    {
                        d = Direction.Bottom;
                    }
                    else if (item.IsUp())
                    {
                        d = Direction.Top;
                    }

                    this.DrawBeam(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, beam, d);
                }
                else if (item.id == 503 || item.id == 614
                    || item.id == 504 || item.id == 615
                    || item.id == 502 || item.id == 613)
                {
                    var srope = 4;
                    if (item.id == 503 || item.id == 614)
                    {
                        srope = 4;
                    }
                    else if (item.id == 504 || item.id == 615)
                    {
                        srope = 3;
                    }
                    else if (item.id == 502 || item.id == 613)
                    {
                        srope = 2;
                    }

                    if (item.rotation == Rotation.ForwardDown)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Right, Direction.Bottom);
                    }
                    else if (item.rotation == Rotation.ForwardUp)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Right, Direction.Top);
                    }
                    else if (item.rotation == Rotation.BackDown)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Left, Direction.Bottom);
                    }
                    else if (item.rotation == Rotation.BackUp)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Left, Direction.Top);
                    }
                    else if (item.rotation == Rotation.DownForward)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Bottom, Direction.Right);
                    }
                    else if (item.rotation == Rotation.DownBack)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Bottom, Direction.Left);
                    }
                    else if (item.rotation == Rotation.UpForward)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Top, Direction.Right);
                    }
                    else if (item.rotation == Rotation.UpBack)
                    {
                        this.DrawSrope(zoom, offsetX, offsetY, g, item, item.z, item.y * -1, srope, Direction.Top, Direction.Left);
                    }
                    else
                    {
                        Direction d = Direction.Other;
                        if (item.IsForward())
                        {
                            d = Direction.Right;
                        }
                        else if (item.IsBack())
                        {
                            d = Direction.Left;
                        }
                        else if (item.IsDown())
                        {
                            d = Direction.Bottom;
                        }
                        else if (item.IsUp())
                        {
                            d = Direction.Top;
                        }
                        this.DrawBeam(zoom, offsetX, offsetY, g, item,item.x, item.y * -1, srope, d);

                    }
                }

                else
                {
                    var r = new RectangleF((item.z + offsetX) * zoom, (item.y * -1 + offsetY) * zoom, zoom, zoom);
                    g.FillRectangle(new SolidBrush(this.Blueprint.Colors[item.colorIndex]), r);
                }
            }

            this.pictureBox1.Image = this.bmp;
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
    }
}
