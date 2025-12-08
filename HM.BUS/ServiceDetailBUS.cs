using HM.DAO.ADO;
using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HM.BUS
{
    public class ServiceDetailBUS
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
        
        public List<ServiceDetailDTO> GetServiceDetailByMedicalId(string maBA)
        {
            return servicedetaildao.GetServiceDetailByMedicalId(maBA);
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

        public bool DeleteServiceDetailByMedicalId(string maBA)
        {
            try
            {
                int affectedRows = servicedetaildao.DeleteServiceDetailByMedicalId(maBA);
                if (affectedRows > 0)
                {
                    listDTO = servicedetaildao.GetAllServiceDetail();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn thuốc theo mã bệnh án: " + ex.Message);
            }
            return false;
        }
        
    }
}
