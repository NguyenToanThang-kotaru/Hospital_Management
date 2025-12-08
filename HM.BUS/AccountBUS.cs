using HM.DTO;
using HM.DAO.ADO;
using HM.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HM.BUS
{
    public class AccountBUS
    {
        private AccountDAO accountDAO;

        public AccountBUS()
        {
            accountDAO = new AccountDAO();
        }

        private bool ValidateAccount(AccountDTO account, out string errorMessage)
        {
            errorMessage = "";

            if (!Validators.CheckEmpty(account.TenDangNhap, "tên đăng nhập", out errorMessage)) return false;

            if (!Validators.CheckEmpty(account.MatKhau, "mật khẩu", out errorMessage)) return false;


            if (account.MatKhau.Length < 6)
            {
                errorMessage = "Mật khẩu phải có ít nhất 6 ký tự!";
                return false;
            }

            return true;
        }
        public bool Login(AccountDTO account, out string errorMessage)
        {
            if (!ValidateAccount(account, out errorMessage))
            {
                return false;
            }
            return accountDAO.Login(account, out errorMessage);
        }

        public List<AccountDTO> GetAllAccount()
        {
            return accountDAO.GetAllAccount();
        }

        public List<AccountDTO> SearchAccount(string keyword)
        {
            return accountDAO.SearchAccountBy(keyword);
        }

        public bool AddAccount(AccountDTO account)
        {
            string errorMessage;
            if (!Validators.CheckEmpty(account.TenDangNhap, "Tên đăng nhập", out errorMessage))
                throw new ArgumentException(errorMessage);

            if (!Validators.CheckEmpty(account.MatKhau, "Mật khẩu", out errorMessage))
                throw new ArgumentException(errorMessage);

            if (!Validators.CheckEmpty(account.MaQuyen, "", out errorMessage, "Vui lòng chọn quyền cho tài khoản!"))
                throw new ArgumentException(errorMessage);

            if (!accountDAO.AddAccount(account))
                throw new Exception("Không thể thêm tài khoản vào cơ sở dữ liệu!");
            return true;
        }

        public bool UpdateAccount(AccountDTO account, string oldUsername)
        {
            var oldAccount = accountDAO.GetAccountByUsername(oldUsername);
            if (oldAccount == null)
                throw new Exception("Không tìm thấy tài khoản để cập nhật!");

            if (!accountDAO.UpdateAccount(account, oldUsername))
                throw new Exception("Không thể cập nhật tài khoản!");
            return true;
        }

        public bool DeleteAccount(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Tên đăng nhập không hợp lệ!");
            if (!accountDAO.DeleteAccount(username))
                throw new Exception("Không thể xoá tài khoản!");
            return true;
        }

        public AccountDTO GetAccountByUsername(string username)
        {
            return accountDAO.GetAccountByUsername(username);
        }

        public bool ExistsAccountUsername(string username)
        {
            return GetAllAccount().Any( sv => sv.TenDangNhap == username);
        }

        //
        public AccountDTO GetAccountByEmployeeId(string employeeId)
        { 
            return accountDAO.GetAccountByEmployeeId(employeeId);
        }
        public List<string> GetFunctionsWithViewPermission(string username)
        {
            return accountDAO.getFunctionsWithViewPermission(username);
        }

        public bool HasPermission(string username, string maCN, string maHD)
        {
            return accountDAO.HasPermission(username, maCN, maHD);
        }

    }
}

