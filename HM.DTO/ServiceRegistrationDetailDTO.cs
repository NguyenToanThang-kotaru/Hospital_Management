using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    // chi tiết đăng ký
    public class ServiceRegistrationDetailDTO
    {
        private string maDKDV;
        private string maDV;
        public ServiceRegistrationDetailDTO()
        {
            this.maDKDV = string.Empty;
            this.maDV = string.Empty;
        }
        public ServiceRegistrationDetailDTO(string maDKDV, string maDV)
        {
            this.maDKDV = maDKDV;
            this.maDV = maDV;        }

        public string MaDKDV
        {
            get => maDKDV;
            set { maDKDV = value; }
        }
        public string MaDV
        {
            get => maDV;
            set { maDV = value; }
        }
    }
}