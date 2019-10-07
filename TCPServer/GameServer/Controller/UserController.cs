using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;
using GameServer.DAO;
using GameServer.Model;


namespace GameServer.Controller
{
    class UserController:baseController    {
        private UserDAO userDAO = new UserDAO();
        public UserController() {
            request = Request.User;
        }
        public string Login(string data, client client, Server server) {
            string[] strs = data.Split(',');
           User user = userDAO.VerifyUser(client.MySQLConn, strs[0], strs[1]);
            if (user == null)
            {
                // Enum.GetName(typeof(ReturnCode), ReturnCode.Fail);
                return ((int)ReturnCode.Fail).ToString();
            }
            else
            {
                return ((int)ReturnCode.Success).ToString();
            }



        }
    }
}
