using HospitalManagerment.DTO;
using HospitalManagerment.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.BUS
{
    internal class ActionBUS
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
