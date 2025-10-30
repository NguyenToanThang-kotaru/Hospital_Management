using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace HospitalManagerment.BUS
{
    internal class ServiceBUS
    {
        private ServiceDAO servicedao;
        private List<ServiceDTO> listDTO;

        public ServiceBUS()
        {
            servicedao = new ServiceDAO();
            listDTO = new List<ServiceDTO>();
        }

        public List<ServiceDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<ServiceDTO> GetAllService()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = servicedao.GetAllService();
            }
            return listDTO;
        }

        public ServiceDTO GetServiceById(string maDV)
        {
            return listDTO.FirstOrDefault(x => x.MaDV == maDV);
        }

        public bool AddService(ServiceDTO obj)
        {
            try
            {
                if (servicedao.AddService(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool UpdateService(ServiceDTO obj)
        {
            try
            {
                if (servicedao.UpdateService(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaDV == obj.MaDV);
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
                MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool DeleteService(string maDV)
        {
            try
            {
                if (servicedao.DeleteService(maDV) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaDV == maDV);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message);
            }
            return false;
        }

        public List<ServiceDTO> SearchServiceByName(string keyword)
        {
            try
            {
                return servicedao.SearchServiceByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dịch vụ: " + ex.Message);
                return new List<ServiceDTO>();
            }
        }

        public string GetNextServiceId()
        {
            try
            {
                return servicedao.GetNextServiceId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã dịch vụ tiếp theo: " + ex.Message);
                return null;
            }
        }

        public bool ExistsServiceId(string maDV)
        {   
            return GetAllService().Any(sv => sv.MaDV == maDV);
        }
    }
}
