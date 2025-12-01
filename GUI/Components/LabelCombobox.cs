using System;
using System.Drawing;
using System.Windows.Forms;
using HospitalManagerment.Utils;

namespace LayoutTest.GUIComponents
{
    internal class LableComboBox : Panel
    {
        public Label lbl;
        public ComboBox comboBox;
        public int PanelWidth { get; set; }
        public int PanelHeight { get; set; }

        public string LabelText
        {
            get => lbl.Text;
            set => lbl.Text = value;
        }

        public string TextValue
        {
            get => comboBox.SelectedItem?.ToString() ?? string.Empty;
            set
            {
                int index = comboBox.Items.IndexOf(value);
                if (index >= 0)
                    comboBox.SelectedIndex = index;
            }
        }

        public LableComboBox()
        {
            InitializeComponent(200, 100, "Label:");
        }

        public LableComboBox(int PanelWidth, int PanelHeight, string LabelText)
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

            comboBox = new ComboBox();
            comboBox.Dock = DockStyle.Fill;
            comboBox.Font = Consts.TextBoxFont;
            comboBox.ForeColor = Consts.FontColorA;
            comboBox.BackColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Standard;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox.ItemHeight = 24;
            comboBox.DrawItem += ComboBox_DrawItem;

            this.Controls.Add(comboBox);
            this.Controls.Add(lbl);
        }


        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox combo = sender as ComboBox;

            string text = combo.GetItemText(combo.Items[e.Index]);
            // --------------------

            // Phần vẽ màu giữ nguyên như cũ
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(155,155,155)), e.Bounds);
                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
                using (Brush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString(text, combo.Font, brush, e.Bounds, sf);
                }
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);

                StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center };
                using (Brush brush = new SolidBrush(Consts.FontColorA))
                {
                    e.Graphics.DrawString(text, combo.Font, brush, e.Bounds, sf);
                }
            }
        }

        public ComboBox GetComboBox()
        {
            return comboBox;
        }
    }
}