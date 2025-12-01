using HospitalManagerment.DAO;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public EmployeeDTO GetEmployeeById(string employeeID)
        {
            var emp = employeeDAO.GetEmployeeById(employeeID);
            if (emp == null)
                throw new Exception("Không tìm thấy nhân viên!");
            return emp;
        }

        public List<EmployeeDTO> SearchEmployee(string keyword)
        {
            return employeeDAO.SearchEmployee(keyword);
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

        public string GetNextEmployeeId()
        {
            return employeeDAO.GetNextEmployeeId();
        }

        public bool ExistsEmployeeId(string maNV)
        {
            return GetAllEmployees().Any(sv => sv.MaNV == maNV);
        }

        public List<EmployeeDTO> GetAllEmployeesDoNotHaveAccount()
        {
            return employeeDAO.GetAllEmployeesDoNotHaveAccount();
        }

        public List<EmployeeDTO> GetAllEmployeesByDepartmentId(string id)
        {
            return employeeDAO.GetAllEmployeesByDepartmentId(id);
        }

        public bool CountHeadOfDepartment(string maKhoa)
        {
            return employeeDAO.CountHeadOfDepartment(maKhoa) >= 1;
        }
    }
}
