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
        private string maKhoa;
        private string tenKhoa;
        private string soLuong;
        private string trangThaiXoa;

        public DepartmentDTO()
        {
            maKhoa = string.Empty;
            tenKhoa = string.Empty;
            soLuong = "0";
            trangThaiXoa = "0";
        }

        public DepartmentDTO(string maKhoa, string tenKhoa, string soLuong , string trangThaiXoa = "0")
        {
            this.maKhoa = maKhoa;
            this.tenKhoa = tenKhoa;
            this.soLuong = soLuong;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaKhoa
        {
            get => maKhoa;
            set => maKhoa = value;
        }

        public string TenKhoa
        {
            get => tenKhoa;
            set => tenKhoa = value;
        }

        public string SoLuong
        {
            get => soLuong;
            set => soLuong = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }
    }
}
