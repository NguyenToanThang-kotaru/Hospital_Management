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
                var functions = (from cn in context.ChucNangs
                                 select new FunctionDTO
                                 {
                                     MaCN = cn.MaCN,        
                                     TenCN = cn.TenCN      
                                 }).ToList();

                return functions;
            }
        }
    }
}