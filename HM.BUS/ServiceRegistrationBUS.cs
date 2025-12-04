using HM.DAO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class ServiceRegistrationBUS
    {
        private ServiceRegistrationDAO serviceregistrationdao;
        private List<ServiceRegistrationDTO> listDTO;

        public ServiceRegistrationBUS()
        {
            serviceregistrationdao = new ServiceRegistrationDAO();
            listDTO = new List<ServiceRegistrationDTO>();
        }

        public List<ServiceRegistrationDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<ServiceRegistrationDTO> GetAllServiceRegistration()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = serviceregistrationdao.GetAllServiceRegistration();
            }
            return listDTO;
        }

        public ServiceRegistrationDTO GetServiceRegistrationById(string maDKDV)
        {
            return listDTO.FirstOrDefault(x => x.MaDKDV == maDKDV);
        }

        public bool AddServiceRegistration(ServiceRegistrationDTO obj)
        {
            try
            {
                if (serviceregistrationdao.AddServiceRegistration(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đăng ký dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool UpdateServiceRegistration(ServiceRegistrationDTO obj)
        {
            try
            {
                if (serviceregistrationdao.UpdateServiceRegistration(obj) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaDKDV == obj.MaDKDV);
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
                MessageBox.Show("Lỗi khi cập nhật đăng ký dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool DeleteServiceRegistration(string maDKDV)
        {
            try
            {
                if (serviceregistrationdao.DeleteServiceRegistration(maDKDV) > 0)
                {
                    var existing = listDTO.FirstOrDefault(x => x.MaDKDV == maDKDV);
                    if (existing != null)
                        listDTO.Remove(existing);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đăng ký dịch vụ: " + ex.Message);
            }
            return false;
        }

        public List<ServiceRegistrationDTO> SearchServiceRegistrationByName(string keyword)
        {
            try
            {
                return serviceregistrationdao.SearchServiceRegistration(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                return new List<ServiceRegistrationDTO>();
            }
        }

        public string GetNextServiceRegistrationId()
        {
            try
            {
                return serviceregistrationdao.GetNextServiceRegistrationId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã đăng ký dịch vụ tiếp theo: " + ex.Message);
                return null;
            }
        }
    }
}
