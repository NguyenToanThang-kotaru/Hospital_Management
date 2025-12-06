using System.ComponentModel.DataAnnotations;

namespace HM.DTO
{
    public class FunctionDTO
    {
        [Key]
        public string MaCN { get; set; }
        public string TenCN { get; set; }
        public FunctionDTO() { }

        public FunctionDTO(string maCN, string tenCN)
        {
            MaCN = maCN;
            TenCN = tenCN;
        }
    }
}
