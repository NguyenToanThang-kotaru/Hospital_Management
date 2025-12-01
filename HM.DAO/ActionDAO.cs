using HM.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.DAO
{
    public class ActionDAO
    {
        public List<ActionDTO> GetAllAction()
        {
            using (var context = new DatabaseContext())
            {
                var actions = (from a in context.HanhDongs
                               select new ActionDTO
                               {
                                   MaHD = a.MaHD, 
                                   TenHD = a.TenHD 
                               }).ToList();

                return actions;
            }
        }
    }
}