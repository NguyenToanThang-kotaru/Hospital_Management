//using HospitalManagerment.DAO;
//using HospitalManagerment.DTO;
//using HospitalManagerment.Utils;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HospitalManagerment.BUS
//{
//    internal class HealthInsuranceBUS
//    {
//        private HealthInsuranceDAO healthInsuranceDAO;

//        public HealthInsuranceBUS()
//        {
//            healthInsuranceDAO = new HealthInsuranceDAO();
//        }
//        public string TinhMucHuongTuSoBHYT(string soBHYT)
//        {
//            char kyTuThu3 = soBHYT[2];
//            if (kyTuThu3 == '1' || kyTuThu3 == '4')
//                return "100%";
//            else if (kyTuThu3 == '2')
//                return "95%";
//            else if (kyTuThu3 == '3')
//                return "80%";
//            else
//                return "null";
//        }
//        private bool ValidateHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
//        {
//            errorMessage = "";

//            if (!Validators.IsEmpty(healthInsurance.SoBHYT))
//            {
//                if (!Validators.IsValidBHYT(healthInsurance.SoBHYT))
//                {
//                    errorMessage = "Số BHYT không hợp lệ (VD: DN19512345)";
//                    return false;
//                }
//                else if (healthInsuranceDAO.IsDuplicateBHYT(healthInsurance.SoBHYT))
//                {
//                    errorMessage = "Số BHYT này đã tồn tại trong hệ thống";
//                    return false;
//                }
//            }

//            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
//            {
//                errorMessage = "Ngày cấp không hợp lệ";
//                return false;
//            }

//            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
//            {
//                errorMessage = "Ngày hết hạn không hợp lệ";
//                return false;
//            }


//            if (healthInsurance.MucHuong == "null")
//            {
//                errorMessage = "Số BHYT không hợp lệ. Vui lòng kiểm tra lại!";
//                return false;
//            }
//            return true;
//        }

//        public HealthInsuranceDTO GetHealthInsuranceByID(string soBHYT, out string errorMessage)
//        {
//            return healthInsuranceDAO.GetHealthInsuranceById(soBHYT, out errorMessage);
//        }

//        public bool AddHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
//        {
//            if (!ValidateHealthInsurance(healthInsurance, out errorMessage))
//            {
//                return false;
//            }
//            return healthInsuranceDAO.AddHealthInsurance(healthInsurance, out errorMessage);
//        }

//        public bool UpdateHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
//        {
//            if (!ValidateHealthInsurance(healthInsurance, out errorMessage))
//            {
//                return false;
//            }
//            return healthInsuranceDAO.UpdateHealthInsurance(healthInsurance, out errorMessage);
//        }

//        public bool DeleteHealthInsurance(string soBHYT, out string errorMessage)
//        {
//            return healthInsuranceDAO.DeleteHealthInsurance(soBHYT, out errorMessage);
//        }
//    }
//}

using HM.DAO;
using HM.DTO;
using HM.Utils;
using System;
using System.Globalization;

namespace HM.BUS
{
    public class HealthInsuranceBUS
    {
        private HealthInsuranceDAO healthInsuranceDAO;

        public HealthInsuranceBUS()
        {
            healthInsuranceDAO = new HealthInsuranceDAO();
        }

        public string TinhMucHuongTuSoBHYT(string soBHYT)
        {
            char kyTuThu3 = soBHYT[2];
            if (kyTuThu3 == '1' || kyTuThu3 == '4')
                return "100%";
            else if (kyTuThu3 == '2')
                return "95%";
            else if (kyTuThu3 == '3')
                return "80%";
            else
                return "null";
        }

        private void ValidateHealthInsurance(HealthInsuranceDTO healthInsurance)
        {
            if (Validators.IsEmpty(healthInsurance.SoBHYT))
                throw new ArgumentException("Số BHYT không được để trống");

            if (!Validators.IsValidBHYT(healthInsurance.SoBHYT))
                throw new ArgumentException("Số BHYT không hợp lệ (VD: DN19512345)");

            //if (healthInsuranceDAO.IsDuplicateBHYT(healthInsurance.SoBHYT))
            //    throw new ArgumentException("Số BHYT này đã tồn tại trong hệ thống");

            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
                throw new ArgumentException("Ngày cấp không hợp lệ");

            if (!Validators.IsValidDate(healthInsurance.NgayHetHan.ToString()))
                throw new ArgumentException("Ngày hết hạn không hợp lệ");

            DateTime dNgayCap = DateTime.ParseExact(healthInsurance.NgayCap.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime dNgayHetHan = DateTime.ParseExact(healthInsurance.NgayHetHan.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            if (dNgayHetHan <= dNgayCap)
                throw new ArgumentException("Ngày hết hạn phải sau ngày cấp");

            if (healthInsurance.MucHuong == "null")
                throw new ArgumentException("Số BHYT không hợp lệ. Vui lòng kiểm tra lại!");
        }

        public HealthInsuranceDTO GetHealthInsuranceByID(string soBHYT)
        {
            var bhyt = healthInsuranceDAO.GetHealthInsuranceById(soBHYT);
            if (bhyt == null)
                throw new Exception("Không tìm thấy BHYT!");
            return bhyt;
        }

        public bool AddHealthInsurance(HealthInsuranceDTO healthInsurance)
        {
            if (healthInsuranceDAO.IsDuplicateBHYT(healthInsurance.SoBHYT))
                throw new ArgumentException("Số BHYT này đã tồn tại trong hệ thống");
            ValidateHealthInsurance(healthInsurance);
            if (!healthInsuranceDAO.AddHealthInsurance(healthInsurance))
                throw new Exception("Thêm BHYT thất bại!");
            return true;
        }

        public bool UpdateHealthInsurance(HealthInsuranceDTO healthInsurance)
        {
            ValidateHealthInsurance(healthInsurance);
            if (!healthInsuranceDAO.UpdateHealthInsurance(healthInsurance))
                throw new Exception("Cập nhật BHYT thất bại!");
            return true;
        }

        public bool DeleteHealthInsurance(string soBHYT)
        {
            if (!healthInsuranceDAO.DeleteHealthInsurance(soBHYT))
                throw new Exception("Xóa BHYT thất bại!");
            return true;
        }
    }
}

