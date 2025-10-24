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
        private bool ValidateHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
        {
            errorMessage = "";

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

            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
            {
                errorMessage = "Ngày cấp không hợp lệ";
                return false;
            }

            if (!Validators.IsValidDate(healthInsurance.NgayCap.ToString()))
            {
                errorMessage = "Ngày hết hạn không hợp lệ";
                return false;
            }


            if (healthInsurance.MucHuong == "null")
            {
                errorMessage = "Số BHYT không hợp lệ. Vui lòng kiểm tra lại!";
                return false;
            }
            return true;
        }

        public HealthInsuranceDTO GetHealthInsuranceByID(string soBHYT, out string errorMessage)
        {
            return healthInsuranceDAO.GetHealthInsuranceById(soBHYT, out errorMessage);
        }

        public bool AddHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
        {
            if (!ValidateHealthInsurance(healthInsurance, out errorMessage))
            {
                return false;
            }
            return healthInsuranceDAO.AddHealthInsurance(healthInsurance, out errorMessage);
        }

        public bool UpdateHealthInsurance(HealthInsuranceDTO healthInsurance, out string errorMessage)
        {
            if (!ValidateHealthInsurance(healthInsurance, out errorMessage))
            {
                return false;
            }
            return healthInsuranceDAO.UpdateHealthInsurance(healthInsurance, out errorMessage);
        }

        public bool DeleteHealthInsurance(string soBHYT, out string errorMessage)
        {
            return healthInsuranceDAO.DeleteHealthInsurance(soBHYT, out errorMessage);
        }
    }
}
