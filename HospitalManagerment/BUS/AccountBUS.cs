using HospitalManagerment.DTO;
using HospitalManagerment.DAO;
using HospitalManagerment.Utils;
using System;
using System.Text.RegularExpressions;
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

        // Hàm kiểm tra login
        public bool Login(AccountDTO account, out string errorMessage)
        {
            // Validation
            if (!ValidateAccount(account, out errorMessage))
            {
                return false;
            }

            // Gọi DAO để kiểm tra database
            return accountDAO.Login(account, out errorMessage);
        }

        // Hàm validation
        private bool ValidateAccount(AccountDTO account, out string errorMessage)
        {
            errorMessage = "";

            if (Validators.IsEmpty(account.TenDangNhap))
            {
                errorMessage = "Tên đăng nhập không được để trống!";
                return false;
            }

            if (Validators.IsEmpty(account.MatKhau))
            {
                errorMessage = "Mật khẩu không được để trống!";
                return false;
            }

            // Ví dụ thêm: kiểm tra định dạng username (chỉ chữ và số)
            //if (!Regex.IsMatch(account.TenDangNhap, @"^[a-zA-Z]+$"))
            //{
            //    errorMessage = "Tên đăng nhập chỉ được chứa chữ và số!";
            //    return false;
            //}

            // Thêm các rule mật khẩu nếu muốn, ví dụ: ít nhất 6 ký tự
            if (account.MatKhau.Length < 6)
            {
                errorMessage = "Mật khẩu phải có ít nhất 6 ký tự!";
                return false;
            }

            return true;
        }

        public List<AccountDTO> GetAllAccount()
        {
            return accountDAO.GetAllAccount();
        }
    }
}
