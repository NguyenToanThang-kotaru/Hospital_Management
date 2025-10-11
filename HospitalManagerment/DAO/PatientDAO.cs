using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DAO
{
    internal class PatientDAO
    {
        public bool IsDuplicateCCCD(string soCCCD)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                DatabaseConnection.Open(conn);
                string query = "SELECT COUNT(*) FROM benh_nhan WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    DatabaseConnection.Close(conn);
                    return count > 0;
                }
            }
        }
        public bool IsDuplicateBHYT(string soBHYT)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                DatabaseConnection.Open(conn);

                string query = "SELECT COUNT(*) FROM benh_nhan WHERE SoBHYT = @SoBHYT AND TrangThaiXoa = 0";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoBHYT", soBHYT);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    DatabaseConnection.Close(conn);
                    return count > 0;
                }
            }
        }

        public bool InsertPatient(PatientDTO patient, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"INSERT INTO benh_nhan
                                    (SoCCCD, TenBN, SoBHYT, NgaySinh, GioiTinh, SdtBN, DiaChi, TrangThaiXoa)
                                     VALUES (@SoCCCD, @TenBN, @SoBHYT, @NgaySinh, @GioiTinh, @SdtBN, @DiaChi, 0)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", patient.SoCCCD);
                        cmd.Parameters.AddWithValue("@TenBN", patient.TenBN);
                        cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT ?? "");
                        cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
                        cmd.Parameters.AddWithValue("@SdtBN", patient.SdtBN);
                        cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);

                        int rows = cmd.ExecuteNonQuery();

                        DatabaseConnection.Close(conn);

                        if (rows > 0)
                            return true;
                        else
                        {
                            errorMessage = "Không thể thêm bệnh nhân vào cơ sở dữ liệu!";
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
                return false;
            }
        }

        public List<PatientDTO> SearchPatient(string keyword)
        {
            List<PatientDTO> patients = new List<PatientDTO>();

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);

                    string query = @"
                    SELECT SoCCCD, TenBN, SoBHYT, NgaySinh, GioiTinh, SdtBN, DiaChi
                    FROM benh_nhan
                    WHERE TrangThaiXoa = 0
                      AND (
                            TenBN LIKE CONCAT('%', @Keyword, '%')
                            OR SoCCCD LIKE CONCAT('%', @Keyword, '%')
                            OR SoBHYT LIKE CONCAT('%', @Keyword, '%')
                          )";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PatientDTO p = new PatientDTO
                                {
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    TenBN = reader["TenBN"].ToString(),
                                    SoBHYT = reader["SoBHYT"].ToString(),
                                    NgaySinh = reader["NgaySinh"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    SdtBN = reader["SdtBN"].ToString(),
                                    DiaChi = reader["DiaChi"].ToString()
                                };

                                patients.Add(p);
                            }
                        }
                    }

                    DatabaseConnection.Close(conn);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Loi CSDL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }

            return patients;
        }

    }
}
