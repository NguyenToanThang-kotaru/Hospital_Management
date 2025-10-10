using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Text;

namespace HospitalManagerment.GUI.Components
{
    internal class TabControlDesign : TabControl
    {
        private const int FIXED_TAB_WIDTH = 200;
        private const int TAB_HEIGHT = 45;

        private Font _tabFont;

        public TabControlDesign()
        {
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(FIXED_TAB_WIDTH, TAB_HEIGHT);
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            _tabFont = new Font("Roboto", 12f, FontStyle.Bold);
  
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = this.TabPages[e.Index];
            Rectangle tabBounds = this.GetTabRect(e.Index);

            // Draw background
            g.FillRectangle(Brushes.White, tabBounds);

            // Draw text - căn trái với padding
            Rectangle textBounds = new Rectangle(tabBounds.Left + 12, tabBounds.Top, tabBounds.Width - 12, tabBounds.Height - 7);
            TextRenderer.DrawText(g, tabPage.Text, _tabFont, textBounds,
                Color.FromArgb(125, 125, 125),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            // Draw bottom border for selected tab
            if (e.State == DrawItemState.Selected)
            {
                using (Pen borderPen = new Pen(Color.FromArgb(52, 211, 153), 3))
                {
                    g.DrawLine(borderPen,
                        tabBounds.Left + 8, tabBounds.Bottom - 2,
                        tabBounds.Right - 8, tabBounds.Bottom - 2);
                }
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _tabFont?.Dispose();
            base.Dispose(disposing);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new TabSizeMode SizeMode
        {
            get { return base.SizeMode; }
            set { base.SizeMode = TabSizeMode.Fixed; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size ItemSize
        {
            get { return base.ItemSize; }
            set { base.ItemSize = new Size(FIXED_TAB_WIDTH, TAB_HEIGHT); }
        }
    }
}