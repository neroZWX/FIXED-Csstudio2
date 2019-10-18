using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Model;
using MySql.Data.MySqlClient;

namespace GameServer.DAO
{
    class ResultDAO
    {
        public Result GetResultByUserid(MySqlConnection conn, int userID) {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select*from result where userid = @userid", conn);
                cmd.Parameters.AddWithValue("userid", userID);
                
                reader = cmd.ExecuteReader();
                //当读取到数据的时候
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    int totalCount = reader.GetInt32("totalmatch");
                    int winCount = reader.GetInt32("wincount");

                    Result res = new Result(id,userID, totalCount, winCount);
                    return res;
                }
                else
                {
                    Result res = new Result(-1, userID, 0, 0);
                    return res;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception while getUserID infromation" + e);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return null;
        }
    }
}
