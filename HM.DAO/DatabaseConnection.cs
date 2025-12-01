using MySql.Data.MySqlClient;

namespace HM.DAO
{
    internal static class DatabaseConnection
    {
        private static readonly string connectionString =
            "server=localhost;port=3306;database=hospital;uid=root;password=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public static void Open(MySqlConnection conn)
        {
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();
        }

        public static void Close(MySqlConnection conn)
        {
            if (conn.State != System.Data.ConnectionState.Closed)
                conn.Close();
        }
    }
}