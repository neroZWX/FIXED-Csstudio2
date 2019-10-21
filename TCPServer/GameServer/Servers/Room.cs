using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace GameServer.Servers
{
    enum RoomState {
        WaitingJoin,
        waitingBattle,
        Battle,
        End,

    }
    class Room
    {
        private List<Client> clientRoom = new List<Client>();
        private RoomState state = RoomState.WaitingJoin;
        public bool IsWaitingJoin() {
            return state == RoomState.WaitingJoin;
        }
        private Server server;

        public Room(Server server)
        {
            this.server = server;
        }

        public void AddClient(Client client)
        {
            clientRoom.Add(client);
            
        }
        public string GetHouseOwnerData() {
            return clientRoom[0].GetUserData();
        }

    }
}
