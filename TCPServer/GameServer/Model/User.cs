using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Model
{
    class User
    {
        public User(int id, string username, string password) {
             this.ID = id;
             this.Username = Username;
            this.password = password;
        } 
        public int ID { get; set; } 
        public string Username { get; set; }
        public string password { get; set; }
    }
}
