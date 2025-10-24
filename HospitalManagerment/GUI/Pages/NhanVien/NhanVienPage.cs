using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.NhanVien
{
    public partial class NhanVienPage : UserControl
    {
        public NhanVienPage()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCbcChucVu_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcChucVu.GetComboBox();
            if (cb.Items.Count == 0) 
            {
                cb.Items.Add("Trưởng khoa");
                cb.Items.Add("Phó khoa");
                cb.Items.Add("Điều trị");
                cb.Items.Add("Nội trú");
                cb.Items.Add("Thực tập");

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

        private void lblCbcVaiTro_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcVaiTro.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Quản trị viên");
                cb.Items.Add("Kế toán");
                cb.Items.Add("Quản lý");
                cb.Items.Add("Nhân viên quầy");
                cb.Items.Add("Bác sĩ");
                cb.Items.Add("Điều dưỡng");
                cb.Items.Add("Bảo vệ");

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

        private void lblCbcKhoa_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcKhoa.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Khoa hành chính");       // Vai trò khác bác sĩ
                cb.Items.Add("Khoa khám bệnh (ngoại trú)"); // Nơi tiếp nhận ban đầu
                cb.Items.Add("Khoa nội");              
                cb.Items.Add("Khoa ngoại");           
                cb.Items.Add("Khoa nhi");              
                cb.Items.Add("Khoa sản");            
                cb.Items.Add("Khoa truyền nhiễm");    
                cb.Items.Add("Khoa cận lâm sàng");  

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
