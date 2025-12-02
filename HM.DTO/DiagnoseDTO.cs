using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    // Chẩn đoán
    public class DiagnoseDTO
    {
        private string maBA;
        private string maBenh;
        private string ngayChanDoan;
        private string ketQuaDieuTri;

        public DiagnoseDTO()
        {
            maBA = string.Empty;
            maBenh = string.Empty;
            ngayChanDoan = string.Empty;
            ketQuaDieuTri = string.Empty;
        }

        public DiagnoseDTO(string maBA, string maBenh, string ngayChanDoan, string ketQuaDieuTri)
        {
            this.maBA = maBA;
            this.maBenh = maBenh;   
            this.ngayChanDoan = ngayChanDoan;
            this.ketQuaDieuTri = ketQuaDieuTri;
        }

        public string MaBA
        {
            get => maBA;
            set => maBA = value;
        }

        public string MaBenh
        {
            get => maBenh;
            set => maBenh = value;
        }

        public string NgayChanDoan
        {
            get => ngayChanDoan;
            set => ngayChanDoan = value;
        }

        public string KetQuaDieuTri
        {
            get => ketQuaDieuTri;
            set => ketQuaDieuTri = value;
        }
    }
}
