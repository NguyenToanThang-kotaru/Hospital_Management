using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.BenhNhan
{
    public partial class BenhNhanPage : UserControl
    {
        public BenhNhanPage()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void roundedPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void CheckBoxCoBHYT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblCbcGioiTinh_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcGioiTinh.GetComboBox();

            if (cb.Items.Count == 0) 
            {
                cb.Items.Add("Nam");
                cb.Items.Add("Nữ");

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;

                    string text = cb.Items[ev.Index].ToString();
                    Color textColor = Color.FromArgb(125,125,125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }

        private void lblCbbTrangThaiDangKy_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbbTrangThaiDangKy.GetComboBox();

            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Đã hoàn thành");
                cb.Items.Add("Đã hủy");

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;

                    string text = cb.Items[ev.Index].ToString();
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }

        private void lblCbbHinhThucThanhToan_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbbHinhThucThanhToan.GetComboBox();

            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Tiền mặt");
                cb.Items.Add("Chuyển khoản");

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;

                    string text = cb.Items[ev.Index].ToString();
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }
    }
}
