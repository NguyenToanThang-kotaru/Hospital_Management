using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class PatientBUS
    {
        private PatientDAO patientDAO;

        public PatientBUS()
        {
            patientDAO = new PatientDAO();
        }
        private bool ValidateInsertPatient(PatientDTO patient, out string errorMessage)
        {
            errorMessage = "";
            // --- Kiểm tra CCCD ---
            if (!Validators.CheckEmpty(patient.SoCCCD, "số CCCD", out errorMessage)) return false;
            else if (!Validators.IsValidCCCD(patient.SoCCCD))
            {
                errorMessage = "CCCD phải gồm đúng 12 chữ số";
                return false;
            }
            else if (patientDAO.IsDuplicateCCCD(patient.SoCCCD))
            {
                errorMessage = "Số CCCD này đã tồn tại trong hệ thống";
                return false;
            }
            return this.ValidateUpdatePatient(patient, out errorMessage);
        }
        private bool ValidateUpdatePatient(PatientDTO patient, out string errorMessage)
        {
            errorMessage = "";

            // --- Kiểm tra tên bệnh nhân ---
            if (!Validators.CheckEmpty(patient.TenBN, "tên bệnh nhân", out errorMessage)) return false;
        

            // --- Kiểm tra ngày sinh ---
            if (!Validators.IsValidDate(patient.NgaySinh.ToString()))
            {
                errorMessage = "Ngày sinh không hợp lệ";
                return false;
            }

            // --- Kiểm tra giới tính ---
            if (!Validators.CheckEmpty(patient.GioiTinh,"", out errorMessage, "Vui lòng chọn giới tính."))
            {
                return false;
            }

            // --- Kiểm tra SĐT ---
            if (!Validators.IsValidPhone(patient.SdtBN))
            {
                errorMessage = "Số điện thoại không hợp lệ";
                return false;
            }

            // --- Kiểm tra địa chỉ ---
            if (!Validators.CheckEmpty(patient.DiaChi, "địa chỉ", out errorMessage)) return false;

            return true;
        }

        public List<PatientDTO> SearchPatient(string keyword, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                if (Validators.IsEmpty(keyword))
                {
                    errorMessage = "Vui lòng nhập thông tin cần tìm (tên, CCCD hoặc BHYT)";
                    return new List<PatientDTO>();
                }

                // Gọi xuống DAO để lấy danh sách bệnh nhân phù hợp
                var result = patientDAO.SearchPatientBy(keyword);

                if (result.Count == 0)
                {
                    errorMessage = "Không tìm thấy bệnh nhân phù hợp";
                }

                return result;
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi tìm kiếm bệnh nhân: {ex.Message}";
                return new List<PatientDTO>();
            }
        }

        public List<PatientDTO> GetAllPatients()
        {
            return patientDAO.GetAllPatients();
        }

        public PatientDTO GetPatientById(string soCCCD, out string errorMessage)
        {
           return patientDAO.GetPatientById(soCCCD, out errorMessage);
        }

        public bool AddPatient(PatientDTO patient, out string errorMessage)
        {
            if (!ValidateInsertPatient(patient, out errorMessage))
                return false;

            return patientDAO.AddPatient(patient, out errorMessage);
        }

        public bool UpdatePatient(PatientDTO patient, out string errorMessage)
        {
            if (!ValidateUpdatePatient(patient, out errorMessage))
                return false;

            return patientDAO.UpdatePatient(patient, out errorMessage);
        }

        public bool DeletePatient(string soCCCD, out string errorMessage)
        {
            errorMessage = string.Empty;
            DialogResult confirm = MessageBox.Show(
                   "Bạn có chắc chắn muốn xóa bệnh nhân này không?",
                   "Xác nhận xóa",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning
               );

            if (confirm == DialogResult.No)
            {
                Console.WriteLine("Hủy thao tác xóa bệnh nhân.");
                return false;
            }

            return patientDAO.DeletePatient(soCCCD, out errorMessage);
        }
    }
}
