using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    //Đăng ký dịch vụ
    internal class ServiceRegistrationDTO
    {
        private string maDKDV;
        private string soCCCD;
        private string ngayGioTao;
        private string trangThaiDK;
        private string tongChiPhi;
        private string hinhThucTT;
        private string maNV;
        public ServiceRegistrationDTO()
        {
            this.maDKDV = " ";
            this.soCCCD = " ";
            this.ngaGioTao = " ";
            this.trangThaiDK = " ";
            this.tongChiPhi = " ";
            this.hinhThucTT = " ";
            this.maNV = " ";
        }
        public ServiceRegistrationDTO(string maDKDV, string soCCCD, string ngayGioTao, string trangThaiDK, string tongChiPhi, string hinhThucTT, string maNV)
        {
            this.maDKDV = maDKDV;
            this.soCCCD = soCCCD;
            this.ngayGioTao = ngayGioTao;
            this.trangThaiDK = trangThaiDK;
            this.tongChiPhi = tongChiPhi;
            this.hinhThucTT = hinhThucTT;
            this.maNV = maNV;
        }
        public string MaDKDV
        {
            get => maDKDV;
            set { maDKDV = value; }
        }
        public string SoCCCD
        {
            get => soCCCD;
            set { soCCCD = value; }
        }
        public string NgayGioTao
        {
            get => ngayGioTao;
            set { ngayGioTao = value; }
        }
        public string TrangThaiDK
        {
            get => trangThaiDK;
            set { trangThaiDK = value; }
        }
        public string TongChiPhi
        {
            get => tongChiPhi;
            set { tongChiPhi = value; }
        }
        public string HinhThucTT
        {
            get => hinhThucTT;
            set { hinhThucTT = value; }
        }
        public string MaNV
        {
            get => maNV;
            set { maNV = value; }
        }
    }
}
