using System.ComponentModel.DataAnnotations;

namespace HospitalManagerment.DTO
{
    internal class FunctionDTO
    {
        public FunctionDTO() { }

        public FunctionDTO(string maCN, string tenCN)
        {
            MaCN = maCN;
            TenCN = tenCN;
        }

        [Key]
        public string MaCN { get; set; }
        public string TenCN { get; set; }
    }
}
