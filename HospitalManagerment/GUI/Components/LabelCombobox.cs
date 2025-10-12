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
            lbl.Height = Math.Max(45, height / 3);
            lbl.ForeColor = Consts.FontColorA;

            comboBox = new ComboBox();
            comboBox.Dock = DockStyle.Fill;
            comboBox.Font = Consts.TextBoxFont;
            comboBox.ForeColor = Consts.FontColorA;
            comboBox.BackColor = Color.White;
            comboBox.FlatStyle = FlatStyle.Standard;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList; 

            this.Controls.Add(comboBox);
            this.Controls.Add(lbl);
        }

        public void SetLabelFont(Font font)
        {
            lbl.Font = font;
        }

        public void SetComboBoxFont(Font font)
        {
            comboBox.Font = font;
        }

        public void SetLabelColor(Color color)
        {
            lbl.ForeColor = color;
        }

        public void SetComboBoxBackColor(Color color)
        {
            comboBox.BackColor = color;
        }

        public void SetComboBoxForeColor(Color color)
        {
            comboBox.ForeColor = color;
        }

        public void SetItems(params string[] items)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(items);
        }

        public void AddItem(string item)
        {
            comboBox.Items.Add(item);
        }

        public void ClearItems()
        {
            comboBox.Items.Clear();
        }

        public string GetSelectedItem()
        {
            return comboBox.SelectedItem?.ToString() ?? string.Empty;
        }

        public int GetSelectedIndex()
        {
            return comboBox.SelectedIndex;
        }

        public void SetSelectedIndex(int index)
        {
            if (index >= 0 && index < comboBox.Items.Count)
                comboBox.SelectedIndex = index;
        }
    }
}
