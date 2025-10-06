using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class EmployeeDTO
    {
        private string maNV;
        private string tenNV;
        private string sdtNV;
        private string chucVu;
        private string vaiTro;
        private string maKhoa;
        private string trangThaiXoa;

        public EmployeeDTO()
        {
            this.maNV = " ";
            this.tenNV = " ";
            this.sdtNV = " ";
            this.chucVu = " ";
            this.vaiTro = " ";
            this.maKhoa = " ";
            this.trangThaiXoa = " ";
        }

        public EmployeeDTO(string maNV, string tenNV, string sdtNV, string chucVu, string vaiTro, string maKhoa,
         string trangThaiXoa)
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.sdtNV = sdtNV;
            this.chucVu = chucVu;
            this.vaiTro = vaiTro;
            this.maKhoa = maKhoa;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaNV
        {
            get => this.maNV;
            set { this.maNV = value; }
        }

        public string TenNV
        {
            get => this.tenNV;
            set { this.tenNV = value; }
        }

        public string SdtNV
        {
            get => this.sdtNV;
            set { this.sdtNV = value; }
        }

        public string ChucVu
        {
            get => this.chucVu;
            set { this.chucVu = value; }
        }

        public string VaiTro
        {
            get => this.vaiTro;
            set { this.vaiTro = value; }
        }

        public string MaKhoa
        {
            get => this.maKhoa;
            set { this.maKhoa = value; }
        }

        public string TrangThaiXoa
        {
            get => this.trangThaiXoa;
            set { this.trangThaiXoa = value; }
        }
    }
}
