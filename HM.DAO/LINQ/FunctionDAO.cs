using HM.DTO;
using System.Collections.Generic;
using System.Linq;

namespace HM.DAO.LINQ
{
    public class FunctionDAO
    {
        public List<FunctionDTO> GetAllFunction()
        {
            using (var context = new DatabaseContext())
            {
                return context.ChucNangs
                .Select(a => new FunctionDTO
                 {
                     MaCN = a.MaCN,
                     TenCN = a.TenCN
                 })
                 .ToList();
            }
        }
    }
}