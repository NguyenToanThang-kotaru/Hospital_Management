using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class DiseaseDTO
    {
        private string mabenh;
        private string tenbenh;
        private string motabenh;

        public DiseaseDTO()
        {
            this.mabenh = " ";
            this.tenbenh = " ";
            this.motabenh = " ";
        }

        public DiseaseDTO(string mabenh, string tenbenh, string motabenh)
        {
            this.mabenh = mabenh;
            this.tenbenh = tenbenh;
            this.motabenh = motabenh;
        }

        public string Mabenh
        {
            get => mabenh;
            set { mabenh = value; }
        }

        public string Tenbenh
        {
            get => tenbenh;
            set { tenbenh = value; }
        }

        public string Motabenh
        {
            get => motabenh;
            set { motabenh = value; }
        }
    }
}
