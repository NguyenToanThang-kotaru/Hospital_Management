using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DAO
{
    internal class HealthInsuranceDAO
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

        public HealthInsuranceDTO GetHealthInsuranceById(string soBHYT, out string errorMessage)
        {
            errorMessage = string.Empty;

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
                                    SoBHYT = reader.GetString("SoBHYT"),
                                    NgayCap = reader.GetString("NgayCap"),
                                    NgayHetHan = reader.GetString("NgayHetHan"),
                                    MucHuong = reader.GetString("MucHuong"),
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
            catch (MySqlException ex)
            {
                errorMessage = $"Lỗi CSDL khi lấy BHYT: {ex.Message}";
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi lấy BHYT: {ex.Message}";
                return null;
            }
        }
        public bool AddHealthInsurance(HealthInsuranceDTO bhyt, out string errorMessage)
        {
            errorMessage = string.Empty;
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

                        if (rows > 0)
                            return true;
                        else
                        {
                            errorMessage = "Không tìm thấy bệnh nhân hoặc không thể cập nhật!";
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Lỗi CSDL khi thêm BHYT: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi thêm BHYT: {ex.Message}";
                return false;
            }
        }

        public bool UpdateHealthInsurance(HealthInsuranceDTO bhyt, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                    UPDATE baohiemyte
                    SET NgayCap = @NgayCap,
                        NgayHetHan = @NgayHetHan,
                        MucHuong = @MucHuong
                    WHERE SoBHYT = @SoBHYT AND TrangThaiXoa = 0;";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoBHYT", bhyt.SoBHYT);
                        cmd.Parameters.AddWithValue("@NgayCap", bhyt.NgayCap);
                        cmd.Parameters.AddWithValue("@NgayHetHan", bhyt.NgayHetHan);
                        cmd.Parameters.AddWithValue("@MucHuong", bhyt.MucHuong);
                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);
                        if (rows > 0)
                            return true;
                        else
                        {
                            errorMessage = "Không tìm thấy BHYT hoặc không thể cập nhật!";
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Lỗi CSDL khi cập nhật BHYT: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi cập nhật BHYT: {ex.Message}";
                return false;
            }
        }

        public bool DeleteHealthInsurance(string soBHYT, out string errorMessage)
        {
            errorMessage = string.Empty;
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
                        if (rows > 0)
                            return true;
                        else
                        {
                            errorMessage = "Không tìm thấy BHYT hoặc không thể xóa!";
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Lỗi CSDL khi xóa BHYT: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi xóa BHYT: {ex.Message}";
                return false;
            }
        }
    }
}
