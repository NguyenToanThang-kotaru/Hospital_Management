using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    //Chi tiết đăng ký
    internal class ServiceRegistrationDetailDTO
    {
        private string maDKDV;
        private string maDV;
        public ServiceRegistrationDetailDTO()
        {
            this.maDKDV = " ";
            this.maDV = " ";
        }
        public ServiceRegistrationDetailDTO(string maDKDV, string maDV)
        {
            this.maDKDV = maDKDV;
            this.maDV = maDV;
        }

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
