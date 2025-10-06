using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class ActionDTO
    {
        private string maHD;
        private string tenHD;

        public ActionDTO()
        {
            this.maHD = " ";
            this.tenHD = " ";
        }

        public ActionDTO(string maHD, string tenHD)
        {
            this.maHD = maHD;
            this.tenHD = tenHD;
        }

        public string MaHD
        {
            get => this.maHD;
            set { this.maHD = value; }
        }

        public string TenHD
        {
            get => this.tenHD;
            set { this.tenHD = value; }
        }
    }
}
