﻿using System;
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
        public string Register(string data, client client, Server server)
        {
            string[] strs = data.Split(',');
            string username = strs[0];string password = strs[1];
            //检查用户名是否存在， check the user if exit or not
            bool res = userDAO.GetUserByUsername(client.mysqlConn ,username);
            if (res) {
                return ((int)ReturnCode.Fail).ToString();
            }
            userDAO.AddUser(client.mysqlConn, username, password);
            return((int)ReturnCode.Success).ToString(); ;
        }
    }
}
