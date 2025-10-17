using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Component
{
    internal class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 40;
        public Color PanelColor { get; set; } = Color.White;
        public int MarginLeft { get; set; } = 0;
        public int MarginTop { get; set; } = 0;
        public int MarginRight { get; set; } = 0;
        public int MarginBottom { get; set; } = 0;

        public RoundedPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float x = MarginLeft;
            float y = MarginTop;
            float width = this.Width - 1 - MarginLeft - MarginRight;
            float height = this.Height - 1 - MarginTop - MarginBottom;

            float radius = Math.Max(0, Math.Min(BorderRadius, Math.Min(width, height) / 2));
            float d = radius * 2;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(x, y, d, d, 180, 90);                         
                path.AddArc(x + width - d, y, d, d, 270, 90);             
                path.AddArc(x + width - d, y + height - d, d, d, 0, 90);   
                path.AddArc(x, y + height - d, d, d, 90, 90);             
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(PanelColor))
                    e.Graphics.FillPath(brush, path);

                //using (Pen pen = new Pen(Color.LightGray, 1))
                //    e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        public void SetBorderRadius(int radius)
        {
            BorderRadius = radius;
            Invalidate();
        }

        public void SetMargin(int left, int top, int right, int bottom)
        {
            MarginLeft = left;
            MarginTop = top;
            MarginRight = right;
            MarginBottom = bottom;
            Invalidate();
        }

        public (float X, float Y, float Width, float Height) GetContentArea()
        {
            return (
                MarginLeft,
                MarginTop,
                this.Width - MarginLeft - MarginRight,
                this.Height - MarginTop - MarginBottom
            );
        }
    }
}
