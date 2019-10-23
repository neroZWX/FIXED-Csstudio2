﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    class RoomController : baseController
    {
        public RoomController()
        {
            request = Request.Room;

        }
        public string CreateRoom(string data, Client client, Server server)
        {
            server.CreateRoom(client);
            return ((int)ReturnCode.Success).ToString();

        }
        public string ListRoom(string data, Client client, Server server) {
            StringBuilder sb = new StringBuilder();
            foreach (Room room in server.GetRoomList()) {
                if (room.IsWaitingJoin()) {
                    sb.Append(room.GetHouseOwnerData()+"|");
                }
            }
            if (sb.Length == 0)
            {
                sb.Append("0");
            }
            else {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        public string JoinRoom(string data, Client client, Server server) {

            int id = int.Parse(data);
            Room room = server.GetRoomById(id);
            if (room == null)
            {
                //NO find room
                return ((int)ReturnCode.NotFound).ToString();
            }
            else if (room.IsWaitingJoin() == false)
            {
                //cant join the room
                return ((int)ReturnCode.Fail).ToString();
            }
            else {
                room.AddClient(client);
                string roomData = room.GetRoomtData();
                return ((int)ReturnCode.Success).ToString() + "-" + roomData;
            }

        }
    }
}

