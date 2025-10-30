//using HospitalManagerment.DTO;
//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;

//namespace HospitalManagerment.DAO
//{
//    internal class EmployeeDAO
//    {
//        public string GetNextEmployeeId(out string errorMessage)
//        {
//            errorMessage = string.Empty;
//            string nextId = "NV000001";

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    conn.Open();
//                    string query = "SELECT MaNV FROM nhanvien ORDER BY CAST(SUBSTRING(MaNV, 3) AS UNSIGNED) DESC LIMIT 1";
//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    {
//                        object result = cmd.ExecuteScalar();
//                        if (result != null)
//                        {
//                            string lastId = result.ToString();
//                            if (lastId.StartsWith("NV") && int.TryParse(lastId.Substring(2), out int numericPart))
//                            {
//                                numericPart++;
//                                nextId = "NV" + numericPart.ToString("D6");
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Lỗi khi sinh mã NV: {ex.Message}";
//            }

//            return nextId;
//        }

//        public List<EmployeeDTO> SearchEmployeeBy(string keyword, out string errorMessage)
//        {
//            errorMessage = string.Empty;
//            List<EmployeeDTO> employees = new List<EmployeeDTO>();

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    DatabaseConnection.Open(conn);

//                    string query = @"
//                        SELECT MaNV, TenNV, SdtNV, ChucVu, VaiTro, MaKhoa
//                        FROM nhanvien
//                        WHERE TrangThaiXoa = 0
//                          AND (
//                                TenNV LIKE CONCAT('%', @Keyword, '%')
//                                OR SdtNV LIKE CONCAT('%', @Keyword, '%')
//                                OR ChucVu LIKE CONCAT('%', @Keyword, '%')
//                                OR VaiTro LIKE CONCAT('%', @Keyword, '%')
//                                OR MaKhoa LIKE CONCAT('%', @Keyword, '%')
//                              )";

//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@Keyword", keyword);

//                        using (MySqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            while (reader.Read())
//                            {
//                                employees.Add(new EmployeeDTO
//                                {
//                                    MaNV = reader["MaNV"].ToString(),
//                                    TenNV = reader["TenNV"].ToString(),
//                                    SdtNV = reader["SdtNV"].ToString(),
//                                    ChucVu = reader["ChucVu"].ToString(),
//                                    VaiTro = reader["VaiTro"].ToString(),
//                                    MaKhoa = reader["MaKhoa"].ToString(),
//                                });
//                            }
//                        }
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
//            }

//            return employees;
//        }

//        public List<EmployeeDTO> GetAllEmployees(out string errorMessage)
//        {
//            errorMessage = string.Empty;
//            List<EmployeeDTO> employees = new List<EmployeeDTO>();

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    conn.Open();
//                    string query = "SELECT * FROM nhanvien WHERE TrangThaiXoa = 0";

//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    using (MySqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            employees.Add(new EmployeeDTO
//                            {
//                                MaNV = reader["MaNV"].ToString(),
//                                TenNV = reader["TenNV"].ToString(),
//                                SdtNV = reader["SdtNV"].ToString(),
//                                ChucVu = reader["ChucVu"].ToString(),
//                                VaiTro = reader["VaiTro"].ToString(),
//                                MaKhoa = reader["MaKhoa"].ToString(),
//                            });
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Lỗi khi lấy danh sách nhân viên: {ex.Message}";
//            }

//            return employees;
//        }

//        public EmployeeDTO GetEmployeeById(string id, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    DatabaseConnection.Open(conn);

//                    string query = "SELECT * FROM nhanvien WHERE MaNV = @MaNV AND TrangThaiXoa = 0";

//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaNV", id);

