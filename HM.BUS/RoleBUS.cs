using HM.DAO.LINQ;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class RoleBUS
    {
        private RoleDAO roleDAO;
        private List<RoleDTO> listDTO;

        public RoleBUS()
        {
            roleDAO = new RoleDAO();
            listDTO = new List<RoleDTO>();
        }

        public List<RoleDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<RoleDTO> GetAllRoles()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = roleDAO.GetAllRoles();
            }
            return listDTO;
        }

        public RoleDTO GetRoleById(string maVT)
        {
            return GetAllRoles().FirstOrDefault(x => x.MaVT == maVT);
        }

        public bool AddRole(RoleDTO obj)
        {
            try
            {
                if (roleDAO.AddRole(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vai trò: " + ex.Message);
            }
            return false;
        }

        public bool UpdateRole(RoleDTO obj)
        {
            try
            {
                if (roleDAO.UpdateRole(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaVT == obj.MaVT);
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
                MessageBox.Show("Lỗi khi cập nhật vai trò: " + ex.Message);
            }
            return false;
        }

        public bool DeleteRole(string maVT)
        {
            try
            {
                if (roleDAO.DeleteRole(maVT) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaVT == maVT);
                    if (existing != null)
                    {
                        // Cập nhật TrangThaiXoa trong listDTO
                        existing.TrangThaiXoa = "1";
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa vai trò: " + ex.Message);
            }
            return false;
        }

        public List<RoleDTO> SearchRoleByName(string keyword)
        {
            try
            {
                return roleDAO.SearchRoleByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm vai trò: " + ex.Message);
                return new List<RoleDTO>();
            }
        }

        public string GetNextRoleId()
        {
            try
            {
                return roleDAO.GetNextRoleId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã vai trò tiếp theo: " + ex.Message);
                return null;
            }
        }

        public bool ExistsRoleId(string maVT)
        {
            return GetAllRoles().Any(r => r.MaVT == maVT);
        }
    }
}