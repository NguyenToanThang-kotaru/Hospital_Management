using System.ComponentModel.DataAnnotations;

namespace HM.DTO
{
    public class ActionDTO
    {
        [Key]
        public string MaHD { get; set; }
        public string TenHD { get; set; }

        public ActionDTO() { }

        public ActionDTO(string maHD, string tenHD)
        {
            this.MaHD = maHD;
            this.TenHD = tenHD;
        }

        
    }
}
