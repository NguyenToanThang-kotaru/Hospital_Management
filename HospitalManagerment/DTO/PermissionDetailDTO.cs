using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    internal class PermissionDetailDTO
    {
        private string maQuyen;
        private string maHD;
        private string maCN;
        private string trangThaiKichHoat;

        public PermissionDetailDTO()
        {
            this.maQuyen = " ";
            this.maHD = " ";
            this.maCN = " ";
            this.trangThaiKichHoat = " ";
        }

        public PermissionDetailDTO(string maQuyen, string maHD, string maCN, string trangThaiKichHoat)
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
