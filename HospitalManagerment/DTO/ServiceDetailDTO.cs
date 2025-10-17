using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    //Chi tiết dịch vụ
    internal class ServiceDetailDTO
    {
        private string maDV;
        private string maBA;
        public ServiceDetailDTO()
        {
            this.maDV = " ";
            this.maBA = " ";
        }
        public ServiceDetailDTO(string maDV, string maBA)
        {
            this.maDV = maDV;
            this.maBA = maBA;
        }
        public string MaDV
        {
            get => maDV;
            set { maDV = value; }
        }
        public string MaBA
        {
            get => maBA;
            set { maBA = value; }
        }
    }
}
