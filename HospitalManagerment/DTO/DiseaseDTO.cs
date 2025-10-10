using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DTO
{
    // Bệnh
    internal class DiseaseDTO
    {
        private string maBenh;
        private string tenBenh;
        private string moTaBenh;
        private string trangThaiXoa;

        public DiseaseDTO()
        {
            maBenh = string.Empty;
            tenBenh = string.Empty;
            moTaBenh = string.Empty;
            trangThaiXoa = "0";
        }

        public DiseaseDTO(string maBenh, string tenBenh, string moTaBenh, string trangThaiXoa = "0")
        {
            this.maBenh = maBenh;
            this.tenBenh = tenBenh;
            this.moTaBenh = moTaBenh;
            this.trangThaiXoa = trangThaiXoa;
        }

        public string MaBenh
        {
            get => maBenh;
            set => maBenh = value;
        }

        public string TenBenh
        {
            get => tenBenh;
            set => tenBenh = value;
        }

        public string MoTaBenh
        {
            get => moTaBenh;
            set => moTaBenh = value;
        }

        public string TrangThaiXoa
        {
            get => trangThaiXoa;
            set => trangThaiXoa = value;
        }

    }
}
