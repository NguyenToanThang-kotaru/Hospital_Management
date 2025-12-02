using HM.DAO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class PermissionDetailBUS
    {
        private PermissionDetailDAO permissionDetailDAO;
        private List<PermissionDetailDTO> listDTO;

        public PermissionDetailBUS()
        {
            permissionDetailDAO = new PermissionDetailDAO();
            listDTO = new List<PermissionDetailDTO>();
        }

        public List<PermissionDetailDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<PermissionDetailDTO> GetAllPermissionDetails()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = permissionDetailDAO.GetAllPermissionDetails();
            }
            return listDTO;
        }

        public List<PermissionDetailDTO> GetPermissionDetailsByPermissionId(string maQuyen)
        {
            try
            {
                return permissionDetailDAO.GetPermissionDetailsByPermissionId(maQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết quyền theo mã: " + ex.Message);
                return new List<PermissionDetailDTO>();
            }
        }

        public bool AddPermissionDetail(PermissionDetailDTO obj)
        {
            try
            {
                if (permissionDetailDAO.AddPermissionDetail(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết quyền: " + ex.Message);
            }
            return false;
        }

        public bool UpdatePermissionDetail(PermissionDetailDTO obj)
        {
            try
            {
                if (permissionDetailDAO.UpdatePermissionDetail(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x =>
                        x.MaQuyen == obj.MaQuyen && x.MaHD == obj.MaHD && x.MaCN == obj.MaCN);
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
                MessageBox.Show("Lỗi khi cập nhật chi tiết quyền: " + ex.Message);
            }
            return false;
        }

        public bool DeletePermissionDetail(string maQuyen, string maHD, string maCN)
        {
            try
            {
                if (permissionDetailDAO.DeletePermissionDetail(maQuyen, maHD, maCN) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x =>
                        x.MaQuyen == maQuyen && x.MaHD == maHD && x.MaCN == maCN);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết quyền: " + ex.Message);
            }
            return false;
        }

        public bool ActivePermissionDetail(string maQuyen, string maHD, string maCN)
        {
            return permissionDetailDAO.ActivePermissionDetail(maCN, maQuyen, maHD) > 0;
        }

        public bool ExistsPermissionDetail(string maQuyen, string maHD, string maCN)
        {
            return permissionDetailDAO.ExistsPermissionDetail(maCN, maQuyen, maHD) > 0;
        }
    }
}
