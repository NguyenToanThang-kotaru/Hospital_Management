using HospitalManagerment.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Component
{
    internal class RoundedLabel : Label
    {
        public int BorderRadius { get; set; } = 20;
        public Color PanelColor { get; set; } = Color.White;
        public int MarginLeft { get; set; } = 0;
        public int MarginTop { get; set; } = 0;
        public int MarginRight { get; set; } = 0;
        public int MarginBottom { get; set; } = 0;
        public int PanelWidth { get; set; } = 140;
        public int PanelHeight { get; set; } = 45;

        public RoundedLabel()
        {
            InitializeLabel(160,45,"Chuc Nang");
        }

        public RoundedLabel(int PanelWidth, int PanelHeight, string LabelText)
        {
            InitializeLabel(160, 45, "Chuc Nang");
        }
        private void InitializeLabel(int width, int height, string labelText)
        {
            this.PanelWidth = width;
            this.PanelHeight = height;
            this.AutoSize = false;
            this.Size = new Size(width, height);
            this.BackColor = Color.Transparent;

            this.Font = Consts.TextBoxFont;
            this.Text = labelText;
            

            this.DoubleBuffered = true;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(
                MarginLeft,
                MarginTop,
                this.Width - 1 - MarginLeft - MarginRight,
                this.Height - 1 - MarginTop - MarginBottom
            );

            using (GraphicsPath path = CreateRoundedRectangle(rect, BorderRadius))
            using (SolidBrush brush = new SolidBrush(PanelColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(
                e.Graphics,
                this.Text,
                this.Font,
                rect,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            int right = rect.Right;
            int bottom = rect.Bottom;

            path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
            path.AddArc(right - diameter, rect.Top, diameter, diameter, 270, 90);
            path.AddArc(right - diameter, bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.Left, bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();
            return path;
        }

        public void SetBorderRadius(int radius)
        {
            BorderRadius = radius;
            this.Invalidate();
        }

        public void SetMargin(int left, int top, int right, int bottom)
        {
            MarginLeft = left;
            MarginTop = top;
            MarginRight = right;
            MarginBottom = bottom;
            this.Invalidate();
        }

        public Rectangle ContentRectangle
        {
            get
            {
                return new Rectangle(
                    MarginLeft,
                    MarginTop,
                    this.Width - MarginLeft - MarginRight,
                    this.Height - MarginTop - MarginBottom
                );
            }
        }
    }
}
