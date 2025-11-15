//using HospitalManagerment.DAO;
//using HospitalManagerment.DTO;
//using HospitalManagerment.Utils;
//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace HospitalManagerment.BUS
//{
//    internal class PatientBUS
//    {
//        private PatientDAO patientDAO;

//        public PatientBUS()
//        {
//            patientDAO = new PatientDAO();
//        }
//        private bool ValidateInsertPatient(PatientDTO patient, out string errorMessage)
//        {
//            errorMessage = "";
//            // --- Kiểm tra CCCD ---
//            if (!Validators.CheckEmpty(patient.SoCCCD, "số CCCD", out errorMessage)) return false;
//            else if (!Validators.IsValidCCCD(patient.SoCCCD))
//            {
//                errorMessage = "CCCD phải gồm đúng 12 chữ số";
//                return false;
//            }
//            else if (patientDAO.IsDuplicateCCCD(patient.SoCCCD))
//            {
//                errorMessage = "Số CCCD này đã tồn tại trong hệ thống";
//                return false;
//            }
//            return this.ValidateUpdatePatient(patient, out errorMessage);
//        }
//        private bool ValidateUpdatePatient(PatientDTO patient, out string errorMessage)
//        {
//            errorMessage = "";

//            // --- Kiểm tra tên bệnh nhân ---
//            if (!Validators.CheckEmpty(patient.TenBN, "tên bệnh nhân", out errorMessage)) return false;


//            // --- Kiểm tra ngày sinh ---
//            if (!Validators.IsValidDate(patient.NgaySinh.ToString()))
//            {
//                errorMessage = "Ngày sinh không hợp lệ";
//                return false;
//            }

//            // --- Kiểm tra giới tính ---
//            if (!Validators.CheckEmpty(patient.GioiTinh,"", out errorMessage, "Vui lòng chọn giới tính."))
//            {
//                return false;
//            }

//            // --- Kiểm tra SĐT ---
//            if (!Validators.IsValidPhone(patient.SdtBN))
//            {
//                errorMessage = "Số điện thoại không hợp lệ";
//                return false;
//            }

//            // --- Kiểm tra địa chỉ ---
//            if (!Validators.CheckEmpty(patient.DiaChi, "địa chỉ", out errorMessage)) return false;

//            return true;
//        }

//        public List<PatientDTO> SearchPatient(string keyword, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                if (Validators.IsEmpty(keyword))
//                {
//                    errorMessage = "Vui lòng nhập thông tin cần tìm (tên, CCCD hoặc BHYT)";
//                    return new List<PatientDTO>();
//                }

//                // Gọi xuống DAO để lấy danh sách bệnh nhân phù hợp
//                var result = patientDAO.SearchPatientBy(keyword);

//                if (result.Count == 0)
//                {
//                    errorMessage = "Không tìm thấy bệnh nhân phù hợp";
//                }

//                return result;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Lỗi khi tìm kiếm bệnh nhân: {ex.Message}";
//                return new List<PatientDTO>();
//            }
//        }

//        public List<PatientDTO> GetAllPatients()
//        {
//            return patientDAO.GetAllPatients();
//        }

//        public PatientDTO GetPatientById(string soCCCD, out string errorMessage)
//        {
//           return patientDAO.GetPatientById(soCCCD, out errorMessage);
//        }

//        public bool AddPatient(PatientDTO patient, HealthInsuranceDTO bhyt, out string errorMessage)
//        {
//            if (!ValidateInsertPatient(patient, out errorMessage))
//                return false;
//            HealthInsuranceBUS bhytBUS = new HealthInsuranceBUS();
//            if (bhyt != null)
//            {
//                if (!bhytBUS.AddHealthInsurance(bhyt, out errorMessage))
//                    return false;

//                patient.SoBHYT = bhyt.SoBHYT;
//            }
//            return patientDAO.AddPatient(patient, out errorMessage);
//        }

