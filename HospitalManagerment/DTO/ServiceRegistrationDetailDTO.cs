using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class ServiceRegistrationDetailDTO
    {
        private string madkdv;
        private string madv;
        public ServiceRegistrationDetailDTO()
        {
            this.madkdv = " ";
            this.madv = " ";
        }
        public ServiceRegistrationDetailDTO(string madkdv, string madv)
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
