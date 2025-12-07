using System.ComponentModel.DataAnnotations;

namespace HM.DTO
{
    public class RoleDTO
    {
        [Key]
        public string MaVT { get; set; }
        public string TenVT { get; set; }
        public string TrangThaiXoa { get; set; }

        public RoleDTO() { }
        public RoleDTO(string maVT, string tenVT, string trangThaiXoa = "0")
        {
            this.MaVT = maVT;
            this.TenVT = tenVT;
            this.TrangThaiXoa = trangThaiXoa;
        }
    }
}