//        public bool UpdatePatient(PatientDTO patient, HealthInsuranceDTO bhyt, string oldSoCCCD, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            //Validate thông tin bệnh nhân ---
//            if (!ValidateUpdatePatient(patient, out errorMessage))
//                return false;

//            //Lấy thông tin bệnh nhân hiện tại để xác định trạng thái BHYT ---
//            var oldPatient = patientDAO.GetPatientById(oldSoCCCD, out string getMsg);
//            if (oldPatient == null)
//            {
//                errorMessage = "Không tìm thấy bệnh nhân để cập nhật!";
//                return false;
//            }

//            HealthInsuranceBUS bhytBUS = new HealthInsuranceBUS();

//            //Xử lý logic liên quan đến BHYT
//            try
//            {
//                if (bhyt != null)
//                {
//                    // 🧠 Nếu bệnh nhân đã có BHYT trước đó → cập nhật lại BHYT
//                    if (!string.IsNullOrEmpty(oldPatient.SoBHYT))
//                    {
//                        // Nếu thay đổi số BHYT → cần check trùng
//                        if (bhyt.SoBHYT != oldPatient.SoBHYT)
//                        {
//                            // Thêm mới BHYT khác (trường hợp đổi thẻ)
//                            if (!bhytBUS.AddHealthInsurance(bhyt, out errorMessage))
//                                return false;
//                        }
//                        else
//                        {
//                            // Cập nhật lại thông tin thẻ cũ
//                            if (!bhytBUS.UpdateHealthInsurance(bhyt, out errorMessage))
//                                return false;
//                        }
//                    }
//                    else
//                    {
//                        //Nếu trước đó chưa có BHYT → thêm mới
//                        if (!bhytBUS.AddHealthInsurance(bhyt, out errorMessage))
//                            return false;
//                    }

//                    patient.SoBHYT = bhyt.SoBHYT; // Gán lại mã BHYT
//                }
//                else
//                {
//                    //Nếu người dùng không nhập gì cho BHYT, thì giữ nguyên
//                    patient.SoBHYT = oldPatient.SoBHYT;
//                }

//                bool result = patientDAO.UpdatePatient(patient, oldSoCCCD, out errorMessage);

//                return result;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Lỗi khi cập nhật bệnh nhân: {ex.Message}";
//                return false;
//            }
//        }


//        public bool DeletePatient(string soCCCD, out string errorMessage)
//        {
//            errorMessage = string.Empty;
//            DialogResult confirm = MessageBox.Show(
//                   "Bạn có chắc chắn muốn xóa bệnh nhân này không?",
//                   "Xác nhận xóa",
//                   MessageBoxButtons.YesNo,
//                   MessageBoxIcon.Warning
//               );

//            if (confirm == DialogResult.No)
//            {
//                Console.WriteLine("Hủy thao tác xóa bệnh nhân.");
//                return false;
//            }

