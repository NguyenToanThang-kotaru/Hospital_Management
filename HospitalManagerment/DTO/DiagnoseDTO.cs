using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // Chẩn đoán
    internal class DiagnoseDTO
    {
        private string maba;
        private string mabenh;
        private string ngaychandoan;
        private string ketquadieutri;

        public DiagnoseDTO()
        {
            this.maba = " ";
            this.mabenh = " ";
            this.ngaychandoan = " ";
            this.ketquadieutri = " ";
        }

        public DiagnoseDTO(string maba, string mabenh, string ngaychandoan, string ketquadieutri)
        {
            this.maba = maba;
            this.mabenh = mabenh;
            this.ngaychandoan = ngaychandoan;
            this.ketquadieutri = ketquadieutri;
        }

        public string Maba
        {
            get => maba;
            set { maba = value; }
        }

        public string Mabenh
        {
            get => mabenh;
            set { mabenh = value; }
        }

        public string Ngaychandoan
        {
            get => ngaychandoan;
            set { ngaychandoan = value; }
        }

        public string Ketquadieutri
        {
            get => ketquadieutri;
            set { ketquadieutri = value; }
        }
    }
}
