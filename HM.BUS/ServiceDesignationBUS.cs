using HM.DAO.ADO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class ServiceDesignationBUS
    {
        private ServiceDesignationDAO serviceDesignationDAO;
        private List<ServiceDesignationDTO> listDTO;

        public ServiceDesignationBUS()
        {
            serviceDesignationDAO = new ServiceDesignationDAO();
            listDTO = new List<ServiceDesignationDTO>();
        }

        public List<ServiceDesignationDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        } 

        public List<ServiceDesignationDTO> GetAllServiceDesignation()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = serviceDesignationDAO.GetAllServiceDesignation();
            }
            return listDTO;
        }

        public ServiceDesignationDTO GetServiceDesignationById(string maPCD)
        {
            return listDTO.FirstOrDefault(x => x.MaPCD == maPCD);
        }

        public bool AddServiceDesignation(ServiceDesignationDTO obj)
        {
            try
            {
                if (serviceDesignationDAO.AddServiceDesignation(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu chỉ định dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool UpdateServiceDesignation(ServiceDesignationDTO obj)
        {
            try
            {
                if (serviceDesignationDAO.UpdateServiceDesignation(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaPCD == obj.MaPCD);
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
                MessageBox.Show("Lỗi khi cập nhật phiếu chỉ định dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool DeleteServiceDesignation(string maPCD)
        {
            try
            {
                if (serviceDesignationDAO.DeleteServiceDesignation(maPCD) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaPCD == maPCD);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu chỉ định dịch vụ: " + ex.Message);
            }
            return false;
        }

        public string GetNextServiceDesignationId()
        {
            try
            {
                return serviceDesignationDAO.GetNextServiceDesignationId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã phiếu chỉ định tiếp theo: " + ex.Message);
                return null;
            }
        }

        public List<ServiceDesignationDTO> SearchServiceDesignationByCustomer(string soCCCD)
        {
            return serviceDesignationDAO.SearchServiceDesignationByCustomer(soCCCD);
        }
        public bool ExistsServiceDesignationId(string maPCD)
        {
            return GetAllServiceDesignation().Any(sv => sv.MaPCD == maPCD);
        }
    }
}
