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
        private string maCN;
        private string maHD;
        private string trangThaiKichHoat;

        public PermissionDetailDTO()
        {
            maQuyen = string.Empty;
            maHD = string.Empty;
            maCN = string.Empty;
            trangThaiKichHoat = "1";
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
            get => maQuyen;
            set => maQuyen = value;
        }

        public string MaCN
        {
            get => maCN;
            set => maCN = value;
        }

        public string MaHD
        {
            get => maHD;
            set => maHD = value;
        }
        
        public string TrangThaiKichHoat
        {
            get => trangThaiKichHoat;
            set => trangThaiKichHoat = value;
        }
    }
}
