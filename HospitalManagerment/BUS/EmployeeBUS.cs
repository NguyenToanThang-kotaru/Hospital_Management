//using HospitalManagerment.DAO;
//using HospitalManagerment.DTO;
//using HospitalManagerment.Utils;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HospitalManagerment.BUS
//{
//    internal class EmployeeBUS
//    {
//        private EmployeeDAO employeeDAO;

//        public EmployeeBUS()
//        {
//            employeeDAO = new EmployeeDAO();
//        }
//        private bool ValidateInsertEmployee(EmployeeDTO employee, out string errorMessage)
//        {
//            errorMessage = "";
//            if (!Validators.CheckEmpty(employee.TenNV, "tên nhân viên", out errorMessage)) return false;

//            if (!Validators.IsValidPhone(employee.SdtNV))
//            {
//                errorMessage = "Số điện thoại không hợp lệ";
//                return false;
//            }
//            return true;
//        }

//        public EmployeeDTO GetEmployeeByID(string employeeID, out string errorMessage)
//        {
//            return employeeDAO.GetEmployeeById(employeeID, out errorMessage);
//        }

//        public List<EmployeeDTO> SearchEmployee(string keyword, out string errorMessage)
//        {
//            return employeeDAO.SearchEmployeeBy(keyword, out  errorMessage);
//        }

//        public List<EmployeeDTO> GetAllEmployees(out string errorMessage)
//        {
//            return employeeDAO.GetAllEmployees(out errorMessage);
//        }

//        public bool AddEmployee(EmployeeDTO employee, out string errorMessage)
//        {
//            if(!ValidateInsertEmployee(employee, out errorMessage))
//            {
//                return false;
//            }

//            return employeeDAO.AddEmployee(employee, out errorMessage);
//        }

//        public bool UpdateEmployee(EmployeeDTO employee, out string errorMessage)
//        {
//            if (!ValidateInsertEmployee(employee, out errorMessage))
//            {
//                return false;
//            }

//            return employeeDAO.UpdateEmployee(employee, out errorMessage);
//        }

//        public bool DeleteEmployee(string employeeID, out string errorMessage)
//        {
//            return employeeDAO.DeleteEmployee(employeeID, out errorMessage);
//        }
//    }
//}

using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;

namespace HospitalManagerment.BUS
{
    internal class EmployeeBUS
    {
        private EmployeeDAO employeeDAO;

        public EmployeeBUS()
        {
            employeeDAO = new EmployeeDAO();
        }

        private void ValidateInsertEmployee(EmployeeDTO employee)
        {
            string errorMessage;
            if (!Validators.CheckEmpty(employee.TenNV, "tên nhân viên", out errorMessage))
                throw new ArgumentException(errorMessage);

            if (!Validators.IsValidPhone(employee.SdtNV))
                throw new ArgumentException("Số điện thoại không hợp lệ");
        }

        public EmployeeDTO GetEmployeeByID(string employeeID)
        {
            var emp = employeeDAO.GetEmployeeById(employeeID);
            if (emp == null)
                throw new Exception("Không tìm thấy nhân viên!");
            return emp;
        }

        public List<EmployeeDTO> SearchEmployee(string keyword)
        {
            var result = employeeDAO.SearchEmployeeBy(keyword);
            if (result.Count == 0)
                throw new Exception("Không tìm thấy nhân viên phù hợp!");
            return result;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            return employeeDAO.GetAllEmployees();
        }

        public bool AddEmployee(EmployeeDTO employee)
        {
            ValidateInsertEmployee(employee);
            if (!employeeDAO.AddEmployee(employee))
                throw new Exception("Thêm nhân viên thất bại!");
            return true;
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            ValidateInsertEmployee(employee);
            if (!employeeDAO.UpdateEmployee(employee))
                throw new Exception("Cập nhật nhân viên thất bại!");
            return true;
        }

        public bool DeleteEmployee(string employeeID)
        {
            if (!employeeDAO.DeleteEmployee(employeeID))
                throw new Exception("Xóa nhân viên thất bại!");
            return true;
        }
    }
}
