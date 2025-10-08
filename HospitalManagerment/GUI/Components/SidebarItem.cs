using HospitalManagerment.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Components
{
    internal class SidebarItem : Label
    {
        public int BorderRadius { get; set; } = 3;
        public Color PanelBgColor { get; set; } = Consts.BgColor;
        public Color PanelTextColor { get; set; } = Consts.FontColorA;
        public Color HoverBgColor { get; set; } = Consts.MenuBtnFocusBgColor;
        public Color HoverTextColor { get; set; } = Consts.MenuBtnFocusFontColor;
        public int LabelWidth { get; set; } = 250;
        public int LabelHeight { get; set; } = 50;
        public Font LabelFont { get; set; } = new Font("Roboto", 16, FontStyle.Bold);

        private bool isHovered = false;

        public SidebarItem()
        {
            Initialize();
        }

        public SidebarItem(int borderRadius, Color panelBgColor, Color panelTextColor, int labelWidth, int labelHeight)
        {
            this.BorderRadius = borderRadius;
            this.PanelBgColor = panelBgColor;
            this.PanelTextColor = panelTextColor;
            this.LabelWidth = labelWidth;
            this.LabelHeight = labelHeight;
            Initialize();
        }

        private void Initialize()
        {
            this.AutoSize = false;
            this.Size = new Size(LabelWidth, LabelHeight);
            this.BackColor = Color.Transparent;
            this.ForeColor = PanelTextColor;
            this.Font = LabelFont;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Margin = new Padding(30, 5, 30, 5);
            this.Cursor = Cursors.Hand;

            //  hover
            MouseEnter += (s, e) =>
            {
                isHovered = true;
                Invalidate(); // vẽ lại
            };
            MouseLeave += (s, e) =>
            {
                isHovered = false;
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);  //Rectangle(int TopLeftPointX, int TopLeftPointY, int width, int height)

            using (GraphicsPath path = RoundedRect(rect, BorderRadius))
            {
                using (SolidBrush brush = new SolidBrush(isHovered ? HoverBgColor : PanelBgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                using (Pen pen = new Pen(Consts.BgColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            //// Vẽ text ////
            Rectangle textRect = new Rectangle(rect.X + 15, rect.Y, rect.Width - 15, rect.Height);

            TextRenderer.DrawText(
                e.Graphics,
                Text,
                LabelFont,
                textRect,
                isHovered ? HoverTextColor : PanelTextColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );
        }

        private GraphicsPath RoundedRect(Rectangle rectangle, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rectangle.X, rectangle.Y, d, d, 180, 90); // AddArc(x, y, width, height, startAngle, sweepAngle);
            path.AddArc(rectangle.Right - d, rectangle.Y, d, d, 270, 90);
            path.AddArc(rectangle.Right - d, rectangle.Bottom - d, d, d, 0, 90);
            path.AddArc(rectangle.X, rectangle.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
