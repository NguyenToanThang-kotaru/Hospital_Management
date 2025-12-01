using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // Chi tiết quyền
    internal class PermissionDetailDTO
    {
        private string maQuyen;
        private string maHD;
        private string maCN;
        private string trangThaiKichHoat;

        public PermissionDetailDTO()
        {
            this.maQuyen = string.Empty;
            this.maHD = string.Empty;
            this.maCN = string.Empty;
            this.trangThaiKichHoat = "1";
        }

        public PermissionDetailDTO(string maQuyen, string maHD, string maCN, string trangThaiKichHoat = "1")
        {
            this.maQuyen = maQuyen;
            this.maHD = maHD;
            this.maCN = maCN;
            this.trangThaiKichHoat = trangThaiKichHoat;
        }

        public string MaQuyen
        {
            get => this.maQuyen;
            set { this.maQuyen = value; }
        }

        public string MaHD
        {
            get => this.maHD;
            set { this.maHD = value; }
        }

        public string MaCN
        {
            get => this.maCN;
            set { this.maCN = value; }
        }

        public string TrangThaiKichHoat
        {
            get => this.trangThaiKichHoat;
            set { this.trangThaiKichHoat = value; }
        }
    }
}
