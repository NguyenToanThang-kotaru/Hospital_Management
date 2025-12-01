using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class PermissionBUS
    {
        private PermissionDAO permissionDAO;
        private List<PermissionDTO> listDTO;

        public PermissionBUS()
        {
            permissionDAO = new PermissionDAO();
            listDTO = new List<PermissionDTO>();
        }

        public List<PermissionDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<PermissionDTO> GetAllPermissions()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = permissionDAO.GetAllPermissions();
            }
            return listDTO;
        }

        public PermissionDTO GetPermissionById(string maQuyen)
        {
            return listDTO.FirstOrDefault(x => x.MaQuyen == maQuyen);
        }

        public bool AddPermission(PermissionDTO obj)
        {
            try
            {
                if (permissionDAO.AddPermission(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm quyền: " + ex.Message);
            }
            return false;
        }

        public bool UpdatePermission(PermissionDTO obj)
        {
            try
            {
                if (permissionDAO.UpdatePermission(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaQuyen == obj.MaQuyen);
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
                MessageBox.Show("Lỗi khi cập nhật quyền: " + ex.Message);
            }
            return false;
        }

        public bool DeletePermission(string maQuyen)
        {
            try
            {
                if (permissionDAO.DeletePermission(maQuyen) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaQuyen == maQuyen);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa quyền: " + ex.Message);
            }
            return false;
        }

        public string GetNextPermissionId()
        {
            try
            {
                return permissionDAO.GetNextPermissionId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã quyền tiếp theo: " + ex.Message);
                return null;
            }
        }

        public List<PermissionDTO> SearchPermissionByName(string keyword)
        {
            try
            {
                return permissionDAO.SearchPermissionByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm quyền: " + ex.Message);
            }
            return new List<PermissionDTO>();
        }

        public bool ExistsPermissionId(string maQuyen)
        {
            return GetAllPermissions().Any(sv => sv.MaQuyen == maQuyen);
        }
    }


}
