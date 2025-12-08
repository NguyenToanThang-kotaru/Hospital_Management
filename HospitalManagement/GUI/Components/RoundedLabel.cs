using HM.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HM.GUI.Component
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
            InitializeLabel(160, 45, "Chuc Nang");
        }

        public RoundedLabel(int panelWidth, int panelHeight, string labelText)
        {
            InitializeLabel(panelWidth, panelHeight, labelText);
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

            // Kiểm tra kích thước hợp lệ
            if (this.Width <= 0 || this.Height <= 0)
                return;

            Rectangle rect = new Rectangle(
                MarginLeft,
                MarginTop,
                Math.Max(1, this.Width - 1 - MarginLeft - MarginRight),
                Math.Max(1, this.Height - 1 - MarginTop - MarginBottom)
            );

            // Kiểm tra rect hợp lệ
            if (rect.Width <= 0 || rect.Height <= 0)
                return;

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

            // Kiểm tra rect hợp lệ
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            // Đảm bảo radius không quá lớn
            int maxRadius = Math.Min(rect.Width, rect.Height) / 2;
            int actualRadius = Math.Min(radius, maxRadius);
            
            // Nếu radius quá nhỏ, vẽ hình chữ nhật thường
            if (actualRadius <= 1)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = actualRadius * 2;
            
            // Đảm bảo diameter không vượt quá kích thước
            diameter = Math.Min(diameter, Math.Min(rect.Width, rect.Height));

            // Tính toán tọa độ
            int left = rect.Left;
            int top = rect.Top;
            int right = rect.Right - 1;  // Trừ 1 để tránh vẽ ra ngoài
            int bottom = rect.Bottom - 1; // Trừ 1 để tránh vẽ ra ngoài

            try
            {
                // Vẽ 4 góc bo tròn theo chiều kim đồng hồ
                // Góc trên bên trái
                path.AddArc(left, top, diameter, diameter, 180, 90);
                
                // Góc trên bên phải
                path.AddArc(right - diameter, top, diameter, diameter, 270, 90);
                
                // Góc dưới bên phải
                path.AddArc(right - diameter, bottom - diameter, diameter, diameter, 0, 90);
                
                // Góc dưới bên trái
                path.AddArc(left, bottom - diameter, diameter, diameter, 90, 90);
                
                path.CloseFigure();
            }
            catch (ArgumentException ex)
            {
                // Fallback: vẽ hình chữ nhật thường nếu có lỗi
                path.Dispose();
                path = new GraphicsPath();
                path.AddRectangle(rect);
                
            }

            return path;
        }

        public void SetBorderRadius(int radius)
        {
            // Kiểm tra giá trị hợp lệ
            if (radius < 0)
                radius = 0;
            
            BorderRadius = radius;
            this.Invalidate();
        }

        public void SetMargin(int left, int top, int right, int bottom)
        {
            // Đảm bảo margin không âm
            MarginLeft = Math.Max(0, left);
            MarginTop = Math.Max(0, top);
            MarginRight = Math.Max(0, right);
            MarginBottom = Math.Max(0, bottom);
            this.Invalidate();
        }

        public Rectangle ContentRectangle
        {
            get
            {
                return new Rectangle(
                    MarginLeft,
                    MarginTop,
                    Math.Max(0, this.Width - MarginLeft - MarginRight),
                    Math.Max(0, this.Height - MarginTop - MarginBottom)
                );
            }
        }

        // Thêm method để kiểm tra tính hợp lệ
        public bool IsValidSize()
        {
            return this.Width > 0 && this.Height > 0;
        }

        // Override để kiểm tra khi thay đổi kích thước
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            // Đảm bảo kích thước không âm
            width = Math.Max(1, width);
            height = Math.Max(1, height);
            
            base.SetBoundsCore(x, y, width, height, specified);
        }
    }
}