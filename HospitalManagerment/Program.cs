using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
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



//class Program
//{
//    static void Main()
//    {
//        PatientBUS bus = new PatientBUS();

//        //var patient = new PatientDTO
//        //{
//        //    SoCCCD = "001234567899",
//        //    TenBN = "Nguyen Van Cao",
//        //    SoBHYT = "",
//        //    NgaySinh = "2000-5-20",
//        //    GioiTinh = "Nam",
//        //    SdtBN = "0912345678",
//        //    DiaChi = "123 Đường ABC",
//        //    TrangThaiXoa = "0",
//        //};

//        //if (bus.InsertPatient(patient, out string error))
//        //    Console.WriteLine("✅ Thêm bệnh nhân thành công!");
//        //else
//        //    Console.WriteLine($"❌ Lỗi: {error}");

//        //List<PatientDTO> patients = bus.SearchPatient("Nguyen", out string errorMessage);
//        //if (patients.Count == 0)
//        //{
//        //    Console.WriteLine("Không tìm thấy bệnh nhân nào!");
//        //}
//        //else
//        //{
//        //    foreach (var p in patients)
//        //    {
//        //        Console.WriteLine($"CCCD: {p.SoCCCD}, Tên: {p.TenBN}, Ngày sinh: {p.NgaySinh}, Giới tính: {p.GioiTinh}, SĐT: {p.SdtBN}, Địa chỉ: {p.DiaChi}");
//        //    }
//        //}
//        //if (bus.DeletePatient("001234567892", out string errorMessage))
//        //    Console.WriteLine("Xoa benh nhan thanh cong");
//        //else
//        //    Console.WriteLine($"❌ Lỗi: {errorMessage}");

//    }
//}