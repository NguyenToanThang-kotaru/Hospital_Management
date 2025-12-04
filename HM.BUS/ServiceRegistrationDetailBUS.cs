using HM.DAO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class ServiceRegistrationDetailBUS
    {
        private ServiceRegistrationDetailDAO serviceregistrationdetaildao;
        private List<ServiceRegistrationDetailDTO> listDTO;

        public ServiceRegistrationDetailBUS()
        {
            serviceregistrationdetaildao = new ServiceRegistrationDetailDAO();
            listDTO = new List<ServiceRegistrationDetailDTO>();
        }

        public List<ServiceRegistrationDetailDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<ServiceRegistrationDetailDTO> GetAllServiceRegistrationDetail()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = serviceregistrationdetaildao.GetAllServiceRegistrationDetail();
            }
            return listDTO;
        }

        public List<ServiceRegistrationDetailDTO> GetServiceRegistrationDetailByServiceRegistrationId(string maDKDV)
        {
            return serviceregistrationdetaildao.GetServiceRegistrationDetailByServiceRegistrationId(maDKDV);
        }

        public bool AddServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            try
            {
                if (serviceregistrationdetaildao.AddServiceRegistrationDetail(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết đăng ký dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool UpdateServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            try
            {
                if (serviceregistrationdetaildao.UpdateServiceRegistrationDetail(obj) > 0)
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
                MessageBox.Show("Lỗi khi cập nhật chi tiết đăng ký dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool DeleteAllServiceRegistrationDetailByRegistrationId(string maDKDV)
        {
            return serviceregistrationdetaildao.DeleteAllServiceRegistrationDetailByRegistrationId(maDKDV);
        }


    }
}
