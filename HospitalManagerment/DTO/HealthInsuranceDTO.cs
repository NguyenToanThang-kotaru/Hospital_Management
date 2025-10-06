using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class HealthInsuranceDTO
    {
        private string soBHYT;
        private string ngayCap;
        private string ngayHetHan;
        private string mucHuong;
        private string trangThaiXoa;

        public HealthInsuranceDTO()
        {
            this.soBHYT = " ";
            this.ngayCap = " ";
            this.ngayHetHan = " ";
            this.mucHuong = " ";
            this.trangThaiXoa = " ";
        }

        public HealthInsuranceDTO(string soBHYT, string ngayCap, string ngayHetHan, string mucHuong, string trangThaiXoa)
        {
            this.soBHYT = soBHYT;
            this.ngayCap = ngayCap;
            this.ngayHetHan = ngayHetHan;
            this.mucHuong = mucHuong;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string SoBHYT
        {
            get => this.soBHYT;
            set { this.soBHYT = value; }
        }

        public string NgayCap
        {
            get => this.ngayCap;
            set { this.ngayCap = value; }
        }

        public string NgayHetHan
        {
            get => this.ngayHetHan;
            set { this.ngayHetHan = value; }
        }

        public string MucHuong
        {
            get => this.mucHuong;
            set { this.mucHuong = value; }
        }

        public string TrangThaiXoa
        {
            get => this.trangThaiXoa;
            set { this.trangThaiXoa = value; }
        }
    }
}
