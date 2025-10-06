using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.Utils
{
    public static class Consts
    {
        // Màu background
        public static Color BgColor = Color.FromArgb(255, 255, 255);
        public static Color FormBgColor = Color.FromArgb(248, 248, 248);
        public static Color HeaderBgColor = Color.FromArgb(21, 77, 146);

        // Màu chữ
        public static Color FontColorA = Color.FromArgb(125, 125, 125);
        public static Color FontColorB = Color.FromArgb(52, 211, 153);

        // Màu table
        public static Color TblHeaderColor = Color.FromArgb(247, 255, 254);
        public static Color TblRowColor = Color.FromArgb(255, 255, 255);

        // Màu menu button focus
        public static Color MenuBtnFocusFontColor = Color.FromArgb(52, 211, 153);
        public static Color MenuBtnFocusBgColor = Color.FromArgb(243, 251, 249);

        // Font mặc định
        public static Font MainFont = new Font("Tamoha", 18, FontStyle.Bold);
        public static Font TextBoxFont = new Font("Roboto", 18, FontStyle.Bold);

    }
}
