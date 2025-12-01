using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    // Bệnh án
    public class MedicalDTO
    {
        private string maBA;
        private string soCCCD;
        private string maNV;
        private string ngayTao;
        private string trangThaiXoa; 

        public MedicalDTO()
        {
            maBA = string.Empty;
            soCCCD = string.Empty;
            maNV = string.Empty;
            ngayTao = string.Empty;
            trangThaiXoa = "0";
        }

        public MedicalDTO(string maBA, string soCCCD, string maNV, string ngayTao, string trangThaiXoa = "0")
        {
            this.maBA = maBA;
            this.soCCCD = soCCCD;
            this.maNV = maNV;
            this.ngayTao = ngayTao;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaBA
        {
            get => maBA;
            set => maBA = value;
        }

        public string SoCCCD
        {
            get => soCCCD;
            set => soCCCD = value;
        }

        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string NgayTao
        {
            get => ngayTao;
            set => ngayTao = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}
