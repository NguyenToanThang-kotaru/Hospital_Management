using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class ServiceRegistrationDetailBUS
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

        public ServiceRegistrationDetailDTO GetServiceRegistrationDetailById(string maDKDV)
        {
            return listDTO.FirstOrDefault(x => x.MaDKDV == maDKDV);
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

        //public bool DeleteServiceRegistrationDetail(string maDKDV)
        //{
        //    try
        //    {
        //        if (serviceregistraiondetaildao.DeleteServiceRegistrationDetail(maDKDV) > 0)
        //        {
        //            var existing = listDTO.FirstOrDefault(x => x.MaDKDV == maDKDV);
        //            if (existing != null)
        //                listDTO.Remove(existing);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi xóa chi tiết đăng ký dịch vụ: " + ex.Message);
        //    }
        //    return false;
        //}

        public List<ServiceRegistrationDetailDTO> SearchServiceRegistrationDetailByName(string keyword)
        {
            try
            {
                return serviceregistrationdetaildao.SearchServiceRegistrationDetailByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm chi tiết đăng ký dịch vụ: " + ex.Message);
                return new List<ServiceRegistrationDetailDTO>();
            }
        }

        public string GetNextServiceRegistrationDetailId()
        {
            try
            {
                return serviceregistrationdetaildao.GetNextServiceRegistrationDetailId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã đăng ký dịch vụ tiếp theo: " + ex.Message);
                return null;
            }
        }
    }
}
