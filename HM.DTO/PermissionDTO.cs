using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    // Quyền
    public class PermissionDTO
    {
        private string maQuyen;
        private string tenQuyen;
        private string trangThaiXoa; 

        public PermissionDTO()
        {
            maQuyen = string.Empty;
            tenQuyen = string.Empty;
            trangThaiXoa = "0"; 
        }

        public PermissionDTO(string maQuyen, string tenQuyen, string trangThaiXoa = "0")
        {
            this.maQuyen = maQuyen;
            this.tenQuyen = tenQuyen;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaQuyen
        {
            get => maQuyen;
            set => maQuyen = value;
        }

        public string TenQuyen
        {
            get => tenQuyen;
            set => tenQuyen = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}
