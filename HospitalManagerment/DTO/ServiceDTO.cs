using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class ServiceDTO
    {
        private string madv;
        private string tendv;
        private string giadv;
        private string BHYTtra;
        public ServiceDTO()
        {
            this.madv = " ";
            this.tendv = " ";
            this.giadv = " ";
            this.BHYTtra = " ";
        }
        public ServiceDTO(string madv, string tendv, string giadv, string BHYTtra)
        {
            this.madv = madv;
            this.tendv = tendv;
            this.giadv = giadv;
            this.BHYTtra = BHYTtra;
        }
        public string Madv
        {
            get => madv;
            set { madv = value; }
        }
        public string Tendv
        {
            get => tendv;
            set { tendv = value; }
        }
        public string Giadv
        {
            get => giadv;
            set { giadv = value; }
        }
        public string BHYTTra
        {
            get => BHYTtra;
            set { BHYTtra = value; }
        }
    }
}
