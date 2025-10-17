using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    //Dịch vụ
    internal class ServiceDTO
    {
        private string maDV;
        private string tenDV;
        private string giaDV;
        private string BHYTtra;
        public ServiceDTO()
        {
            this.maDV = " ";
            this.tenDV = " ";
            this.giaDV = " ";
            this.BHYTtra = " ";
        }
        public ServiceDTO(string maDV, string tenDV, string giaDV, string BHYTtra)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.giaDV = giaDV;
            this.BHYTtra = BHYTtra;
        }
        public string MaDV
        {
            get => maDV;
            set { maDV = value; }
        }
        public string TenDV
        {
            get => tenDV;
            set { tenDV = value; }
        }
        public string GiaDV
        {
            get => giaDV;
            set { giaDV = value; }
        }
        public string BHYTTra
        {
            get => BHYTtra;
            set { BHYTtra = value; }
        }
    }
}
