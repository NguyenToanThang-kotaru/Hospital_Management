using HospitalManagerment.DTO;
using HospitalManagerment.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.BUS
{
    internal class FunctionBUS
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
