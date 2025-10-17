using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    //Dược phẩm
    internal class MedicineDTO
    {
        private string maDP;
        private string tenDP;
        private string loaiDP;
        public MedicineDTO()
        {
            this.maDP = " ";
            this.tenDP = " ";
            this.loaiDP = " ";
        }
        public MedicineDTO(string maDP, string tenDP, string loaiDP)
        {
            this.maDP = maDP;
            this.tenDP = tenDP;
            this.loaiDP = loaiDP;
        }
        public string MaDP
        {
            get => maDP;
            set { maDP = value; }
        }
        public string TenDP
        {
            get => tenDP;
            set { tenDP = value; }
        }
        public string LoaiDP
        {
            get => loaiDP;
            set { loaiDP = value; }
        }
    }
}
