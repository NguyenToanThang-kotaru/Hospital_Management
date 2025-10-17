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

//namespace HospitalManagerment
//{
//    internal static class Program
//    {
//        [DllImport("user32.dll")]
//        private static extern bool SetProcessDPIAware();
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            // Kích hoạt DPI aware
//            SetProcessDPIAware();

//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new Login_Layout());
//            //Application.Run(new Main_Layout());
//        }
//    }
//}


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



class Program
{
    static void Main()
    {
        string errorMessage;
        bool chkHasBHYT = true;
        var patient = new PatientDTO
        {
            SoCCCD = "075204007856",
            TenBN = "Trần Thị Hồng",
            NgaySinh = "1995-09-14",
            GioiTinh = "Nữ",
            SdtBN = "0905123456",
            DiaChi = "P. Linh Trung, TP. Thủ Đức",
        };

        HealthInsuranceDTO bhyt = null;

        if (chkHasBHYT)
        {
            bhyt = new HealthInsuranceDTO
            {
                SoBHYT = "DN9876543210",
                NgayCap = "2022-02-01",
                NgayHetHan = "2027-02-01",
                MucHuong = "90%",
                NoiDangKi = "Bệnh viện ĐH Y Dược TP.HCM"
            };
        }

        var service = new PatientWithHIBUS();
        if (service.AddPatientWithOptionalBHYT(patient, bhyt, out errorMessage))
            MessageBox.Show("Thêm bệnh nhân thành công!");
        else
            MessageBox.Show("Lỗi: " + errorMessage);

    }
}