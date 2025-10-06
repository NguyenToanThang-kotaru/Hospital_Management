using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class ServiceRegistrationDetailDTO
    {
        private string madv;
        private string maba;
        public UseServiceDTO()
        {
            this.madv = " ";
            this.maba = " ";
        }
        public UseServiceDTO(string madv, string maba)
        {
            this.madv = madv;
            this.maba = maba;
        }
        public string Madv
        {
            get => madv;
            set { madv = value; }
        }
        public string Maba
        {
            get => maba;
            set { maba = value; }
        }
    }
}
