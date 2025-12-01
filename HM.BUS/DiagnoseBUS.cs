using HM.DAO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class DiagnoseBUS
    {
        private DiagnoseDAO diagnoseDAO;
        private List<DiagnoseDTO> listDTO;

        public DiagnoseBUS()
        {
            diagnoseDAO = new DiagnoseDAO();
            listDTO = new List<DiagnoseDTO>();
        }

        public List<DiagnoseDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<DiagnoseDTO> GetAllDiagnose()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = diagnoseDAO.GetAllDiagnose();
            }
            return listDTO;
        }

        public DiagnoseDTO GetDiagnoseById(string maBA, string maBenh)
        {
            return listDTO.FirstOrDefault(x => x.MaBA == maBA && x.MaBenh == maBenh);
        }

        public bool AddDiagnose(DiagnoseDTO obj)
        {
            try
            {
                if (diagnoseDAO.AddDiagnose(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chẩn đoán: " + ex.Message);
            }
            return false;
        }

        public bool UpdateDiagnose(DiagnoseDTO obj)
        {
            try
            {
                if (diagnoseDAO.UpdateDiagnose(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaBA == obj.MaBA && x.MaBenh == obj.MaBenh);
                    if (existing != null)
                    {
                        int index = listDTO.IndexOf(existing);
                        listDTO[index] = obj;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chẩn đoán: " + ex.Message);
            }
            return false;
        }

        public bool DeleteDiagnose(string maBA, string maBenh)
        {
            try
            {
                if (diagnoseDAO.DeleteDiagnose(maBA, maBenh) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaBA == maBA && x.MaBenh == maBenh);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chẩn đoán: " + ex.Message);
            }
            return false;
        }

        public List<DiagnoseDTO> GetDiagnoseByMedicalId(string maBA)
        {
            try
            {
                return diagnoseDAO.GetDiagnoseByMedicalId(maBA);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chẩn đoán theo bệnh án: " + ex.Message);
            }
            return new List<DiagnoseDTO>();
        }

        public List<DiagnoseDTO> GetDiagnoseByDiseaseId(string maBenh)
        {
            try
            {
                return diagnoseDAO.GetDiagnoseByDiseaseId(maBenh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chẩn đoán theo bệnh: " + ex.Message);
            }
            return new List<DiagnoseDTO>();
        }

        public bool IsDiagnoseExists(string maBA, string maBenh)
        {
            try
            {
                return diagnoseDAO.IsDiagnoseExists(maBA, maBenh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra chẩn đoán tồn tại: " + ex.Message);
            }
            return false;
        }

        public List<DiagnoseDTO> GetDiagnosesByMedicalId(string maBA)
        {
            return diagnoseDAO.GetDiagnoseByMedicalId(maBA);
        }
    }

}
