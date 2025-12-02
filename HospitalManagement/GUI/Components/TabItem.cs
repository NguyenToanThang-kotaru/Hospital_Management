using HM.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HM.GUI.Components
{
    internal class TabItem : Label
    {
        public Color LabelTextColor { get; set; } = Consts.FontColorA;
        public Color HoverBorderColor { get; set; } = Consts.MenuBtnFocusFontColor;
        public int LabelWidth { get; set; } = 160;
        public int LabelHeight { get; set; } = 40;
        public Font LabelFont { get; set; } = new Font("Roboto", 12, FontStyle.Bold);

        private bool isHovered = false;

        public TabItem()
        {
            Initialize();
        }

        public TabItem(Color labelTextColor, int labelWidth, int labelHeight)
        {
            LabelTextColor = labelTextColor;
            LabelWidth = labelWidth;
            LabelHeight = labelHeight;
            Initialize();
        }

        private void Initialize()
        {
            this.AutoSize = false;
            this.Size = new Size(LabelWidth, LabelHeight);
            this.BackColor = Color.Transparent;
            this.ForeColor = LabelTextColor;
            this.Font = LabelFont;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Margin = new Padding(10, 10, 10, 10);
            this.Cursor = Cursors.Hand;

            MouseEnter += (s, e) => { isHovered = true; Invalidate(); };
            MouseLeave += (s, e) => { isHovered = false; Invalidate(); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle textRect = new Rectangle(10, 0, Width - 10, Height);
            TextRenderer.DrawText(
                e.Graphics,
                Text,
                LabelFont,
                textRect,
                LabelTextColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left
            );

            if (isHovered)
            {
                using (Pen pen = new Pen(HoverBorderColor, 3))
                {
                    int y = Height - 3; 
                    e.Graphics.DrawLine(pen, 0, y, Width, y);
                }
            }
        }
    }
}
