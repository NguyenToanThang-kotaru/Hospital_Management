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

        // Thêm các thuộc tính margin
        public int MarginLeft { get; set; } = 0;
        public int MarginTop { get; set; } = 0;
        public int MarginRight { get; set; } = 0;
        public int MarginBottom { get; set; } = 0;

        public RoundedPanel()
        {
            InitializePanel();
        }

        public RoundedPanel(int borderRadius, Color panelColor)
        {
            BorderRadius = borderRadius;
            PanelColor = panelColor;
            InitializePanel();
        }

        // Constructor mới với margin
        public RoundedPanel(int borderRadius, Color panelColor, int marginLeft, int marginTop, int marginRight, int marginBottom)
        {
            BorderRadius = borderRadius;
            PanelColor = panelColor;
            MarginLeft = marginLeft;
            MarginTop = marginTop;
            MarginRight = marginRight;
            MarginBottom = marginBottom;
            InitializePanel();
        }

        private void InitializePanel()
        {
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Tính toán kích thước thực tế với margin
            Rectangle rect = new Rectangle(
                MarginLeft,
                MarginTop,
                this.Width - 1 - MarginLeft - MarginRight,
                this.Height - 1 - MarginTop - MarginBottom
            );

            using (GraphicsPath path = CreateRoundedRectangle(rect, BorderRadius))
            {
                using (SolidBrush brush = new SolidBrush(PanelColor))
                    e.Graphics.FillPath(brush, path);

                using (Pen pen = new Pen(Color.LightGray, 1))
                    e.Graphics.DrawPath(pen, path);
            }
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

            int diameter = radius * 2;

            // Đảm bảo đường kính không lớn hơn kích thước hình chữ nhật
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arcRect, 180, 90);

            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Phương thức để thiết lập border radius
        public void SetBorderRadius(int radius)
        {
            BorderRadius = radius;
            this.Invalidate();
        }

        // Các phương thức mới để thiết lập margin
        public void SetMargin(int left, int top, int right, int bottom)
        {
            MarginLeft = left;
            MarginTop = top;
            MarginRight = right;
            MarginBottom = bottom;
            this.Invalidate();
        }

        
        // Property để lấy kích thước nội dung thực tế (trừ margin)
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