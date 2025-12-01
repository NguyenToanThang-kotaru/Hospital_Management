using HM.DAO;
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

        public PrescriptionDTO GetPrescriptionByMedicalId(string maBA)
        {
            return listDTO.FirstOrDefault(x => x.MaBA == maBA);
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

        //public bool DeletePrescription(string maDP)
        //{
        //    try
        //    {
        //        if (prescriptiondao.DeletePrescription(maDP) > 0)
        //        {
        //            var existing = listDTO.FirstOrDefault(x => x.MaDP == maDP);
        //            if (existing != null)
        //                listDTO.Remove(existing);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi xóa đơn thuốc: " + ex.Message);
        //    }
        //    return false;
        //}

        public List<PrescriptionDTO> SearchPrescriptionByName(string keyword)
        {
            try
            {
                return prescriptiondao.SearchPrescriptionByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đơn thuốc: " + ex.Message);
                return new List<PrescriptionDTO>();
            }
        }

        public string GetNextPresciptionId()
        {
            try
            {
                return prescriptiondao.GetNextPrescriptionId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã đơn thuốc tiếp theo: " + ex.Message);
                return null;
            }
        }

        public List<PrescriptionDTO> GetPrescriptionsByMedicalId(string maBA)
        {
            return prescriptiondao.GetPrescriptionsByMedicalId(maBA);
        }
    }
}
