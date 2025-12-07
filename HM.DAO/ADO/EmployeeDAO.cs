using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO
{
    public class EmployeeDAO
    {
        public string GetNextEmployeeId()
        {
            string nextId = "NV000001";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MaNV FROM nhanvien ORDER BY CAST(SUBSTRING(MaNV, 3) AS UNSIGNED) DESC LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            string lastId = result.ToString();
                            if (lastId.StartsWith("NV") && int.TryParse(lastId.Substring(2), out int numericPart))
                            {
                                numericPart++;
                                nextId = "NV" + numericPart.ToString("D6");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi sinh mã NV: {ex.Message}");
            }
            return nextId;
        }

        public List<EmployeeDTO> SearchEmployee(string keyword)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"
                        SELECT MaNV, TenNV, SdtNV, ChucVu, VaiTro, MaKhoa
                        FROM nhanvien
                        WHERE TrangThaiXoa = 0
                          AND (
                                TenNV LIKE CONCAT('%', @Keyword, '%')
                                OR SdtNV LIKE CONCAT('%', @Keyword, '%')
                                OR ChucVu LIKE CONCAT('%', @Keyword, '%')
                                OR VaiTro LIKE CONCAT('%', @Keyword, '%')
                                OR MaKhoa LIKE CONCAT('%', @Keyword, '%')
                              )";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new EmployeeDTO
                                {
                                    MaNV = reader["MaNV"].ToString(),
                                    TenNV = reader["TenNV"].ToString(),
                                    SdtNV = reader["SdtNV"].ToString(),
                                    ChucVu = reader["ChucVu"].ToString(),
                                    VaiTro = reader["VaiTro"].ToString(),
                                    MaKhoa = reader["MaKhoa"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm nhân viên: {ex.Message}");
            }
            return employees;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM nhanvien WHERE TrangThaiXoa = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeDTO
                            {
                                MaNV = reader["MaNV"].ToString(),
                                TenNV = reader["TenNV"].ToString(),
                                SdtNV = reader["SdtNV"].ToString(),
                                ChucVu = reader["ChucVu"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                MaKhoa = reader["MaKhoa"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
            }
            return employees;
        }

        public EmployeeDTO GetEmployeeById(string id)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = "SELECT * FROM nhanvien WHERE MaNV = @MaNV AND TrangThaiXoa = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new EmployeeDTO
                                {
                                    MaNV = reader["MaNV"].ToString(),
                                    TenNV = reader["TenNV"].ToString(),
                                    SdtNV = reader["SdtNV"].ToString(),
                                    ChucVu = reader["ChucVu"].ToString(),
                                    VaiTro = reader["VaiTro"].ToString(),
                                    MaKhoa = reader["MaKhoa"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString(),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy nhân viên theo ID: {ex.Message}");
            }
            return null;
        }

        public bool AddEmployee(EmployeeDTO employee)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                        INSERT INTO nhanvien (MaNV, TenNV, SdtNV, ChucVu, VaiTro, MaKhoa, TrangThaiXoa)
                        VALUES (@MaNV, @TenNV, @SdtNV, @ChucVu, @VaiTro, @MaKhoa, 0)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                        cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
                        cmd.Parameters.AddWithValue("@SdtNV", employee.SdtNV);
                        cmd.Parameters.AddWithValue("@ChucVu", employee.ChucVu);
                        cmd.Parameters.AddWithValue("@VaiTro", employee.VaiTro);
                        cmd.Parameters.AddWithValue("@MaKhoa", employee.MaKhoa);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm nhân viên: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"
                        UPDATE nhanvien
                        SET TenNV = @TenNV,
                            SdtNV = @SdtNV,
                            ChucVu = @ChucVu,
                            VaiTro = @VaiTro,
                            MaKhoa = @MaKhoa
                        WHERE MaNV = @MaNV AND TrangThaiXoa = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                        cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
                        cmd.Parameters.AddWithValue("@SdtNV", employee.SdtNV);
                        cmd.Parameters.AddWithValue("@ChucVu", employee.ChucVu);
                        cmd.Parameters.AddWithValue("@VaiTro", employee.VaiTro);
                        cmd.Parameters.AddWithValue("@MaKhoa", employee.MaKhoa);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật nhân viên: {ex.Message}");
                return false;
            }
        }

        public bool DeleteEmployee(string employeeId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"
                        UPDATE nhanvien
                        SET TrangThaiXoa = 1
                        WHERE MaNV = @MaNV";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", employeeId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xoá nhân viên: {ex.Message}");
                return false;
            }
        }

        public List<EmployeeDTO> GetAllEmployeesDoNotHaveAccount()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"
                        SELECT nv.MaNV, nv.TenNV, nv.SdtNV, nv.ChucVu, nv.VaiTro, nv.MaKhoa
                        FROM nhanvien nv
                        LEFT JOIN taikhoan tk 
                               ON nv.MaNV = tk.MaNV AND tk.TrangThaiXoa = 0
                        WHERE nv.TrangThaiXoa = 0 AND tk.MaNV IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new EmployeeDTO
                            {
                                MaNV = reader["MaNV"].ToString(),
                                TenNV = reader["TenNV"].ToString(),
                                SdtNV = reader["SdtNV"].ToString(),
                                ChucVu = reader["ChucVu"].ToString(),
                                VaiTro = reader["VaiTro"].ToString(),
                                MaKhoa = reader["MaKhoa"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhân viên chưa có tài khoản: {ex.Message}");
            }
            return employees;
        }

        public List<EmployeeDTO> GetAllEmployeesByDepartmentId(string departmentId)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"
                SELECT MaNV, TenNV, SdtNV, ChucVu, VaiTro, MaKhoa
                FROM nhanvien
                WHERE TrangThaiXoa = 0
                  AND MaKhoa = @MaKhoa";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", departmentId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new EmployeeDTO
                                {
                                    MaNV = reader["MaNV"].ToString(),
                                    TenNV = reader["TenNV"].ToString(),
                                    SdtNV = reader["SdtNV"].ToString(),
                                    ChucVu = reader["ChucVu"].ToString(),
                                    VaiTro = reader["VaiTro"].ToString(),
                                    MaKhoa = reader["MaKhoa"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhân viên theo khoa: {ex.Message}");
            }

            return employees;
        }

        public int CountHeadOfDepartment(string maKhoa)
        {
            int count = 0;

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"SELECT COUNT(*) FROM nhanvien WHERE TrangThaiXoa = 0 AND MaKhoa = @MaKhoa AND ChucVu = 'Trưởng khoa'";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            count = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra số lượng Trưởng khoa: {ex.Message}");
            }

            return count;
        }


    }
}

