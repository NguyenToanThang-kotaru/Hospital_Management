using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class MedicalBUS
    {
        private MedicalDAO medicalDAO;
        private List<MedicalDTO> listDTO;

        public MedicalBUS()
        {
            medicalDAO = new MedicalDAO();
            listDTO = new List<MedicalDTO>();
        }

        public List<MedicalDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<MedicalDTO> GetAllMedicals()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = medicalDAO.GetAllMedicals();
            }
            return listDTO;
        }

        public MedicalDTO GetMedicalById(string maBA)
        {
            return listDTO.FirstOrDefault(x => x.MaBA == maBA);
        }

        public bool AddMedical(MedicalDTO obj)
        {
            try
            {
                if (medicalDAO.AddMedical(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bệnh án: " + ex.Message);
            }
            return false;
        }

        public bool UpdateMedical(MedicalDTO obj)
        {
            try
            {
                if (medicalDAO.UpdateMedical(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaBA == obj.MaBA);
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
                MessageBox.Show("Lỗi khi cập nhật bệnh án: " + ex.Message);
            }
            return false;
        }

        public bool DeleteMedical(string maBA)
        {
            try
            {
                if (medicalDAO.DeleteMedical(maBA) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaBA == maBA);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bệnh án: " + ex.Message);
            }
            return false;
        }

        public string GetNextMedicalId()
        {
            try
            {
                return medicalDAO.GetNextMedicalId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã bệnh án tiếp theo: " + ex.Message);
                return null;
            }
        }

        public List<MedicalDTO> SearchMedicalByName(string keyword)
        {
            try
            {
                return medicalDAO.SearchMedicalByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm bệnh án: " + ex.Message);
            }
            return new List<MedicalDTO>();
        }
    }
}
