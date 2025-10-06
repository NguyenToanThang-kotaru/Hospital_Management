using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HospitalManagerment.DAO
{
    internal class DatabaseConnection
    {

            private static string connectionString = "server=localhost;port=3306;database=hospital;uid=root;password=;SslMode=none;";
            private static MySqlConnection connection;

            // Lấy kết nối
            public static MySqlConnection GetConnection()
            {
                if (connection == null)
                    connection = new MySqlConnection(connectionString);
                return connection;
            }

            // Mở kết nối
            public static void Open()
            {
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();
            }

            // Đóng kết nối
            public static void Close()
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
            }
    }
}
