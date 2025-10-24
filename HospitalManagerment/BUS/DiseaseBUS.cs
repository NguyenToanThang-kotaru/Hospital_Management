using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class DiseaseBUS
    {
        private DiseaseDAO diseaseDAO;
        private List<DiseaseDTO> listDTO;

        public DiseaseBUS()
        {
            diseaseDAO = new DiseaseDAO();
            listDTO = new List<DiseaseDTO>();
        }

        public List<DiseaseDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<DiseaseDTO> GetAllDiseases()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = diseaseDAO.GetAllDiseases();
            }
            return listDTO;
        }

        public DiseaseDTO GetDiseaseById(string maBenh)
        {
            return listDTO.FirstOrDefault(x => x.MaBenh == maBenh);
        }

        public bool AddDisease(DiseaseDTO obj)
        {
            try
            {
                if (diseaseDAO.AddDisease(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bệnh: " + ex.Message);
            }
            return false;
        }

        public bool UpdateDisease(DiseaseDTO obj)
        {
            try
            {
                if (diseaseDAO.UpdateDisease(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaBenh == obj.MaBenh);
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
                MessageBox.Show("Lỗi khi cập nhật bệnh: " + ex.Message);
            }
            return false;
        }

        public bool DeleteDisease(string maBenh)
        {
            try
            {
                if (diseaseDAO.DeleteDisease(maBenh) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaBenh == maBenh);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bệnh: " + ex.Message);
            }
            return false;
        }

        public string GetNextDiseaseId()
        {
            try
            {
                return diseaseDAO.GetNextDiseaseId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã bệnh tiếp theo: " + ex.Message);
                return null;
            }
        }

        public List<DiseaseDTO> SearchDiseaseByName(string keyword)
        {
            try
            {
                return diseaseDAO.SearchDiseaseByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm bệnh: " + ex.Message);
            }
            return new List<DiseaseDTO>();
        }
    }
}
