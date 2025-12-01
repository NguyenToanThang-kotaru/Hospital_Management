using System.ComponentModel.DataAnnotations;

namespace HM.DTO
{
    public class ActionDTO
    {

        public ActionDTO() { }

        public ActionDTO(string maHD, string tenHD)
        {
            this.MaHD = maHD;
            this.TenHD = tenHD;
        }

        [Key]
        public string MaHD { get; set; }
        public string TenHD { get; set; }
    }
}
