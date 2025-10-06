using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // Khoa
    internal class DepartmentDTO
    {
        private string makhoa;
        private string tenkhoa;
        private string soluong;

        public DepartmentDTO()
        {
            this.makhoa = " ";
            this.tenkhoa = " ";
            this.soluong = " ";
        }

        public DepartmentDTO(string makhoa, string tenkhoa, string soluong)
        {
            this.makhoa = makhoa;
            this.tenkhoa = tenkhoa;
            this.soluong = soluong;
        }

        public string Makhoa
        {
            get => makhoa;
            set { makhoa = value; }
        }

        public string Tenkhoa
        {
            get => tenkhoa;
            set { tenkhoa = value; }
        }

        public string Soluong
        {
            get => soluong;
            set { soluong = value; }
        }
    }
}
