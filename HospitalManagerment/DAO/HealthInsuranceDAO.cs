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

        public bool AddHealthInsurance(HealthInsuranceDTO bhyt, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                    INSERT INTO baohiemyte (SoBHYT, NgayCap, NgayHetHan, NoiDangKi, MucHuong, TrangThaiXoa)
                    VALUES (@SoBHYT, @NgayCap, @NgayHetHan, @NoiDangKi, @MucHuong, 0);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoBHYT", bhyt.SoBHYT);
                        cmd.Parameters.AddWithValue("@NgayCap", bhyt.NgayCap);
                        cmd.Parameters.AddWithValue("@NgayHetHan", bhyt.NgayHetHan);
                        cmd.Parameters.AddWithValue("@NoiDangKi", bhyt.NoiDangKi);
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
    }
}
