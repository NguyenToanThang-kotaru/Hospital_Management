using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class PrescriptionDTO
    {
        private string maba;
        private string madp;
        private string soluongdp;
        private string donvidp;
        public PrecriptionDTO()
        {
            this.maba = " ";
            this.madp = " ";
            this.soluongdp = " ";
            this.donvidp = " ";
        }
        public PrecriptionDTO(string maba, string madp, string soluongdp, string donvidp)
        {
            this.maba = maba;
            this.madp = madp;
            this.soluongdp = soluongdp;
            this.donvidp = donvidp;
        }
        public string Maba
        {
            get => maba;
            set { maba = value; }
        }
        public string Madp
        {
            get => madp;
            set { madp = value; }
        }
        public string Soluongdp
        {
            get => soluongdp;
            set { soluongdp = value; }
        }
        public string Donvidp
        {
            get => donvidp;
            set { donvidp = value; }
        }
    }
}
