using System;

namespace HospitalManagerment.DTO
{
    // Thuốc
    internal class MedicineDTO
    {
        private string maDP;
        private string tenDP;
        private string loaiDP;
        private string trangThaiXoa;

        public MedicineDTO()
        {
            this.maDP = string.Empty;
            this.tenDP = string.Empty;
            this.loaiDP = string.Empty;
            this.trangThaiXoa = "0";
        }

        public MedicineDTO(string maDP, string tenDP, string loaiDP, string trangThaiXoa = "0")
        {
            this.maDP = maDP;
            this.tenDP = tenDP;
            this.loaiDP = loaiDP;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaDP
        {
            get => maDP;
            set => maDP = value;
        }

        public string TenDP
        {
            get => tenDP;
            set => tenDP = value;
        }

        public string LoaiDP
        {
            get => loaiDP;
            set => loaiDP = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}
