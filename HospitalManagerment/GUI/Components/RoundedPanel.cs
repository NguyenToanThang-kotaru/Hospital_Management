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
        public int PanelWidth { get; set; } = 800;
        public int PanelHeight { get; set; } = 400;

        public RoundedPanel()
        {
            InitializePanel();
        }

        public RoundedPanel(int borderRadius, Color panelColor, int panelWidth, int panelHeight)
        {
            BorderRadius = borderRadius;
            PanelColor = panelColor;
            PanelWidth = panelWidth;
            PanelHeight = panelHeight;
            InitializePanel();
        }

        private void InitializePanel()
        {
            this.Size = new Size(PanelWidth, PanelHeight);
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

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
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

            // Đảm bảo radius không quá lớn
            int actualRadius = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);

            int diameter = actualRadius * 2;
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

        // Cập nhật kích thước panel khi thuộc tính thay đổi
        protected virtual void OnPanelSizeChanged()
        {
            this.Size = new Size(PanelWidth, PanelHeight);
            this.Invalidate();
        }

        // Override các setter để cập nhật giao diện khi thuộc tính thay đổi
        public void SetBorderRadius(int radius)
        {
            BorderRadius = radius;
            this.Invalidate();
        }

        public void SetPanelColor(Color color)
        {
            PanelColor = color;
            this.Invalidate();
        }

        public void SetPanelSize(int width, int height)
        {
            PanelWidth = width;
            PanelHeight = height;
            this.Size = new Size(width, height);
            this.Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Không gọi base.OnPaintBackground để tránh chớp do xóa nền
            // Tự vẽ nền trong OnPaint() rồi
        }
    }
}