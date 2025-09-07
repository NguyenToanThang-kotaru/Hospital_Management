using MySql.Data.MySqlClient;

namespace Hospital_Management.DAL
{
    public static class DatabaseConnection
    {
        // ⚠️ Thay đổi thông tin theo XAMPP của bạn
        private static string server = "localhost";   // thường là localhost
        private static string database = "hospital_db"; // tên database trong phpMyAdmin
        private static string username = "root";      // mặc định của XAMPP là root
        private static string password = "";          // mặc định để trống (nếu chưa set)

        private static string connectionString =
            $"Server={server};Database={database};Uid={username};Pwd={password};SslMode=none;";

        /// <summary>
        /// Lấy kết nối mới tới MySQL
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        
         public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true; // Kết nối thành công
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
                return false;
            }
        }
    }
}
