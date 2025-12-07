using HM.DAO.ADO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class MedicalBUS
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
            return medicalDAO.GetMedicalById(maBA);
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
                return listDTO.Where(x =>
                    x.MaBA.Contains(keyword) ||
                    x.SoCCCD.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm bệnh án: " + ex.Message);
                return new List<MedicalDTO>();
            }
        }

        public bool ExistsMedicalId(string maBA)
        {
            return listDTO.Any(ba => ba.MaBA == maBA);
        }

        public List<MedicalDTO> GetAllMedicalsByPatientId(string soCCCD)
        {
            return medicalDAO.GetAllMedicalsByPatientId(soCCCD);
        }

        public bool UpdatePatientCCCD(string oldCCCD, string newCCCD)
        {
            try
            {
                bool dbResult = medicalDAO.UpdatePatientCCCD(oldCCCD, newCCCD);

                if (dbResult)
                {
                    var itemsToUpdate = listDTO.Where(x => x.SoCCCD == oldCCCD).ToList();
                    foreach (var item in itemsToUpdate)
                    {
                        item.SoCCCD = newCCCD;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật CCCD trong bệnh án: {ex.Message}");
                return false;
            }
        }

        public bool HasMedicalRecords(string soCCCD)
        {
            try
            {
                if (listDTO.Any(x => x.SoCCCD == soCCCD))
                    return true;
                return medicalDAO.HasMedicalRecords(soCCCD);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra bệnh án: {ex.Message}");
                return false;
            }
        }

    }
}
