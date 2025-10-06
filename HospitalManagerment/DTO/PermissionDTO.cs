using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // Quyền
    internal class PermissionDTO
    {
        private string maquyen;
        private string tenquyen;

        public PermissionDTO()
        {
            this.maquyen = " ";
            this.tenquyen = " ";
        }

        public PermissionDTO(string maquyen, string tenquyen)
        {
            this.maquyen = maquyen;
            this.tenquyen = tenquyen;
        }

        public string Maquyen
        {
            get => maquyen;
            set { maquyen = value; }
        }

        public string Tenquyen
        {
            get => tenquyen;
            set { tenquyen = value; }
        }
    }
}
