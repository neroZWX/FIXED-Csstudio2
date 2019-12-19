using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    class GameController : baseController
    {
        public GameController()
        {
            request = Request.Game;

        }
        public string StartGame(string data, Client client, Server server)
        {
            if (client.IsHouseOwner())
            {
                Room room = client.Room;
                room.BroadCastMessage(client, ActionCode.StartGame, ((int)ReturnCode.Success).ToString());
                room.StartTimer();
                return ((int)ReturnCode.Success).ToString();
            }
            else {
                return ((int)ReturnCode.Fail).ToString();

            }
        }
        public string Move(string data, Client client, Server server) {
            Room room = client.Room;
            if(room!=null)
            room.BroadCastMessage(client, ActionCode.Move, data);

            return null;
        }
        public string Shoot(string data, Client client, Server server)
        {
            Room room = client.Room;
            if (room != null)
                room.BroadCastMessage(client, ActionCode.Shoot, data);

            return null;
        }

    }
  
}
