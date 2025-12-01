using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HospitalManagerment.Utils;

namespace HospitalManagerment.GUI.Components
{
    internal class SearchBar : Panel
    {
        private TextBox txtSearch;
        private PictureBox picSearchIcon;

        private Color _borderColor = Color.FromArgb(125, 125, 125);
        private int _borderRadius = 10;
        private int _borderWidth = 1;
        private Color _iconColor = Consts.FontColorB;

        // Sự kiện public cho thay đổi nội dung
        public event EventHandler SearchTextChanged;

        public SearchBar()
        {
            InitializeComponent();
            SetupControls();
            txtSearch.TextChanged += TxtSearch_TextChanged;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                         ControlStyles.UserPaint |
                         ControlStyles.ResizeRedraw |
                         ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.BackColor = Color.White;
            txtSearch.Font = new Font("Roboto", 10F, FontStyle.Regular);
            txtSearch.ForeColor = Color.FromArgb(64, 64, 64);

            picSearchIcon = new PictureBox();
            picSearchIcon.BackColor = Color.Transparent;
            picSearchIcon.SizeMode = PictureBoxSizeMode.Zoom;

            this.Controls.Add(txtSearch);
            this.Controls.Add(picSearchIcon);
            this.Size = new Size(500, 40);
            this.BackColor = Color.Transparent;
        }

        private void SetupControls()
        {
            SetSearchIcon();
            ArrangeControls();
        }

        private void SetSearchIcon()
        {
            Bitmap icon = new Bitmap(20, 20);
            using (Graphics g = Graphics.FromImage(icon))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (Pen pen = new Pen(_iconColor, 2))
                {
                    g.DrawEllipse(pen, 2, 2, 12, 12);
                    g.DrawLine(pen, 12, 12, 18, 18);
                }
            }

            picSearchIcon.Image = icon;
        }

        private void ArrangeControls()
        {
            int iconSize = 30;
            int padding = 10;

            picSearchIcon.Size = new Size(iconSize, iconSize);
            picSearchIcon.Location = new Point(
                this.Width - iconSize - padding,
                (this.Height - iconSize) / 2
            );

            txtSearch.Location = new Point(padding, (this.Height - txtSearch.Height) / 2);
            txtSearch.Size = new Size(
                this.Width - (iconSize + padding * 3),
                txtSearch.Height
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ArrangeControls();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (GraphicsPath path = CreateRoundedRectanglePath(new Rectangle(0, 0, Width - 1, Height - 1), _borderRadius))
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }

            using (GraphicsPath path = CreateRoundedRectanglePath(new Rectangle(0, 0, Width - 1, Height - 1), _borderRadius))
            using (Pen pen = new Pen(_borderColor, _borderWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            radius = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();

            return path;
        }

        [Category("Appearance")]
        [Description("Màu viền của search bar")]
        [DefaultValue(typeof(Color), "125, 125, 125")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Độ bo góc của search bar")]
        [DefaultValue(10)]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Độ dày viền")]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                this.Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Màu icon tìm kiếm")]
        public Color IconColor
        {
            get { return _iconColor; }
            set
            {
                _iconColor = value;
                SetSearchIcon();
                this.Invalidate();
            }
        }

        [Browsable(false)]
        public string SearchText
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        // Gọi hàm này khi text thay đổi
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTextChanged?.Invoke(this, e);
        }
    }
}
