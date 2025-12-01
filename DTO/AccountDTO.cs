using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class AccountDTO
    {
        private string tenDangNhap;
        private string matKhau;
        private string maQuyen;
        private string maNV;
        private string trangThaiXoa;

        public AccountDTO()
        {
            this.tenDangNhap = "";
            this.matKhau = "";
            this.maQuyen = "";
            this.maNV = "";
            this.trangThaiXoa = "0";
        }

        public AccountDTO(string tenDangNhap, string matKhau, string maQuyen, string maNV, string trangThaiXoa = "0")
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.maQuyen = maQuyen;
            this.maNV = maNV;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string TenDangNhap
        {
            get => this.tenDangNhap;
            set { this.tenDangNhap = value; }
        }

        public string MatKhau
        {
            get => this.matKhau;
            set { this.matKhau = value; }
        }

        public string MaQuyen
        {
            get => this.maQuyen;
            set { this.maQuyen = value; }
        }

        public string MaNV
        {
            get => this.maNV;
            set { this.maNV = value; }
        }

        public string TrangThaiXoa
        {
            get => this.trangThaiXoa;
            set { this.trangThaiXoa = value; }
        }
    }
}
