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
        public Color LanelBgColor { get; set; } = Consts.BgColor;
        public Color LanelTextColor { get; set; } = Consts.FontColorA;
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

        public SidebarItem(int borderRadius, Color lanelBgColor, Color lanelTextColor, int labelWidth, int labelHeight)
        {
            this.BorderRadius = borderRadius;
            this.LanelBgColor = lanelBgColor;
            this.LanelTextColor = lanelTextColor;
            this.LabelWidth = labelWidth;
            this.LabelHeight = labelHeight;
            Initialize();
        }

        private void Initialize()
        {
            this.AutoSize = false;
            this.Size = new Size(LabelWidth, LabelHeight);
            this.BackColor = Color.Transparent;
            this.ForeColor = LanelTextColor;
            this.Font = LabelFont;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Margin = new Padding(30, 5, 30, 5);
            this.Cursor = Cursors.Hand;

            //  hover
            MouseEnter += (s, e) => { isHovered = true; Invalidate(); };
            MouseLeave += (s, e) => { isHovered = false; Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);  //Rectangle(int TopLeftPointX, int TopLeftPointY, int width, int height)

            using (GraphicsPath path = RoundedRect(rect, BorderRadius))
            {
                using (SolidBrush brush = new SolidBrush(isHovered ? HoverBgColor : LanelBgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                using (Pen pen = new Pen(Consts.BgColor, 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            Rectangle textRect = new Rectangle(rect.X + 15, rect.Y, rect.Width - 15, rect.Height);
            TextRenderer.DrawText(
                e.Graphics,
                Text,
                LabelFont,
                textRect,
                isHovered ? HoverTextColor : LanelTextColor,
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
