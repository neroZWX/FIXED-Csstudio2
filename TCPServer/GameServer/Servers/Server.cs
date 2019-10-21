using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using GameServer.Controller;
using Common;


namespace GameServer.Servers
{
    class Server
    {
        private IPEndPoint ipendpoint;
        private Socket ServerSocket;
        private List<Client> Clientlist = new List<Client>();
        private List<Room> roomlist = new List<Room>();
        private ControllerManager controllerManager;
        public Server() {

        }
        public Server(string ip, int port)
        {
            controllerManager = new ControllerManager(this);
            SetIpandPort(ip, port);
        }
        public void SetIpandPort(string ip, int port) {
            ipendpoint = new IPEndPoint(IPAddress.Parse(ip), port);
        }
        public void Start()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerSocket.Bind(ipendpoint);
            ServerSocket.Listen(0);
            ServerSocket.BeginAccept(AcceptCallBack,null);
        }
        private void AcceptCallBack(IAsyncResult ar) {
            Socket ClientSocket = ServerSocket.EndAccept(ar);
            Client client = new Client(ClientSocket,this);
            client.Start();
            Clientlist.Add(client);
            ServerSocket.BeginAccept(AcceptCallBack, null);
        }
        public void RemoveClient(Client client) {
            lock (Clientlist)
            {
                Clientlist.Remove(client);
            }
            
        }
        public void SendResponse(Client client, ActionCode actionCode, string data) {
            // response the client
            client.Send(actionCode, data);
        }
        public void HandleRequest(Request request, ActionCode actioncode, string data, Client client)
        {
            Console.WriteLine("srv rec: " + actioncode.ToString());
            controllerManager.HandRequest(request, actioncode, data, client);
        }
        public void CreateRoom(Client client)
        {
            Room room = new Room(this);
            room.AddClient(client);
            roomlist.Add(room);

        }
        public List<Room> GetRoomList() {
            return roomlist;

        }
    }
}
