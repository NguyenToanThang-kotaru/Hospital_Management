using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.DTO
{
    public class StatisticDTO
    {
        private string tenDV;
        private string soLan;
        private string tongTien;
       
        public StatisticDTO()
        {
            this.tenDV = string.Empty;
            this.soLan = string.Empty;
            this.tongTien = string.Empty;
        }

        public StatisticDTO(string tenDV, string soLan, string tongTien)
        {
            this.tenDV = tenDV;
            this.soLan = soLan;
            this.tongTien = tongTien;
        }

        public String TenDV 
        {
            get => tenDV;
            set => tenDV = value;
        }

        public String SoLan
        {
            get => soLan;
            set => soLan = value;
        }

        public String TongTien
        {
            get => tongTien;
            set => tongTien = value;
        }
    }
}
