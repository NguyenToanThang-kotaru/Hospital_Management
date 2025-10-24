using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // bệnh nhân
    internal class PatientDTO
    {
        private string soCCCD;
        private string tenBN;
        private string soBHYT;
        private string ngaySinh;
        private string gioiTinh;
        private string sdtBN;
        private string diaChi;
        private string trangThaiXoa;

        public PatientDTO()
        {
            this.soCCCD = string.Empty;
            this.tenBN = string.Empty;
            this.soBHYT = string.Empty;
            this.ngaySinh = string.Empty;
            this.gioiTinh = string.Empty;
            this.sdtBN = string.Empty;
            this.diaChi = string.Empty;
            this.trangThaiXoa = "0";
        }

        public PatientDTO(string soCCCD, string tenBN, string soBHYT, string ngaySinh, string gioiTinh, string sdtBN, string diaChi, string trangThaiXoa = "0")
        {
            this.soCCCD = soCCCD;
            this.tenBN = tenBN;
            this.soBHYT = soBHYT;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.sdtBN = sdtBN;
            this.diaChi = diaChi;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string SoCCCD
        {
            get => this.soCCCD;
            set { this.soCCCD = value; }
        }

        public string TenBN
        {
            get => this.tenBN;
            set { this.tenBN = value; }
        }

        public string SoBHYT
        {
            get => this.soBHYT;
            set { this.soBHYT = value; }
        }

        public string NgaySinh
        {
            get => this.ngaySinh;
            set { this.ngaySinh = value; }
        }

        public string GioiTinh
        {
            get => this.gioiTinh;
            set { this.gioiTinh = value; }
        }

        public string SdtBN
        {
            get => this.sdtBN;
            set { this.sdtBN = value; }
        }

        public string DiaChi
        {
            get => this.diaChi;
            set { this.diaChi = value; }
        }

        public string TrangThaiXoa
        {
            get => this.trangThaiXoa;
            set { this.trangThaiXoa = value; }
        }
    }
}
