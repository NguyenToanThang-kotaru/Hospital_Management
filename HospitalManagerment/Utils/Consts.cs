using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.Utils
{
    public static class Consts
    {
        // Màu background
        public static Color BgColor = Color.FromArgb(255, 255, 255); // trắng
        public static Color FormBgColor = Color.FromArgb(248, 248, 248);  // xám nhạt
        public static Color HeaderBgColor = Color.FromArgb(21, 77, 146); // xanh

        // Màu chữ
        public static Color FontColorA = Color.FromArgb(125, 125, 125); // xám 
        public static Color FontColorB = Color.FromArgb(52, 211, 153);  // xanh lá dạ quang

        // Màu table
        public static Color TblHeaderColor = Color.FromArgb(247, 255, 254);
        public static Color TblRowColor = Color.FromArgb(255, 255, 255);

        // Màu menu button focus
        public static Color MenuBtnFocusFontColor = Color.FromArgb(52, 211, 153);
        public static Color MenuBtnFocusBgColor = Color.FromArgb(243, 251, 249);

        // Font mặc định
        public static Font MainFont = new Font("Tamoha", 12, FontStyle.Bold);
        public static Font TextBoxFont = new Font("Roboto", 12, FontStyle.Bold);

    }

    public static class Helpers
    {
        public static void ClearTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb) tb.Clear();
                else ClearTextBoxes(c);
            }
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool ConfirmExit()
        {
            return MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                                   "Xác nhận thoát",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question)
                                   == DialogResult.Yes;
        }
    }

    public static class Validators
    {
        public static bool IsEmpty(string input) =>
            string.IsNullOrWhiteSpace(input);

        public static bool IsNumber(string input) =>
            double.TryParse(input, out _);

        public static bool IsValidPhone(string phone) =>
            Regex.IsMatch(phone, @"^(0[0-9]{9,10})$");

        public static bool IsValidCCCD(string cccd) =>
            Regex.IsMatch(cccd, @"^[0-9]{12}$");

        public static bool IsValidBHYT(string bhyt) =>
            Regex.IsMatch(bhyt, @"^[A-Z]{2}[0-9]{8,10}$");

        public static bool IsValidDate(string date)
        {
            return DateTime.TryParse(date, out DateTime d) && d <= DateTime.Today;
        }

        public static bool IsValidGender(string gender)
        {
            return gender.Equals("Nam", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Nu", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Nữ", StringComparison.OrdinalIgnoreCase);
        }

        public static bool ValidateTextBox(TextBox tb, ErrorProvider ep, string fieldName)
        {
            if (IsEmpty(tb.Text))
            {
                ep.SetError(tb, $"{fieldName} không được để trống");
                return false;
            }

            ep.SetError(tb, "");
            return true;
        }

        // ======= KIỂM TRA DỮ LIỆU BỆNH NHÂN =======
        public static bool ValidatePatient(
            string soCCCD, string tenBN, string soBHYT,
            string ngaySinh, string gioiTinh, string sdtBN, string diaChi,
            ErrorProvider ep,
            TextBox txtCCCD, TextBox txtTen, TextBox txtBHYT,
            DateTimePicker dtpNgaySinh, ComboBox cboGioiTinh,
            TextBox txtSdt, TextBox txtDiaChi)
        {
            bool ok = true;

            // 1️⃣ Kiểm tra trống
            if (!ValidateTextBox(txtCCCD, ep, "Số CCCD")) ok = false;
            if (!ValidateTextBox(txtTen, ep, "Tên bệnh nhân")) ok = false;
            if (!ValidateTextBox(txtBHYT, ep, "Số BHYT")) ok = false;
            if (!ValidateTextBox(txtSdt, ep, "Số điện thoại")) ok = false;
            if (!ValidateTextBox(txtDiaChi, ep, "Địa chỉ")) ok = false;

            // 2️⃣ Kiểm tra CCCD
            if (!IsValidCCCD(soCCCD))
            {
                ep.SetError(txtCCCD, "Số CCCD phải gồm đúng 12 chữ số");
                ok = false;
            }

            // 3️⃣ Kiểm tra BHYT
            if (!IsValidBHYT(soBHYT))
            {
                ep.SetError(txtBHYT, "Số BHYT phải gồm 2 chữ cái đầu và 8–10 số sau (VD: DN19512345)");
                ok = false;
            }

            // 4️⃣ Kiểm tra ngày sinh
            if (!IsValidDate(ngaySinh))
            {
                ep.SetError(dtpNgaySinh, "Ngày sinh không hợp lệ");
                ok = false;
            }

            // 5️⃣ Kiểm tra giới tính
            if (string.IsNullOrWhiteSpace(gioiTinh) || !IsValidGender(gioiTinh))
            {
                ep.SetError(cboGioiTinh, "Giới tính phải là Nam hoặc Nữ");
                ok = false;
            }

            // 6️⃣ Kiểm tra SĐT
            if (!IsValidPhone(sdtBN))
            {
                ep.SetError(txtSdt, "Số điện thoại không hợp lệ (VD: 0901234567)");
                ok = false;
            }

            // 7️⃣ Địa chỉ
            if (diaChi.Length < 2)
            {
                ep.SetError(txtDiaChi, "Địa chỉ quá ngắn");
                ok = false;
            }

            return ok;
        }
    }
}
}
