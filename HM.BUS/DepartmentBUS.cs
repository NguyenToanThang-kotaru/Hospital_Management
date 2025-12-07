using HM.DAO.ADO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class DepartmentBUS
    {
        private DepartmentDAO departmentDAO;
        private List<DepartmentDTO> listDTO;

        public DepartmentBUS()
        {
            departmentDAO = new DepartmentDAO();
            listDTO = new List<DepartmentDTO>();
        }

        public List<DepartmentDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<DepartmentDTO> GetAllDepartment()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = departmentDAO.GetAllDepartment();
            }
            return listDTO;
        }

        public DepartmentDTO GetDepartmentById(string maKhoa)
        {
            return listDTO.FirstOrDefault(x => x.MaKhoa == maKhoa);
        }

        public bool AddDepartment(DepartmentDTO obj)
        {
            try
            {
                if (departmentDAO.AddDepartment(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khoa: " + ex.Message);
            }
            return false;
        }

        public bool UpdateDepartment(DepartmentDTO obj)
        {
            try
            {
                if (departmentDAO.UpdateDepartment(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaKhoa == obj.MaKhoa);
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
                MessageBox.Show("Lỗi khi cập nhật khoa: " + ex.Message);
            }
            return false;
        }

        public bool DeleteDepartment(string maKhoa)
        {
            try
            {
                if (departmentDAO.DeleteDepartment(maKhoa) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaKhoa == maKhoa);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khoa: " + ex.Message);
            }
            return false;
        }

        public List<DepartmentDTO> SearchDepartmentByName(string keyword)
        {
            try
            {
                return departmentDAO.SearchDepartmentByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khoa: " + ex.Message);
                return new List<DepartmentDTO>();
            }
        }

        public string GetNextDepartmentId()
        {
            try
            {
                return departmentDAO.GetNextDepartmentId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã khoa tiếp theo: " + ex.Message);
                return null;
            }
        }

        public bool ExistsDepartmentId(string maKhoa)
        {
            return GetAllDepartment().Any(sv => sv.MaKhoa == maKhoa);
        }
    }
}
