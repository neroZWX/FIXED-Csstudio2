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
        public const string connectionstring = "datasource= edgu.lt; database=cs-studio2; user=nero; pwd=971370106";
        public static MySqlConnection Connect() {
            MySqlConnection conn = new MySqlConnection(connectionstring);
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
