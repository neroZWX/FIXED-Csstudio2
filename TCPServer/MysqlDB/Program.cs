using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MysqlDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectioStr = "DataBase=testgame;Data Source= 127.0.0.1; port =3306;User Id = root; Password =;";
            MySqlConnection conn = new MySqlConnection(connectioStr);
            conn.Open();
            #region Check the database
            //MySqlCommand cmd = new MySqlCommand("select * from user ",conn);

            //MySqlDataReader reader =cmd.ExecuteReader();

            //while (reader.Read()) {

            //    //reader.Read();
            //    string Username = reader.GetString("username");
            //    string Password = reader.GetString("password");
            //    Console.WriteLine(Username + ":" + Password);
            //}
            //reader.Close();
            //conn.Close();
            #endregion
            #region Add
            //string username = "jimmy";
            //string password = "jimmy;com;";
            //MySqlCommand cmd = new MySqlCommand("insert into user set username =@un, password=@pwd", conn);
            //// add user info to database
            //cmd.Parameters.AddWithValue("un", username);
            //cmd.Parameters.AddWithValue("pwd", password);
            //// excute 
            //cmd.ExecuteNonQuery();
            #endregion
            #region Delete
            //MySqlCommand cmd = new MySqlCommand("delete from user where id = @id", conn);
            //cmd.Parameters.AddWithValue("id", 3);
            //cmd.ExecuteNonQuery();
            #endregion
            #region
            //MySqlCommand cmd = new MySqlCommand("update user set password=@paw where id = 1", conn);
            //cmd.Parameters.AddWithValue("paw", "123456");
            //cmd.ExecuteNonQuery();
            #endregion
            conn.Close();
            Console.ReadKey();
        }
    }
}
