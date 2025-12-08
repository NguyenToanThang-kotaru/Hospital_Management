using HM.DAO.ADO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class PrescriptionBUS
    {
        private PrescriptionDAO prescriptiondao;
        private List<PrescriptionDTO> listDTO;

        public PrescriptionBUS()
        {
            prescriptiondao = new PrescriptionDAO();
            listDTO = new List<PrescriptionDTO>();
        }

        public List<PrescriptionDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<PrescriptionDTO> GetAllPrescription()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = prescriptiondao.GetAllPrescription();
            }
            return listDTO;
        }
        public List<PrescriptionDTO> GetPrescriptionsByMedicalId(string maBA)
        {
            return prescriptiondao.GetPrescriptionsByMedicalId(maBA);
        }

        public bool AddPrescription(PrescriptionDTO obj)
        {
            try
            {
                if (prescriptiondao.AddPrescription(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đơn thuốc: " + ex.Message);
            }
            return false;
        }

        public bool UpdatePrescription(PrescriptionDTO obj)
        {
            try
            {
                if (prescriptiondao.UpdatePrescription(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaDP == obj.MaDP);
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
                MessageBox.Show("Lỗi khi cập nhật đơn thuốc: " + ex.Message);
            }
            return false;
        }

        public bool DeletePrescriptionByMedicalId(string maBA)
        {
            try
            {
                int affectedRows = prescriptiondao.DeletePrescriptionByMedicalId(maBA);
                if (affectedRows > 0)
                {
                    listDTO = prescriptiondao.GetAllPrescription();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn thuốc theo mã bệnh án: " + ex.Message);
            }
            return false;
        }
    }
}
