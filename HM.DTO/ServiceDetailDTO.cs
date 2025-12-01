using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    // chi tiết dịch vụ
    public class ServiceDetailDTO
    {
        private string maDV;
        private string maBA;
        public ServiceDetailDTO()
        {
            this.maDV = string.Empty;
            this.maBA = string.Empty;
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