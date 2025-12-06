using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.DAO
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