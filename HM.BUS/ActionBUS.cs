using HM.DTO;
using HM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BUS
{
    public class ActionBUS
    {
        private ActionDAO actionDAO;

        public ActionBUS()
        {
            actionDAO = new ActionDAO();
        }

        public List<ActionDTO> GetAllAction()
        {
            return actionDAO.GetAllAction();
        }
    }
}
