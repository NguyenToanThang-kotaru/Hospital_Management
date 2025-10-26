using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalManagerment.BUS
{
    internal class ServiceDetailBUS
    {
        private ServiceDetailDAO servicedetaildao;
        private List<ServiceDetailDTO> listDTO;

        public ServiceDetailBUS()
        {
            servicedetaildao = new ServiceDetailDAO();
            listDTO = new List<ServiceDetailDTO>();
        }

        public List<ServiceDetailDTO> ListDTO
        {
            get => listDTO;
            set => listDTO = value;
        }

        public List<ServiceDetailDTO> GetAllServiceDetail()
        {
            if (listDTO == null || listDTO.Count == 0)
            {
                listDTO = servicedetaildao.GetAllServiceDetail();
            }
            return listDTO;
        }

        public ServiceDetailDTO GetServiceDetailById(string maDV)
        {
            return listDTO.FirstOrDefault(x => x.MaDV == maDV);
        }

        public bool AddServiceDetail(ServiceDetailDTO obj)
        {
            try
            {
                if (servicedetaildao.AddServiceDetail(obj) > 0)
                {
                    listDTO.Add(obj);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết dịch vụ: " + ex.Message);
            }
            return false;
        }

        public bool UpdateServiceDetail(ServiceDetailDTO obj)
        {
            try
            {
                if (servicedetaildao.UpdateServiceDetail(obj) > 0)
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
                MessageBox.Show("Lỗi khi cập nhật chi tiết dịch vụ: " + ex.Message);
            }
            return false;
        }

        //public bool DeleteServiceDetail(string maDV)
        //{
        //    try
        //    {
        //        if (servicedetaildao.DeleteServiceDetail(maDV) > 0)
        //        {
        //            var existing = listDTO.FirstOrDefault(x => x.MaDV == maDV);
        //            if (existing != null)
        //                listDTO.Remove(existing);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi xóa chi tiết dịch vụ: " + ex.Message);
        //    }
        //    return false;
        //}

        public List<ServiceDetailDTO> SearchServiceDetailByName(string keyword)
        {
            try
            {
                return servicedetaildao.SearchServiceDetailByName(keyword);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm chi tiết dịch vụ: " + ex.Message);
                return new List<ServiceDetailDTO>();
            }
        }

        public string GetNextServiceDetailId()
        {
            try
            {
                return servicedetaildao.GetNextServiceDetailId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã dịch vụ tiếp theo: " + ex.Message);
                return null;
            }
        }
    }
}
