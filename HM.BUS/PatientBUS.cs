using HM.DAO.ADO;
using HM.DTO;
using HM.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HM.BUS
{
    public class PatientBUS
    {
        private PatientDAO patientDAO;
        private List<PatientDTO> listDTO; 

        public PatientBUS()
        {
            patientDAO = new PatientDAO();
            listDTO = new List<PatientDTO>();
        }

        private bool ValidateInsertPatient(PatientDTO patient)
        {
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
            return patientDAO.SearchPatientBy(keyword);
        }

        public List<PatientDTO> GetAllPatients()
        {
            // THÊM CACHE LOGIC
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = patientDAO.GetAllPatients();
            }
            return listDTO;
        }

        public PatientDTO GetPatientById(string soCCCD)
        {
            // Kiểm tra cache trước
            var cached = listDTO.FirstOrDefault(x => x.SoCCCD == soCCCD);
            if (cached != null)
                return cached;

            // Nếu không có trong cache, lấy từ database
            var patient = patientDAO.GetPatientById(soCCCD);
            if (patient == null)
                throw new Exception("Không tìm thấy bệnh nhân!");

            // Thêm vào cache
            listDTO.Add(patient);
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
                patient.SoBHYT = "";
            }

            if (!patientDAO.AddPatient(patient))
                throw new Exception("Không thể thêm bệnh nhân vào cơ sở dữ liệu!");

            // THÊM VÀO CACHE
            listDTO.Add(patient);
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
                // ... giữ nguyên xử lý BHYT ...
            }
            else
            {
                patient.SoBHYT = oldPatient.SoBHYT;
            }

            if (!patientDAO.UpdatePatient(patient, oldSoCCCD))
                throw new Exception("Không tìm thấy bệnh nhân hoặc không thể cập nhật!");

            // CẬP NHẬT CACHE - QUAN TRỌNG!
            // 1. Xóa bản ghi cũ (với oldSoCCCD)
            var oldCached = listDTO.FirstOrDefault(x => x.SoCCCD == oldSoCCCD);
            if (oldCached != null)
            {
                listDTO.Remove(oldCached);
            }
            listDTO.Add(patient);

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

            // XÓA KHỎI CACHE
            var patient = listDTO.FirstOrDefault(x => x.SoCCCD == soCCCD);
            if (patient != null)
                listDTO.Remove(patient);

            return true;
        }

        public PatientDTO GetPatientByIdOrNull(string soCCCD)
        {
            // Kiểm tra cache trước
            var cached = listDTO.FirstOrDefault(x => x.SoCCCD == soCCCD);
            if (cached != null)
                return cached;

            // Lấy từ database
            return patientDAO.GetPatientById(soCCCD);
        }

        public bool ExistsPatient(string cccd)
        {
            // Kiểm tra cả cache và database
            if (listDTO.Any(sv => sv.SoCCCD == cccd))
                return true;

            // Nếu không có trong cache, kiểm tra database
            var patient = patientDAO.GetPatientById(cccd);
            if (patient != null)
            {
                listDTO.Add(patient); // Thêm vào cache
                return true;
            }
            return false;
        }

        public void RefreshList()
        {
            listDTO.Clear();
            listDTO = patientDAO.GetAllPatients();
        }
    }
}
