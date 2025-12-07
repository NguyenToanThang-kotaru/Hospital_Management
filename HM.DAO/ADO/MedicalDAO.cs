using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO.ADO
{
    public class MedicalDAO
    {
        public int AddMedical(MedicalDTO obj)
        {
            string sql = "INSERT INTO benhan (MaBA, SoCCCD, MaNV, NgayTao, TrangThaiXoa) " +
                         "VALUES (@MaBA, @SoCCCD, @MaNV, @NgayTao, @TrangThaiXoa)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);
                        cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bệnh án: " + ex.Message);
            }
            return 0;
        }

        public int UpdateMedical(MedicalDTO obj)
        {
            string sql = "UPDATE benhan SET SoCCCD = @SoCCCD, MaNV = @MaNV, NgayTao = @NgayTao, TrangThaiXoa = @TrangThaiXoa " +
                         "WHERE MaBA = @MaBA";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);
                        cmd.Parameters.AddWithValue("@NgayTao", obj.NgayTao);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bệnh án: " + ex.Message);
            }
            return 0;
        }

        public int DeleteMedical(string maBA)
        {
            string sql = "UPDATE benhan SET TrangThaiXoa = 1 WHERE MaBA = @MaBA";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bệnh án: " + ex.Message);
            }
            return 0;
        }

        public List<MedicalDTO> GetAllMedicals()
        {
            List<MedicalDTO> list = new List<MedicalDTO>();
            string sql = "SELECT * FROM benhan WHERE TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new MedicalDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    NgayTao = reader["NgayTao"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách bệnh án: " + ex.Message);
            }
            return list;
        }

        public MedicalDTO GetMedicalById(string maBA)
        {
            string sql = "SELECT * FROM benhan WHERE MaBA = @MaBA AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new MedicalDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    NgayTao = reader["NgayTao"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin bệnh án: " + ex.Message);
            }
            return null;
        }

        public string GetNextMedicalId()
        {
            string sql = "SELECT MaBA FROM benhan ORDER BY MaBA DESC LIMIT 1";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string lastID = result.ToString(); 
                            int number = 0;

                            if (int.TryParse(lastID.Substring(2), out number))
                            {
                                number++;
                                return "BA" + number.ToString("D6"); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã bệnh án tiếp theo: " + ex.Message);
            }
            return "BA000001";
        }

        public List<MedicalDTO> SearchMedicalByName(string keyword)
        {
            List<MedicalDTO> list = new List<MedicalDTO>();
            string sql = "SELECT * FROM benhan WHERE SoCCCD LIKE @keyword AND TrangThaiXoa = 0";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new MedicalDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    NgayTao = reader["NgayTao"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm bệnh án: " + ex.Message);
            }

            return list;
        }

        public List<MedicalDTO> GetAllMedicalsByPatientId(string soCCCD)
        {
            List<MedicalDTO> list = new List<MedicalDTO>();
            string sql = "SELECT * FROM benhan WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0 ORDER BY NgayTao DESC";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new MedicalDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    NgayTao = reader["NgayTao"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách bệnh án theo bệnh nhân: " + ex.Message);
            }
            return list;
        }
    }
}
