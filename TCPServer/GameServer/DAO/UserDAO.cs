﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using GameServer.Model;

namespace GameServer.DAO
{
    class UserDAO
    {
        public User VerifyUser(MySqlConnection conn, string username, string password) {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select*from user where username = @username and password =@password", conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    User user = new User(id, username, password);
                    return user;
                }
                else {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception while VerifyUser infromation" + e);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return null;
            }
        //根据用户名来查找用户
       
        public bool GetUserByUsername(MySqlConnection conn, string username) {
            MySqlDataReader reader = null;
            try
            {
                MySqlCommand cmd = new MySqlCommand("select*from user where username = @username", conn);
                cmd.Parameters.AddWithValue("username", username);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception while Check user's infromation" + e);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return false;
        }
        public void AddUser(MySqlConnection conn, string username, string password) {
            
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into user set username = @username , password = @password", conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Get Exception while Add new User " + e);
            }
           
        }
        }
    }
