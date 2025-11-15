using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class PatientDAO
    {
        //public bool IsDuplicateCCCD(string soCCCD)
        //{
        //    using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //    {
        //        DatabaseConnection.Open(conn);
        //        string query = "SELECT COUNT(*) FROM benhnhan WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0";

        //        using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);
        //            int count = Convert.ToInt32(cmd.ExecuteScalar());
        //            DatabaseConnection.Close(conn);
        //            return count > 0;
        //        }
        //    }
        //}

        //public List<PatientDTO> SearchPatientBy(string keyword)
        //{
        //    List<PatientDTO> patients = new List<PatientDTO>();

        //    try
        //    {
        //        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //        {
        //            DatabaseConnection.Open(conn);

        //            string query = @"
        //            SELECT SoCCCD, TenBN, SoBHYT, NgaySinh, GioiTinh, SdtBN, DiaChi
        //            FROM benhnhan
        //            WHERE TrangThaiXoa = 0
        //              AND (
        //                    TenBN LIKE CONCAT('%', @Keyword, '%')
        //                    OR SoCCCD LIKE CONCAT('%', @Keyword, '%')
        //                    OR SoBHYT LIKE CONCAT('%', @Keyword, '%')
        //                  )";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@Keyword", keyword);

        //                using (MySqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        PatientDTO p = new PatientDTO
        //                        {
        //                            SoCCCD = reader["SoCCCD"].ToString(),
        //                            TenBN = reader["TenBN"].ToString(),
        //                            SoBHYT = reader["SoBHYT"].ToString(),
        //                            NgaySinh = reader["NgaySinh"].ToString(),
        //                            GioiTinh = reader["GioiTinh"].ToString(),
        //                            SdtBN = reader["SdtBN"].ToString(),
        //                            DiaChi = reader["DiaChi"].ToString()
        //                        };

        //                        patients.Add(p);
        //                    }
        //                }
        //            }

        //            DatabaseConnection.Close(conn);
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        Console.WriteLine($"Loi CSDL: {ex.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Loi: {ex.Message}");
        //    }

        //    return patients;
        //}

        //public List<PatientDTO> GetAllPatients()
        //{
        //    List<PatientDTO> patients = new List<PatientDTO>();

        //    try
        //    {
        //        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //        {
        //            conn.Open();
        //            string query = "SELECT * FROM benhnhan WHERE TrangThaiXoa = 0";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            using (MySqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    patients.Add(new PatientDTO
        //                    {
        //                        SoCCCD = reader["SoCCCD"].ToString(),
        //                        TenBN = reader["TenBN"].ToString(),
        //                        SoBHYT = reader["SoBHYT"].ToString(),
        //                        NgaySinh = reader["NgaySinh"].ToString(),
        //                        GioiTinh = reader["GioiTinh"].ToString(),
        //                        SdtBN = reader["SdtBN"].ToString(),
        //                        DiaChi = reader["DiaChi"].ToString(),
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi lấy danh sách bệnh nhân: " + ex.Message);
        //    }
        //    return patients;
        //}

        //public PatientDTO GetPatientById(string soCCCD, out string errorMessage)
        //{
        //    errorMessage = string.Empty;

        //    try
        //    {
        //        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //        {
        //            DatabaseConnection.Open(conn);

        //            string query = "SELECT * FROM benhnhan WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);

        //                using (MySqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        PatientDTO patient = new PatientDTO
        //                        {
        //                            SoCCCD = reader["SoCCCD"].ToString(),
        //                            TenBN = reader["TenBN"].ToString(),
        //                            SoBHYT = reader["SoBHYT"].ToString(),
        //                            NgaySinh = reader["NgaySinh"].ToString(),
        //                            GioiTinh = reader["GioiTinh"].ToString(),
        //                            SdtBN = reader["SdtBN"].ToString(),
        //                            DiaChi = reader["DiaChi"].ToString(),
        //                        };

        //                        DatabaseConnection.Close(conn);
        //                        return patient;
        //                    }
        //                    else
        //                    {
        //                        errorMessage = "Không tìm thấy bệnh nhân!";
        //                        DatabaseConnection.Close(conn);
        //                        return null;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
        //        return null;
        //    }
        //}
        //public bool AddPatient(PatientDTO patient, out string errorMessage)
        //{
        //    errorMessage = string.Empty;

        //    try
        //    {
        //        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //        {
        //            DatabaseConnection.Open(conn);

        //            string query = @"INSERT INTO benhnhan
        //            (SoCCCD, TenBN, SoBHYT, NgaySinh, GioiTinh, SdtBN, DiaChi, TrangThaiXoa)
        //            VALUES (@SoCCCD, @TenBN, @SoBHYT, @NgaySinh, @GioiTinh, @SdtBN, @DiaChi, 0)";


        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@SoCCCD", patient.SoCCCD);
        //                cmd.Parameters.AddWithValue("@TenBN", patient.TenBN);
        //                cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
        //                cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
        //                cmd.Parameters.AddWithValue("@SdtBN", patient.SdtBN);
        //                cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);
        //                if (string.IsNullOrEmpty(patient.SoBHYT))
        //                    cmd.Parameters.AddWithValue("@SoBHYT", DBNull.Value);
        //                else
        //                    cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT);

        //                int rows = cmd.ExecuteNonQuery();
        //                DatabaseConnection.Close(conn);

        //                if (rows > 0)
        //                    return true;
        //                else
        //                {
        //                    errorMessage = "Không thể thêm bệnh nhân vào cơ sở dữ liệu!";
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
        //        return false;
        //    }
        //}


        //public bool UpdatePatient(PatientDTO patient, string oldSoCCCD, out string errorMessage)
        //{
        //    errorMessage = string.Empty;

        //    try
        //    {
        //        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //        {
        //            DatabaseConnection.Open(conn);

        //            string query = @"UPDATE benhnhan
        //                     SET SoCCCD = @NewSoCCCD,
        //                         TenBN = @TenBN,
        //                         SoBHYT = @SoBHYT,
        //                         NgaySinh = @NgaySinh,
        //                         GioiTinh = @GioiTinh,
        //                         SdtBN = @SdtBN,
        //                         DiaChi = @DiaChi
        //                     WHERE SoCCCD = @OldSoCCCD AND TrangThaiXoa = 0";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@NewSoCCCD", patient.SoCCCD);
        //                cmd.Parameters.AddWithValue("@TenBN", patient.TenBN);
        //                cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
        //                cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
        //                cmd.Parameters.AddWithValue("@SdtBN", patient.SdtBN);
        //                cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);
        //                cmd.Parameters.AddWithValue("@OldSoCCCD", oldSoCCCD);
        //                if (string.IsNullOrEmpty(patient.SoBHYT))
        //                    cmd.Parameters.AddWithValue("@SoBHYT", DBNull.Value);
        //                else
        //                    cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT);

        //                int rows = cmd.ExecuteNonQuery();
        //                DatabaseConnection.Close(conn);

        //                if (rows > 0)
        //                    return true;
        //                else
        //                {
        //                    errorMessage = "Không tìm thấy bệnh nhân hoặc không thể cập nhật!";
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
        //        return false;
        //    }
        //}

        //public bool DeletePatient(string soCCCD, out string errorMessage)
        //{
        //    errorMessage = string.Empty;

        //    try
        //    {
        //        using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //        {
        //            DatabaseConnection.Open(conn);

        //            string query = "UPDATE benhnhan SET TrangThaiXoa = 1 WHERE SoCCCD = @SoCCCD";

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);

        //                int rows = cmd.ExecuteNonQuery();
        //                DatabaseConnection.Close(conn);

        //                return rows > 0;
        //            }
        //        }
        //    }
        //    catch (MySqlException ex)
        //    {
        //        errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = $"Đã xảy ra lỗi: {ex.Message}";
        //        return false;
        //    }
        //}

        public bool IsDuplicateCCCD(string soCCCD)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                DatabaseConnection.Open(conn);
                string query = "SELECT COUNT(*) FROM benhnhan WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    DatabaseConnection.Close(conn);
                    return count > 0;
                }
            }
        }

        public List<PatientDTO> SearchPatientBy(string keyword)
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"
                SELECT SoCCCD, TenBN, SoBHYT, NgaySinh, GioiTinh, SdtBN, DiaChi
                FROM benhnhan
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tìm kiếm bệnh nhân: {ex.Message}");
            }

            return patients;
        }

        public List<PatientDTO> GetAllPatients()
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM benhnhan WHERE TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new PatientDTO
                            {
                                SoCCCD = reader["SoCCCD"].ToString(),
                                TenBN = reader["TenBN"].ToString(),
                                SoBHYT = reader["SoBHYT"].ToString(),
                                NgaySinh = reader["NgaySinh"].ToString(),
                                GioiTinh = reader["GioiTinh"].ToString(),
                                SdtBN = reader["SdtBN"].ToString(),
                                DiaChi = reader["DiaChi"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách bệnh nhân: " + ex.Message);
            }
            return patients;
        }

        public PatientDTO GetPatientById(string soCCCD)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = "SELECT * FROM benhnhan WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PatientDTO patient = new PatientDTO
                                {
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    TenBN = reader["TenBN"].ToString(),
                                    SoBHYT = reader["SoBHYT"].ToString(),
                                    NgaySinh = reader["NgaySinh"].ToString(),
                                    GioiTinh = reader["GioiTinh"].ToString(),
                                    SdtBN = reader["SdtBN"].ToString(),
                                    DiaChi = reader["DiaChi"].ToString(),
                                };
                                DatabaseConnection.Close(conn);
                                return patient;
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
                Console.WriteLine("Lỗi lấy bệnh nhân theo CCCD: " + ex.Message);
                return null;
            }
        }

        public bool AddPatient(PatientDTO patient)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"INSERT INTO benhnhan
            (SoCCCD, TenBN, SoBHYT, NgaySinh, GioiTinh, SdtBN, DiaChi, TrangThaiXoa)
            VALUES (@SoCCCD, @TenBN, @SoBHYT, @NgaySinh, @GioiTinh, @SdtBN, @DiaChi, 0)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", patient.SoCCCD);
                        cmd.Parameters.AddWithValue("@TenBN", patient.TenBN);
                        cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
                        cmd.Parameters.AddWithValue("@SdtBN", patient.SdtBN);
                        cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);
                        cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT);

                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);

                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm bệnh nhân: " + ex.Message);
                return false;
            }
        }

        public bool UpdatePatient(PatientDTO patient, string oldSoCCCD)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = @"UPDATE benhnhan
                     SET SoCCCD = @NewSoCCCD,
                         TenBN = @TenBN,
                         SoBHYT = @SoBHYT,
                         NgaySinh = @NgaySinh,
                         GioiTinh = @GioiTinh,
                         SdtBN = @SdtBN,
                         DiaChi = @DiaChi
                     WHERE SoCCCD = @OldSoCCCD AND TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewSoCCCD", patient.SoCCCD);
                        cmd.Parameters.AddWithValue("@TenBN", patient.TenBN);
                        cmd.Parameters.AddWithValue("@NgaySinh", patient.NgaySinh);
                        cmd.Parameters.AddWithValue("@GioiTinh", patient.GioiTinh);
                        cmd.Parameters.AddWithValue("@SdtBN", patient.SdtBN);
                        cmd.Parameters.AddWithValue("@DiaChi", patient.DiaChi);
                        cmd.Parameters.AddWithValue("@OldSoCCCD", oldSoCCCD);
                        if (string.IsNullOrEmpty(patient.SoBHYT))
                            cmd.Parameters.AddWithValue("@SoBHYT", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@SoBHYT", patient.SoBHYT);

                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);

                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật bệnh nhân: " + ex.Message);
                return false;
            }
        }

        public bool DeletePatient(string soCCCD)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    DatabaseConnection.Open(conn);
                    string query = "UPDATE benhnhan SET TrangThaiXoa = 1 WHERE SoCCCD = @SoCCCD";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);
                        int rows = cmd.ExecuteNonQuery();
                        DatabaseConnection.Close(conn);
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xoá bệnh nhân: " + ex.Message);
                return false;
            }
        }


    }
}
