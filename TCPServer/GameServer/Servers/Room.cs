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
        private Server server;
        public bool IsWaitingJoin() {
            return state == RoomState.WaitingJoin;
        }

        public Room(Server server)
        {
            this.server = server;
        }

        public void AddClient(Client client)
        {
            clientRoom.Add(client);
            client.Room = this;
            if (clientRoom.Count >= 2 ) {
                state = RoomState.waitingBattle;
            }
            
        }
        public void RemoveClient(Client client) {
            client.Room = null;
            clientRoom.Remove(client);
            if (clientRoom.Count >= 2)
            {
                state = RoomState.waitingBattle;
            }
            else {
                state = RoomState.WaitingJoin;

            }

        }
        public string GetHouseOwnerData() {
            return clientRoom[0].GetUserData();
        }
        public void Close(Client client) {
            if (client == clientRoom[0])
                server.RemoveRoom(this);
            else
                clientRoom.Remove(client);
        }
        public int GetRoomId() {
            if (clientRoom.Count > 0) {
                return clientRoom[0].GetUserId();
            }
            return -1;
        }
        public string GetRoomtData() {
            StringBuilder sb = new StringBuilder();
            foreach (Client client in clientRoom) {
                sb.Append(client.GetUserData() + "|" );
            }
            if (sb.Length > 0) {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        public void BroadCastMessage(Client excludeClient,ActionCode actionCode, string data) {
            foreach (Client client in clientRoom) {
                if (client != excludeClient) {
                    server.SendResponse(client, actionCode, data);
                }
            }
        }
        public bool IsHouseOwner(Client client) {
            return client == clientRoom[0];

        }
        public void CloseRoom() {
            foreach (Client client in clientRoom) {
                client.Room = null;
            }
            server.RemoveRoom(this);

        }
    }
}
