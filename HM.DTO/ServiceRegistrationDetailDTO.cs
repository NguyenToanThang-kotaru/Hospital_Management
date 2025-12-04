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
        private string tienDV;
        public ServiceRegistrationDetailDTO()
        {
            this.maDKDV = string.Empty;
            this.maDV = string.Empty;
            this.tienDV = string.Empty;
        }
        public ServiceRegistrationDetailDTO(string maDKDV, string maDV, string tienDV)
        {
            this.maDKDV = maDKDV;
            this.maDV = maDV;       
            this.tienDV = tienDV;
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

        public string TienDV
        {
            get => tienDV;
            set { tienDV = value; }
        }
    }
}