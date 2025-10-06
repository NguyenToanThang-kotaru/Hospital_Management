using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // bệnh án
    internal class MedicalDTO
    {
        private string maba;
        private string socccd;
        private string manv;
        private string ngaytao;

        public MedicalDTO()
        {
            this.maba = " ";
            this.socccd = " ";
            this.manv = " ";
            this.ngaytao = " ";
        }

        public MedicalDTO(string maba, string socccd, string manv, string ngaytao)
        {
            this.maba = maba;
            this.socccd = socccd;
            this.manv = manv;
            this.ngaytao = ngaytao;
        }

        public string Maba
        {
            get => maba;
            set { maba = value; }
        }

        public string Socccd
        {
            get => socccd;
            set { socccd = value; }
        }

        public string Manv
        {
            get => manv;
            set { manv = value; }
        }

        public string Ngaytao
        {
            get => ngaytao;
            set { ngaytao = value; }
        }
    }
}
