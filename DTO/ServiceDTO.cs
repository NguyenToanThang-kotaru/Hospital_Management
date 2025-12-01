using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // dịch vụ
    internal class ServiceDTO
    {
        private string maDV;
        private string tenDV;
        private string giaDV;
        private string BHYTtra;
        private string trangThaiXoa;
        public ServiceDTO()
        {
            this.maDV = string.Empty;
            this.tenDV = string.Empty;
            this.giaDV = string.Empty;
            this.BHYTtra = string.Empty;
            this.trangThaiXoa = "0";
        }
        public ServiceDTO(string maDV, string tenDV, string giaDV, string BHYTtra, string trangThaiXoa = "0")
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.giaDV = giaDV;
            this.BHYTtra = BHYTtra;
            this.trangThaiXoa = trangThaiXoa;
        }
        public string MaDV
        {
            get => maDV;
            set => maDV = value;
        }
        public string TenDV
        {
            get => tenDV;
            set => tenDV = value;
        }
        public string GiaDV
        {
            get => giaDV;
            set => giaDV = value; 
        }
        public string BHYTTra
        {
            get => BHYTtra;
            set => BHYTtra = value; 
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}