//            return patientDAO.DeletePatient(soCCCD, out errorMessage);
//        }
//    }
//}

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
        private bool ValidateInsertPatient(PatientDTO patient)
        {
            // --- Kiểm tra CCCD ---
            string errorMessage = "";
            if (!Validators.CheckEmpty(patient.SoCCCD, "số CCCD", out errorMessage)) throw new ArgumentException(errorMessage);
            if (!Validators.IsValidCCCD(patient.SoCCCD)) throw new ArgumentException("CCCD phải gồm đúng 12 chữ số");
            if (patientDAO.IsDuplicateCCCD(patient.SoCCCD)) throw new ArgumentException("Số CCCD này đã tồn tại trong hệ thống");
            ValidateUpdatePatient(patient);
            return true;
        }
        private bool ValidateUpdatePatient(PatientDTO patient)
        {
            string errorMessage = "";

            if (!Validators.CheckEmpty(patient.TenBN, "tên bệnh nhân", out errorMessage)) throw new ArgumentException(errorMessage);
            if (!Validators.IsValidDate(patient.NgaySinh.ToString())) throw new ArgumentException("Ngày sinh không hợp lệ");
            if (!Validators.CheckEmpty(patient.GioiTinh, "", out errorMessage, "Vui lòng chọn giới tính.")) throw new ArgumentException(errorMessage);
            if (!Validators.IsValidPhone(patient.SdtBN)) throw new ArgumentException("Số điện thoại không hợp lệ");
            if (!Validators.CheckEmpty(patient.DiaChi, "địa chỉ", out errorMessage)) throw new ArgumentException(errorMessage);

            return true;
        }

        public List<PatientDTO> SearchPatient(string keyword)
        {
            if (Validators.IsEmpty(keyword))
                throw new ArgumentException("Vui lòng nhập thông tin cần tìm (tên, CCCD hoặc BHYT)");

            var result = patientDAO.SearchPatientBy(keyword);

            if (result.Count == 0)
                throw new Exception("Không tìm thấy bệnh nhân phù hợp");

            return result;
        }

        public List<PatientDTO> GetAllPatients()
        {
            return patientDAO.GetAllPatients();
        }

        public PatientDTO GetPatientById(string soCCCD)
        {
            var patient = patientDAO.GetPatientById(soCCCD);
            if (patient == null)
                throw new Exception("Không tìm thấy bệnh nhân!");
            return patient;
        }

        public bool AddPatient(PatientDTO patient, HealthInsuranceDTO bhyt)
        {
            ValidateInsertPatient(patient);

            HealthInsuranceBUS bhytBUS = new HealthInsuranceBUS();
            if (bhyt != null)
            {
                if (!bhytBUS.AddHealthInsurance(bhyt))
                    throw new Exception("Thêm BHYT thất bại!");

                patient.SoBHYT = bhyt.SoBHYT;
            }
            else
            {
                patient.SoBHYT = ""; // gán rỗng nếu không có BHYT
            }

            if (!patientDAO.AddPatient(patient))
                throw new Exception("Không thể thêm bệnh nhân vào cơ sở dữ liệu!");

            return true;
        }

        public bool UpdatePatient(PatientDTO patient, HealthInsuranceDTO bhyt, string oldSoCCCD)
        {
            ValidateUpdatePatient(patient);

            var oldPatient = patientDAO.GetPatientById(oldSoCCCD);
            if (oldPatient == null)
                throw new Exception("Không tìm thấy bệnh nhân để cập nhật!");

            HealthInsuranceBUS bhytBUS = new HealthInsuranceBUS();

            if (bhyt != null)
            {
                if (!string.IsNullOrEmpty(oldPatient.SoBHYT))
                {
                    if (bhyt.SoBHYT != oldPatient.SoBHYT)
                    {
                        if (!bhytBUS.AddHealthInsurance(bhyt))
                            throw new Exception("Thêm BHYT mới thất bại!");
                    }
                    else
                    {
                        if (!bhytBUS.UpdateHealthInsurance(bhyt))
                            throw new Exception("Cập nhật thẻ BHYT thất bại!");
                    }
                }
                else
                {
                    if (!bhytBUS.AddHealthInsurance(bhyt))
                        throw new Exception("Thêm BHYT mới thất bại!");
                }

                patient.SoBHYT = bhyt.SoBHYT;
            }
            else
            {
                patient.SoBHYT = oldPatient.SoBHYT;
            }

            if (!patientDAO.UpdatePatient(patient, oldSoCCCD))
                throw new Exception("Không tìm thấy bệnh nhân hoặc không thể cập nhật!");

            return true;
        }

        public bool DeletePatient(string soCCCD)
        {
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

            if (!patientDAO.DeletePatient(soCCCD))
                throw new Exception("Xoá bệnh nhân thất bại!");
            return true;
        }

        public PatientDTO GetPatientByIdOrNull(string soCCCD)
        {
            return patientDAO.GetPatientById(soCCCD); // trả về null nếu không tìm thấy
        }

    }
}
