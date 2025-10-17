using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.BUS
{
    internal class HealthInsuranceBUS
    {
        private HealthInsuranceDAO healthInsuranceDAO;

        public HealthInsuranceBUS()
        {
            healthInsuranceDAO = new HealthInsuranceDAO();
        }
        private bool ValidateHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
        {
            errorMessage = "";

            // --- Kiểm tra số BHYT (nếu có) ---
            if (!Validators.IsEmpty(healthInsurance.SoBHYT))
            {
                if (!Validators.IsValidBHYT(healthInsurance.SoBHYT))
                {
                    errorMessage = "Số BHYT không hợp lệ (VD: DN19512345)";
                    return false;
                }
                else if (healthInsuranceDAO.IsDuplicateBHYT(healthInsurance.SoBHYT))
                {
                    errorMessage = "Số BHYT này đã tồn tại trong hệ thống";
                    return false;
                }
            }

            // --- Kiểm tra ngày cấp ---
            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
            {
                errorMessage = "Ngày cấp không hợp lệ";
                return false;
            }

            // --- Kiểm tra ngày hết hạn ---
            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
            {
                errorMessage = "Ngày hết hạn không hợp lệ";
                return false;
            }

            // --- Kiểm tra SĐT ---
            if (!Validators.CheckEmpty(healthInsurance.NoiDangKi, "nơi đang ký", out errorMessage)) return false;

            // --- Kiểm tra địa chỉ ---
            if (!Validators.CheckEmpty(healthInsurance.MucHuong, "mức hưởng", out errorMessage)) return false;

            return true;
        }

        public bool AddHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
        {
            if (!ValidateHealthInsurance(healthInsurance, out errorMessage))
            {
                return false;
            }
            return healthInsuranceDAO.AddHealthInsurance(healthInsurance, out errorMessage);
        }
    }
}
