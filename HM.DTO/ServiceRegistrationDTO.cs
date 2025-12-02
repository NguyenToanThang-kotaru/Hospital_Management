using System;

namespace HM.DTO
{
    // đăng ký dịch vụ
    public class ServiceRegistrationDTO
    {
        private string maDKDV;
        private string soCCCD;
        private string ngayGioTaoPhieu;
        private string trangThaiDangKy;
        private string tongChiPhi;
        private string hinhThucThanhToan;
        private string maNV;
        private string trangThaiXoa;

        public ServiceRegistrationDTO()
        {
            this.maDKDV = string.Empty;
            this.soCCCD = string.Empty;
            this.ngayGioTaoPhieu = string.Empty;
            this.trangThaiDangKy = string.Empty;
            this.tongChiPhi = string.Empty;
            this.hinhThucThanhToan = string.Empty;
            this.maNV = string.Empty;
            this.trangThaiXoa = "0";
        }

        public ServiceRegistrationDTO( string maDKDV, string soCCCD, string ngayGioTaoPhieu, string trangThaiDangKy, string tongChiPhi, string hinhThucThanhToan, string maNV, string trangThaiXoa = "0")
        {
            this.maDKDV = maDKDV;
            this.soCCCD = soCCCD;
            this.ngayGioTaoPhieu = ngayGioTaoPhieu;
            this.trangThaiDangKy = trangThaiDangKy;
            this.tongChiPhi = tongChiPhi;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maNV = maNV;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaDKDV
        {
            get => maDKDV;
            set => maDKDV = value;
        }

        public string SoCCCD
        {
            get => soCCCD;
            set => soCCCD = value;
        }

        public string NgayGioTaoPhieu
        {
            get => ngayGioTaoPhieu;
            set => ngayGioTaoPhieu = value;
        }

        public string TrangThaiDangKy
        {
            get => trangThaiDangKy;
            set => trangThaiDangKy = value;
        }

        public string TongChiPhi
        {
            get => tongChiPhi;
            set => tongChiPhi = value;
        }

        public string HinhThucThanhToan
        {
            get => hinhThucThanhToan;
            set => hinhThucThanhToan = value;
        }

        public string MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}
