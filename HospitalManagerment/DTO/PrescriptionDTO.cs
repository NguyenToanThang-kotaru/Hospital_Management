using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    //Đơn thuốc
    internal class PrescriptionDTO
    {
        private string maBA;
        private string maDP;
        private string soLuongDP;
        private string donViDP;
        public PrescriptionDTO()
        {
            this.maBA = " ";
            this.maDP = " ";
            this.soLuongDP = " ";
            this.donViDP = " ";
        }
        public PrescriptionDTO(string maBA, string maDP, string soLuongDP, string donViDP)
        {
            this.maBA = maBA;
            this.maDP = maDP;
            this.soLuongDP = soLuongDP;
            this.donViDP = donViDP;
        }
        public string MaBA
        {
            get => maBA;
            set { maBA = value; }
        }
        public string MaDP
        {
            get => maDP;
            set { maDP = value; }
        }
        public string SoLuongDP
        {
            get => soLuongDP;
            set { soLuongDP = value; }
        }
        public string DonViDP
        {
            get => donViDP;
            set { donViDP = value; }
        }
    }
}
