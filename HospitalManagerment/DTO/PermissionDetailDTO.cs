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
        private string maquyen;
        private string macd;
        private string mahd;

        public PermissionDetailDTO()
        {
            this.maquyen = " ";
            this.macd = " ";
            this.mahd = " ";
        }

        public PermissionDetailDTO(string maquyen, string macd, string mahd)
        {
            this.maquyen = maquyen;
            this.macd = macd;
            this.mahd = mahd;
        }

        public string Maquyen
        {
            get => maquyen;
            set { maquyen = value; }
        }

        public string Macd
        {
            get => macd;
            set { macd = value; }
        }

        public string Mahd
        {
            get => mahd;
            set { mahd = value; }
        }
    }
}
