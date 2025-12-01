using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    // chỉ định dịch vụ
    public class ServiceDesignationDTO
    {
        private string maPCD;
        private string soCCCD;
        private string maNV;
        private string maDV;
        private string ngayGioTaoPhieu;
        private string trangThaiXoa;

        public ServiceDesignationDTO()
        {
            this.maPCD = string.Empty;
            this.soCCCD = string.Empty;
            this.maNV = string.Empty;
            this.maDV = string.Empty;
            this.ngayGioTaoPhieu = string.Empty;
            this.trangThaiXoa = "0";
        }

        public ServiceDesignationDTO(string maPCD, string soCCCD, string maNV, string maDV, string ngayGioTaoPhieu, string trangThaiXoa = "0")
        {
            this.maPCD = maPCD;
            this.soCCCD = soCCCD;
            this.maNV = maNV;
            this.maDV = maDV;
            this.ngayGioTaoPhieu = ngayGioTaoPhieu;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaPCD
        {
            get => maPCD;
            set => maPCD = value;
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

        public string MaDV
        {
            get => maDV;
            set => maDV = value;
        }

        public string NgayGioTaoPhieu
        {
            get => ngayGioTaoPhieu;
            set => ngayGioTaoPhieu = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}
