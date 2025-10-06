using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class ServiceRegistrationDTO
    {
        private string madkdv;
        private string socccd;
        private string ngaygiotao;
        private string trangthaidk;
        private string tongchiphi;
        private string hinhthuctt;
        private string manv;
        public ServiceRegistrationDTO()
        {
            this.madkdv = " ";
            this.socccd = " ";
            this.ngaygiotao = " ";
            this.trangthaidk = " ";
            this.tongchiphi = " ";
            this.hinhthuctt = " ";
            this.manv = " ";
        }
        public ServiceRegistrationDTO(string madkdv, string socccd, string ngaygiotao, string trangthaidk, string tongchiphi, string hinhthuctt, string manv)
        {
            this.madkdv = madkdv;
            this.socccd = socccd;
            this.ngaygiotao = ngaygiotao;
            this.trangthaidk = trangthaidk;
            this.tongchiphi = tongchiphi;
            this.hinhthuctt = hinhthuctt;
            this.manv = manv;
        }
        public string Madkdv
        {
            get => madkdv;
            set { madkdv = value; }
        }
        public string Socccd
        {
            get => socccd;
            set { socccd = value; }
        }
        public string Ngaygiotao
        {
            get => ngaygiotao;
            set { ngaygiotao = value; }
        }
        public string Trangthaidk
        {
            get => trangthaidk;
            set { trangthaidk = value; }
        }
        public string Tongchiphi
        {
            get => tongchiphi;
            set { tongchiphi = value; }
        }
        public string Hinhthuctt
        {
            get => hinhthuctt;
            set { hinhthuctt = value; }
        }
        public string Manv
        {
            get => manv;
            set { manv = value; }
        }
    }
}
