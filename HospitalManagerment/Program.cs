using HospitalManagerment.GUI;
using HospitalManagerment.GUI.Login_Layout;
using HospitalManagerment.GUI.Main_Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Kích hoạt DPI aware
            SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Layout());
            //Application.Run(new Main_Layout());
        }
    }
}
//using System;
//using System.Collections.Generic;
//using HospitalManagerment.BUS;
//using HospitalManagerment.DTO;

//namespace TestBUS
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            AccountBUS bus = new AccountBUS();

//            try
//            {
//                List<AccountDTO> accounts = bus.GetAllAccount();

//                Console.WriteLine("=== DANH SÁCH TÀI KHOẢN ===");

//                if (accounts.Count == 0)
//                {
//                    Console.WriteLine("Không có tài khoản nào trong database!");
//                }
//                else
//                {
//                    foreach (var acc in accounts)
//                    {
//                        Console.WriteLine($"Tên đăng nhập: {acc.TenDangNhap}, " +
//                                          $"Mã quyền: {acc.MaQuyen}, " +
//                                          $"Mã nhân viên: {acc.MaNV}");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi khi lấy danh sách tài khoản: {ex.Message}");
//            }

//        }
//    }
//}
