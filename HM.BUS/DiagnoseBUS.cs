using HM.DAO.ADO;
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
        public List<DiagnoseDTO> GetDiagnosesByMedicalId(string maBA)
        {
            return diagnoseDAO.GetDiagnoseByMedicalId(maBA);
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

        public bool DeleteDiagnoseByMedicalId(string maBA)
        {
            try
            {
                int affectedRows = diagnoseDAO.DeleteDiagnoseByMedicalId(maBA);
                if (affectedRows > 0)
                {
                    listDTO = diagnoseDAO.GetAllDiagnose();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chẩn đoán theo mã bệnh án: " + ex.Message);
            }
            return false;
        }
    }

}
