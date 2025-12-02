using HM.DTO;
using HM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BUS
{
    public class FunctionBUS
    {
        private FunctionDAO functionDAO;

        public FunctionBUS() 
        { 
            functionDAO = new FunctionDAO();
        }

        public List<FunctionDTO> GetAllFunction()
        {
            return functionDAO.GetAllFunction();
        }
    }
}