//                        using (MySqlDataReader reader = cmd.ExecuteReader())
//                        {
//                            if (reader.Read())
//                            {
//                                return new EmployeeDTO
//                                {
//                                    MaNV = reader["MaNV"].ToString(),
//                                    TenNV = reader["TenNV"].ToString(),
//                                    SdtNV = reader["SdtNV"].ToString(),
//                                    ChucVu = reader["ChucVu"].ToString(),
//                                    VaiTro = reader["VaiTro"].ToString(),
//                                    MaKhoa = reader["MaKhoa"].ToString(),
//                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString(),
//                                };
//                            }
//                            else
//                            {
//                                errorMessage = "Không tìm thấy nhân viên!";
//                                return null;
//                            }
//                        }
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
//                return null;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
//                return null;
//            }
//        }

//        public bool AddEmployee(EmployeeDTO employee, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    DatabaseConnection.Open(conn);

//                    string nextId = GetNextEmployeeId(out string idError);
//                    if (!string.IsNullOrEmpty(idError))
//                    {
//                        errorMessage = idError;
//                        return false;
//                    }

//                    string query = @"
//                        INSERT INTO nhanvien (MaNV, TenNV, SdtNV, ChucVu, VaiTro, MaKhoa, TrangThaiXoa)
//                        VALUES (@MaNV, @TenNV, @SdtNV, @ChucVu, @VaiTro, @MaKhoa, 0)";
//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaNV", nextId);
//                        cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
//                        cmd.Parameters.AddWithValue("@SdtNV", employee.SdtNV);
//                        cmd.Parameters.AddWithValue("@ChucVu", employee.ChucVu);
//                        cmd.Parameters.AddWithValue("@VaiTro", employee.VaiTro);
//                        cmd.Parameters.AddWithValue("@MaKhoa", employee.MaKhoa);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        return rowsAffected > 0;
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
//                return false;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
//                return false;
//            }
//        }

//        public bool UpdateEmployee(EmployeeDTO employee, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    DatabaseConnection.Open(conn);

//                    string query = @"
//                        UPDATE nhanvien
//                        SET TenNV = @TenNV,
//                            SdtNV = @SdtNV,
//                            ChucVu = @ChucVu,
//                            VaiTro = @VaiTro,
//                            MaKhoa = @MaKhoa
//                        WHERE MaNV = @MaNV AND TrangThaiXoa = 0";

//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
//                        cmd.Parameters.AddWithValue("@TenNV", employee.TenNV);
//                        cmd.Parameters.AddWithValue("@SdtNV", employee.SdtNV);
//                        cmd.Parameters.AddWithValue("@ChucVu", employee.ChucVu);
//                        cmd.Parameters.AddWithValue("@VaiTro", employee.VaiTro);
//                        cmd.Parameters.AddWithValue("@MaKhoa", employee.MaKhoa);

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        return rowsAffected > 0;
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
//                return false;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
//                return false;
//            }
//        }

//        public bool DeleteEmployee(string employeeId, out string errorMessage)
//        {
//            errorMessage = string.Empty;

//            try
//            {
//                using (MySqlConnection conn = DatabaseConnection.GetConnection())
//                {
//                    DatabaseConnection.Open(conn);

//                    string query = @"
//                        UPDATE nhanvien
//                        SET TrangThaiXoa = 1
//                        WHERE MaNV = @MaNV";

//                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
//                    {
//                        cmd.Parameters.AddWithValue("@MaNV", employeeId);
//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        return rowsAffected > 0;
//                    }
//                }
//            }
//            catch (MySqlException ex)
//            {
//                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
//                return false;
//            }
//            catch (Exception ex)
//            {
//                errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
//                return false;
//            }
//        }
//    }
//}

using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace HospitalManagerment.DAO
{
    internal class EmployeeDAO
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

        public List<EmployeeDTO> SearchEmployeeBy(string keyword)
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

                    string nextId = GetNextEmployeeId();

                    string query = @"
                        INSERT INTO nhanvien (MaNV, TenNV, SdtNV, ChucVu, VaiTro, MaKhoa, TrangThaiXoa)
                        VALUES (@MaNV, @TenNV, @SdtNV, @ChucVu, @VaiTro, @MaKhoa, 0)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", nextId);
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
    }
}

