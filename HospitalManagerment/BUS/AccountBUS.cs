//using HospitalManagerment.DTO;
//using HospitalManagerment.DAO;
//using HospitalManagerment.Utils;
//using System;
//using System.Text.RegularExpressions;
//using System.Collections.Generic;

//namespace HospitalManagerment.BUS
//{
//    internal class AccountBUS
//    {
//        private AccountDAO accountDAO;

//        public AccountBUS()
//        {
//            accountDAO = new AccountDAO();
//        }

//        // Hàm validation
//        private bool ValidateAccount(AccountDTO account, out string errorMessage)
//        {
//            errorMessage = "";

//            if (!Validators.CheckEmpty(account.TenDangNhap, "tên đăng nhập", out errorMessage)) return false;

//            if (!Validators.CheckEmpty(account.MatKhau, "mật khẩu", out errorMessage)) return false;


//            if (account.MatKhau.Length < 6)
//            {
//                errorMessage = "Mật khẩu phải có ít nhất 6 ký tự!";
//                return false;
//            }

//            return true;
//        }

//        // Hàm kiểm tra login
//        public bool Login(AccountDTO account, out string errorMessage)
//        {
//            // Validation
//            if (!ValidateAccount(account, out errorMessage))
//            {
//                return false;
//            }

//            // Gọi DAO để kiểm tra database
//            return accountDAO.Login(account, out errorMessage);
//        }

//        public List<AccountDTO> GetAllAccount()
//        {
//            return accountDAO.GetAllAccount();
//        }

//        public bool CreateAccount(AccountDTO account,out string message)
//        {
//            if (!Validators.CheckEmpty(account.TenDangNhap, "Tên đăng nhập", out message)) return false;

//            if (!Validators.CheckEmpty(account.MatKhau, "Mật khẩu", out message)) return false;

//            if (!Validators.CheckEmpty(account.MaQuyen, "", out message, 
//                "Vui lòng chọn quyền cho tài khoản!")) return false;

//            bool result = accountDAO.AddAccount(account, out string daoMessage);

//            if (result)
//            {
//                message = "Thêm tài khoản thành công!";
//                return true;
//            }
//            else
//            {
//                message = daoMessage;
//                return false;
//            }
//        }
//    }
//}

using HospitalManagerment.DTO;
using HospitalManagerment.DAO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;

namespace HospitalManagerment.BUS
{
    internal class AccountBUS
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

        // Trả về tất cả tài khoản
        public List<AccountDTO> GetAllAccount()
        {
            return accountDAO.GetAllAccount();
        }

        // Tìm kiếm tài khoản theo keyword (tenDangNhap, MaNV)
        public List<AccountDTO> SearchAccount(string keyword)
        {
            return accountDAO.SearchAccountBy(keyword);
        }

        // Thêm tài khoản
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

        // Cập nhật tài khoản
        public bool UpdateAccount(AccountDTO account)
        {
            if (!accountDAO.UpdateAccount(account))
                throw new Exception("Không thể cập nhật tài khoản!");
            return true;
        }

        // Xoá tài khoản
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
     }
}

