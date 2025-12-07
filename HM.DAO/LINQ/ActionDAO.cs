using HM.DTO;
using System.Collections.Generic;
using System.Linq;

namespace HM.DAO.LINQ
{
    public class ActionDAO
    {
        public List<ActionDTO> GetAllAction()
        {
            using (var context = new DatabaseContext())
            {
                return context.HanhDongs
                             .Select(a => new ActionDTO
                             {
                                 MaHD = a.MaHD,
                                 TenHD = a.TenHD
                             })
                             .ToList();
            }
        }
    }
}