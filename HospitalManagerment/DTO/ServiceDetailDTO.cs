using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class ServiceDetailDTO
    {
        private string madkdv;
        private string madv;
        public ServiceDetailDTO()
        {
            this.madkdv = " ";
            this.madv = " ";
        }
        public ServiceDetailDTO(string madkdv, string madv)
        {
            this.madkdv = madkdv;
            this.madv = madv;
        }

        public string Madkdv
        {
            get => madkdv;
            set { madkdv = value; }
        }
        public string Madv
        {
            get => madv;
            set { madv = value; }
        }
    }
}
