using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlueprintManager
{
    class ColorPalettePanel : Panel
    {
        public bool Selected { get; set; }

        public ColorPalettePanel()
        {
            _colors = new Color[32];
            this.DoubleBuffered = true;
        }

        private Color[] _colors;
        private Rectangle buttonRect;

        public Color[] Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
            }
        }

        public bool CanRemove { get; internal set; }
        public bool IsHitDelelteButton { get; private set; }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var temp = (this.buttonRect.Left <= e.X && e.X <= this.buttonRect.Right &&
                this.buttonRect.Top <= e.Y && e.Y <= this.buttonRect.Bottom);

            if (this.IsHitDelelteButton != temp)
            {
                this.IsHitDelelteButton = temp;
                this.Refresh();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.IsHitDelelteButton = false;
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            var cellWidth = this.Width / 19;
            var cellHeight = this.Height / 2;

            var backRectSize = 5;
            var backRectTop = 0;
            var backRectCount = 0;
            var topCount = 0;
            while (backRectTop < this.Height)
            {
                var backRectLeft = 0;
                backRectCount = topCount;
                while (backRectLeft < this.Width)
                {
                    var rect = new Rectangle(backRectLeft, backRectTop, backRectSize, backRectSize);
                    if (backRectCount % 2 == 0)
                    {
                        g.FillRectangle(Brushes.White, rect);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Silver, rect);
                    }
                    backRectLeft += backRectSize;
                    backRectCount++;
                }
                backRectTop += backRectSize;
                topCount++;
            }


            var top = 0;
            for (int i = 0; i < 2; i++)
            {
                var left = 0;
                for (int j = 0; j < 19; j++)
                {
                    var index = i * 19 + j;
                    if (this.Colors.Length <= index)
                    {
                        break;
                    }
                    cellWidth = (this.Width - left) / (19 - j);
                    var rect = new Rectangle(left, top, cellWidth, cellHeight);
                    using (var b = new SolidBrush(this.Colors[index]))
                    {
                        g.FillRectangle(b, rect);
                        var s = index.ToString();
                        var sr = g.MeasureString(s, this.Font);

                        var temp = this.Colors[index].R + this.Colors[index].G + this.Colors[index].B;
                        var sb = Brushes.Black;
                        if (this.Colors[index].A > 128 && temp < 255 * 4 / 2)
                        {
                            sb = Brushes.White;
                        }

                        g.DrawString(index.ToString(), this.Font, sb, 
                            left + (cellWidth - sr.Width) / 2,
                            top + (cellHeight - sr.Height) / 2);
                    }
                    left += cellWidth;
                }
                top += cellHeight;
            }

            if (this.CanRemove)
            {
                // delete button
                var buttonSize = cellHeight;
                var deleteText = "x";
                var deleteTextRectTemp = g.MeasureString(deleteText, this.Font);
                this.buttonRect = new Rectangle(this.Width - buttonSize, this.Height - buttonSize, buttonSize, buttonSize);
                var deleteTextRect = new Rectangle(this.buttonRect.X, this.buttonRect.Y, this.buttonRect.Width, this.buttonRect.Height);
                deleteTextRect.X += (int)(deleteTextRect.Width - deleteTextRectTemp.Width) / 2;
                deleteTextRect.Y += (int)(deleteTextRect.Height - deleteTextRectTemp.Height) / 2;

                if (this.IsHitDelelteButton)
                {
                    g.FillEllipse(Brushes.Red, buttonRect);
                    g.DrawString(deleteText, this.Font, Brushes.White, deleteTextRect);
                }
                else
                {
                    g.FillEllipse(Brushes.White, buttonRect);
                    g.DrawString(deleteText, this.Font, Brushes.Black, deleteTextRect);
                }
            }

            using (var b = new Pen(Color.Silver))
            {
                var left = 0;

                for (int i = 0; i < 19; i++)
                {
                    cellWidth = (this.Width - left) / (19 - i);
                    g.DrawLine(b, left, 0, left, this.Height);
                    left += cellWidth;
                }
                g.DrawLine(b, 0, cellHeight, this.Width, cellHeight);
            }

            if (this.Selected)
            {
                using (var b = new Pen(Color.Black, 2))
                {
                    b.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawRectangle(b, 1, 1, this.Width - 2, this.Height - 2);
                }
            }
        }
        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            this.Refresh();
        }
    }

   
}
