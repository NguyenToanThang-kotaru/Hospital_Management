using System;
using System.Drawing;
using System.Windows.Forms;
using HospitalManagerment.Utils;

namespace LayoutTest.GUIComponents
{
    internal class LableTextBox : Panel
    {
        public Label lbl;
        public TextBox txt;
        public int PanelWidth { get; set; }
        public int PanelHeight { get; set; }

        public string LabelText
        {
            get => lbl.Text;
            set => lbl.Text = value;
        }

        public string TextValue
        {
            get => txt.Text;
            set => txt.Text = value;
        }

        private bool _isPassword = false;
        public bool IsPassword
        {
            get => _isPassword;
            set
            {
                _isPassword = value;
                txt.UseSystemPasswordChar = value; 
            }
        }

        public LableTextBox()
        {
            InitializeComponent(200, 80, "Label:");
        }

        public LableTextBox(int PanelWidth, int PanelHeight, string LabelText)
        {
            InitializeComponent(PanelWidth, PanelHeight, LabelText);
        }

        private void InitializeComponent(int width, int height, string labelText)
        {
            this.PanelWidth = width;
            this.PanelHeight = height;
            this.Size = new Size(width, height);
            this.BackColor = Color.Transparent;

            lbl = new Label();
            lbl.Text = labelText;
            lbl.Font = Consts.TextBoxFont;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Dock = DockStyle.Top;
            lbl.Height = Math.Max(40, height / 3); 
            lbl.ForeColor = Consts.FontColorA;

            txt = new TextBox();
            txt.Font = Consts.TextBoxFont;
            txt.Dock = DockStyle.Fill;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = Consts.FontColorA;

            this.Controls.Add(txt);
            this.Controls.Add(lbl);
        }

        public void SetLabelFont(Font font)
        {
            lbl.Font = font;
        }

        public void SetTextBoxFont(Font font)
        {
            txt.Font = font;
        }

        public void SetLabelColor(Color color)
        {
            lbl.ForeColor = color;
        }

        public void SetTextBoxBackColor(Color color)
        {
            txt.BackColor = color;
        }

        public void SetTextBoxForeColor(Color color)
        {
            txt.ForeColor = color;
        }

        public void SetReadOnly(bool readOnly)
        {
            txt.ReadOnly = readOnly;
            txt.BackColor = readOnly ? Color.LightGray : Color.White;
        }
    }
}