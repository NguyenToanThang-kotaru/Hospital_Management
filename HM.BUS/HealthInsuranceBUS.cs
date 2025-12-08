using HM.DAO.ADO;
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
            if (kyTuThu3 == '1' || kyTuThu3 == '2')
                return "100%";
            else if (kyTuThu3 == '3')
                return "95%";
            else if (kyTuThu3 == '4')
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

        public bool UpdateHealthInsurance(HealthInsuranceDTO healthInsurance, string oldSoBHYT)
        {
            ValidateHealthInsurance(healthInsurance);

            var oldHealthInsurance = healthInsuranceDAO.GetHealthInsuranceById(oldSoBHYT);
            if (oldHealthInsurance == null)
                throw new Exception("Không tìm thấy bảo hiểm y tế để cập nhật!");

            if (!healthInsuranceDAO.UpdateHealthInsurance(healthInsurance, oldSoBHYT))
                throw new Exception("Cập nhật BHYT thất bại!");
            return true;
        }

        public bool DeleteHealthInsurance(string soBHYT)
        {
            if (!healthInsuranceDAO.DeleteHealthInsurance(soBHYT))
                throw new Exception("Xóa BHYT thất bại!");
            return true;
        }

        public bool ExistsHealthInsurance(string soBHYT)
        {
            var healthInsurance = healthInsuranceDAO.GetHealthInsuranceById(soBHYT);
            return healthInsurance != null;
        }

    }
}

