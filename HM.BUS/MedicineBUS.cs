using HM.DAO.ADO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class MedicineBUS
    {
        private MedicineDAO medicinedao;
        private List<MedicineDTO> listDTO;

        public MedicineBUS()
        {
            medicinedao = new MedicineDAO();
            listDTO = new List<MedicineDTO>();
        }

        public List<MedicineDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<MedicineDTO> GetAllMedicines()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = medicinedao.GetAllMedicines();
            }
            return listDTO;
        }

        public MedicineDTO GetMedicineById(string maDP)
        {
            return medicinedao.GetMedicineById(maDP);
        }

        public bool AddMedicine(MedicineDTO obj)
        {
            try
            {
                if (medicinedao.AddMedicine(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dược phẩm: " + ex.Message);
            }
            return false;
        }

        public bool UpdateMedicine(MedicineDTO obj)
        {
            try
            {
                if (medicinedao.UpdateMedicine(obj) > 0)
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
                MessageBox.Show("Lỗi khi cập nhật dược phẩm: " + ex.Message);
            }
            return false;
        }

        public bool DeleteMedicine(string maDP)
        {
            try
            {
                if (medicinedao.DeleteMedicine(maDP) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaDP == maDP);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dược phẩm: " + ex.Message);
            }
            return false;
        }

        public List<MedicineDTO> SearchMedicinesByName(string keyword)
        {
            try
            {
                return medicinedao.SearchMedicinesByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dược phẩm: " + ex.Message);
                return new List<MedicineDTO>();
            }
        }

        public string GetNextMedicineId()
        {
            try
            {
                return medicinedao.GetNextMedicineId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã dược phẩm tiếp theo: " + ex.Message);
                return null;
            }
        }

        public bool ExistsMedicineId(string maDP)
        {
            return GetAllMedicines().Any(sv => sv.MaDP == maDP);
        }
    }
}
