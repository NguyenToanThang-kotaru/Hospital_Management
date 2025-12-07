using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO.ADO
{
    public class DiseaseDAO
    {
        public int AddDisease(DiseaseDTO obj)
        {
            string sql = "INSERT INTO benh (MaBenh, TenBenh, MoTaBenh, TrangThaiXoa) " +
                         "VALUES (@MaBenh, @TenBenh, @MoTaBenh, @TrangThaiXoa)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenh", obj.MaBenh);
                        cmd.Parameters.AddWithValue("@TenBenh", obj.TenBenh);
                        cmd.Parameters.AddWithValue("@MoTaBenh", obj.MoTaBenh);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bệnh: " + ex.Message);
            }
            return 0;
        }

        public int UpdateDisease(DiseaseDTO obj)
        {
            string sql = "UPDATE benh SET TenBenh = @TenBenh, MoTaBenh = @MoTaBenh, TrangThaiXoa = @TrangThaiXoa " +
                         "WHERE MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenh", obj.MaBenh);
                        cmd.Parameters.AddWithValue("@TenBenh", obj.TenBenh);
                        cmd.Parameters.AddWithValue("@MoTaBenh", obj.MoTaBenh);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật bệnh: " + ex.Message);
            }
            return 0;   
        }

        public int DeleteDisease(string maBenh)
        {
            string sql = "UPDATE benh SET TrangThaiXoa = 1 WHERE MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenh", maBenh);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bệnh: " + ex.Message);
            }
            return 0;
        }

        public List<DiseaseDTO> GetAllDiseases()
        {
            List<DiseaseDTO> list = new List<DiseaseDTO>();
            string sql = "SELECT * FROM benh WHERE TrangThaiXoa = 0";
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
                                list.Add(new DiseaseDTO
                                {
                                    MaBenh = reader["MaBenh"].ToString(),
                                    TenBenh = reader["TenBenh"].ToString(),
                                    MoTaBenh = reader["MoTaBenh"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách bệnh: " + ex.Message);
            }
            return list;
        }

        public DiseaseDTO GetDiseaseById(string maBenh)
        {
            string sql = "SELECT * FROM benh WHERE MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenh", maBenh);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DiseaseDTO
                                {
                                    MaBenh = reader["MaBenh"].ToString(),
                                    TenBenh = reader["TenBenh"].ToString(),
                                    MoTaBenh = reader["MoTaBenh"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin bệnh: " + ex.Message);
            }
            return null;
        }

        public string GetNextDiseaseId()
        {
            string sql = "SELECT MaBenh FROM benh ORDER BY MaBenh DESC LIMIT 1";
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
                            string lastID = result.ToString(); // Ví dụ: "BENH0007"
                            int number = 0;

                            if (int.TryParse(lastID.Substring(4), out number))
                            {
                                number++;
                                return "BENH" + number.ToString("D4"); // => BENH0008
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã bệnh tiếp theo: " + ex.Message);
            }
            return "BENH0001";
        }

        public List<DiseaseDTO> SearchDiseaseByName(string keyword)
        {
            List<DiseaseDTO> list = new List<DiseaseDTO>();
            string sql = "SELECT * FROM benh WHERE TenBenh LIKE CONCAT('%', @keyword, '%') AND TrangThaiXoa = '0'";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", keyword);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new DiseaseDTO
                                {
                                    MaBenh = reader["MaBenh"].ToString(),
                                    TenBenh = reader["TenBenh"].ToString(),
                                    MoTaBenh = reader["MoTaBenh"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm bệnh: " + ex.Message);
            }

            return list;
        }
    }
}
