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
        //string errorMessage;
        //bool chkHasBHYT = true;

        //// --- Tạo bệnh nhân ---
        //var patient = new PatientDTO
        //{
        //    SoCCCD = "079105008934",
        //    TenBN = "Phạm Quốc z",
        //    NgaySinh = "2001-03-10",
        //    GioiTinh = "Nam",
        //    SdtBN = "0978123987",
        //    DiaChi = "P. Tân Hưng, Q.7, TP.HCM",
        //};

        //HealthInsuranceDTO bhyt = null;

        //// --- Nếu có BHYT ---
        //if (chkHasBHYT)
        //{
        //    string soBHYT = "DN38765432"; // ký tự thứ 3 = 3 → 80%
        //    HealthInsuranceBUS bhytBus = new HealthInsuranceBUS();
        //    string mucHuong = bhytBus.TinhMucHuongTuSoBHYT(soBHYT);

        //    bhyt = new HealthInsuranceDTO
        //    {
        //        SoBHYT = soBHYT,
        //        NgayCap = "2021-07-20",
        //        NgayHetHan = "2026-07-20",
        //        MucHuong = mucHuong,
        //    };
        //}

        //// --- Gọi BUS để thêm bệnh nhân + (tùy chọn) BHYT ---
        //var service = new PatientBUS();
        //if (service.AddPatient(patient, bhyt, out errorMessage))
        //    MessageBox.Show("✅ Thêm bệnh nhân thành công!");
        //else
        //    MessageBox.Show("❌ Lỗi: " + errorMessage);

        var patientBUS = new PatientBUS();
        PatientDTO oldPatient = patientBUS.GetPatientById("082193004512", out string errorMessage);

        var heathInsuranceBUS = new HealthInsuranceBUS();
        HealthInsuranceDTO oldBHYT = heathInsuranceBUS.GetHealthInsuranceByID(oldPatient.SoBHYT, out errorMessage);

        var newPatient = new PatientDTO
        {
            SoCCCD = oldPatient.SoCCCD,
            TenBN = oldPatient.TenBN,
            NgaySinh = oldPatient.NgaySinh,
            GioiTinh = oldPatient.GioiTinh,
            SdtBN = oldPatient.SdtBN,
            DiaChi = "P. Nguyen Thai Binh, Q.1, TP.HCM",
        };
        

        HealthInsuranceDTO newBHYT = null;
        bool temp = true;
        if (temp)
        {
            // Nếu bệnh nhân chưa có BHYT hoặc muốn đổi thẻ
            string soBHYT = oldBHYT == null ? "DN48765432" : oldBHYT.SoBHYT;
            newBHYT = new HealthInsuranceDTO
            {
                SoBHYT = soBHYT, // giữ hoặc đổi
                NgayCap = "2022-07-20",
                NgayHetHan = "2027-07-20",
                MucHuong = heathInsuranceBUS.TinhMucHuongTuSoBHYT(soBHYT),
            };
        }

        // 5️⃣ Gọi cập nhật
        bool result = patientBUS.UpdatePatient(newPatient, newBHYT, oldPatient.SoCCCD, out errorMessage);

        // 6️⃣ Kết quả
        if (result)
            Console.WriteLine("✅ Cập nhật bệnh nhân thành công!");
        else
            Console.WriteLine($"❌ Cập nhật thất bại: {errorMessage}");

    }
}