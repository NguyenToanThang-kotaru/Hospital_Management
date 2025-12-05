using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.Utils
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
        public static Font TextBoxFont = new Font("Roboto", 13, FontStyle.Bold);

    }

    public static class Helpers
    {
        public static string MoneyFormater(decimal money)
        {
            return money.ToString("#,##0");

        }
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

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }

    public static class Validators
    {
        public static bool IsEmpty(string input) => string.IsNullOrWhiteSpace(input);

        public static bool IsNumber(string input) => double.TryParse(input, out _);

        public static bool IsValidPhone(string phone) => Regex.IsMatch(phone, @"^(0[0-9]{9,10})$");

        public static bool IsValidCCCD(string cccd) => Regex.IsMatch(cccd, @"^[0-9]{12}$");

        public static bool IsValidBHYT(string bhyt) => Regex.IsMatch(bhyt, @"^[A-Z]{2}[0-9]{8,10}$");


        public static bool IsValidDate(string date)
        {
            bool isFormatValid = DateTime.TryParseExact(
                date,
                "dd-MM-yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime d
            );

            return isFormatValid;
        }

        public static bool IsValidGender(string gender)
        {
            return gender.Equals("Nam", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Nu", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Nữ", StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckEmpty(string value, string fieldName, out string errorMessage, string customMessage = null)
        {
            if (Validators.IsEmpty(value))
            {
                errorMessage = !string.IsNullOrEmpty(customMessage)
                    ? customMessage
                    : $"Vui lòng nhập {fieldName}!";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
}
