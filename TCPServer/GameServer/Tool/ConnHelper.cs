using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GameServer.Tool
{
    class ConnHelper
    {
        public const string ConnectionString = "datasouce= 127.0.0.1; port= 3306; database=cs-studio2; user=root;pwd= ";
        public static MySqlConnection Connect() {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception e) {
                Console.WriteLine("expection when connected the database");
                return null;
            }
            
        }
        public static void CloseConnection(MySqlConnection conn) {
            if (conn != null)
                conn.Close();
            else {
                Console.WriteLine("MySqlConnection can not be null!");
            }


        }
    }
}
