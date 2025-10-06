using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class MedicalDTO
    {
        private string madp;
        private string tendp;
        private string loaidp;
        public PharmaceuticalsDTO()
        {
            this.madp = " ";
            this.tendp = " ";
            this.loaidp = " ";
        }
        public PharmaceuticalsDTO(string madp, string tendp, string loaidp)
        {
            this.madp = madp;
            this.tendp = tendp;
            this.loaidp = loaidp;
        }
        public string Madp
        {
            get => madp;
            set { madp = value; }
        }
        public string Tendp
        {
            get => tendp;
            set { tendp = value; }
        }
        public string Loaidp
        {
            get => loaidp;
            set { loaidp = value; }
        }
    }
}
