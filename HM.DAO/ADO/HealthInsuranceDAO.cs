using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO.ADO
{
    public class HealthInsuranceDAO
    {
        public bool IsDuplicateBHYT(string soBHYT)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                DatabaseConnection.Open(conn);

                string query = "SELECT COUNT(*) FROM baohiemyte WHERE SoBHYT = @SoBHYT AND TrangThaiXoa = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoBHYT", soBHYT);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    DatabaseConnection.Close(conn);
                    return count > 0;
                }
            }
        }

        public HealthInsuranceDTO GetHealthInsuranceById(string soBHYT)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                        SELECT SoBHYT, NgayCap, NgayHetHan, MucHuong
                        FROM baohiemyte
                        WHERE SoBHYT = @SoBHYT AND TrangThaiXoa = 0;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoBHYT", soBHYT);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                HealthInsuranceDTO bhyt = new HealthInsuranceDTO
                                {
                                    SoBHYT = reader["SoBHYT"].ToString(),
                                    NgayCap = reader["NgayCap"].ToString(),
                                    NgayHetHan = reader["NgayHetHan"].ToString(),
                                    MucHuong = reader["MucHuong"].ToString(),
                                };
                                DatabaseConnection.Close(conn);
                                return bhyt;
                            }
                            else
                            {
                                DatabaseConnection.Close(conn);
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy BHYT: {ex.Message}");
                return null;
            }
        }

        public bool AddHealthInsurance(HealthInsuranceDTO bhyt)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                    INSERT INTO baohiemyte (SoBHYT, NgayCap, NgayHetHan, MucHuong, TrangThaiXoa)
                    VALUES (@SoBHYT, @NgayCap, @NgayHetHan, @MucHuong, 0);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoBHYT", bhyt.SoBHYT);
                        cmd.Parameters.AddWithValue("@NgayCap", bhyt.NgayCap);
                        cmd.Parameters.AddWithValue("@NgayHetHan", bhyt.NgayHetHan);
                        cmd.Parameters.AddWithValue("@MucHuong", bhyt.MucHuong);

                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);

                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm BHYT: {ex.Message}");
                return false;
            }
        }

        public bool UpdateHealthInsurance(HealthInsuranceDTO bhyt, string oldSoBHYT)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                        UPDATE baohiemyte
                        SET SoBHYT = @NewSoBHYT,
                            NgayCap = @NgayCap,
                            NgayHetHan = @NgayHetHan,
                            MucHuong = @MucHuong
                        WHERE SoBHYT = @OldSoBHYT AND TrangThaiXoa = 0;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewSoBHYT", bhyt.SoBHYT);
                        cmd.Parameters.AddWithValue("@NgayCap", bhyt.NgayCap);
                        cmd.Parameters.AddWithValue("@NgayHetHan", bhyt.NgayHetHan);
                        cmd.Parameters.AddWithValue("@MucHuong", bhyt.MucHuong);
                        cmd.Parameters.AddWithValue("@OldSoBHYT", oldSoBHYT);

                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật BHYT: {ex.Message}");
                return false;
            }
        }

        public bool DeleteHealthInsurance(string soBHYT)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                    UPDATE baohiemyte
                    SET TrangThaiXoa = 1
                    WHERE SoBHYT = @SoBHYT AND TrangThaiXoa = 0;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoBHYT", soBHYT);
                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa BHYT: {ex.Message}");
                return false;
            }
        }
    }
}
