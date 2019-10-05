﻿using System;
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
        private List<client> Clientlist;
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
            client client = new client(ClientSocket);
            client.Start();
            Clientlist.Add(client);
        }
        public void RemoveClient(client client) {
            lock (Clientlist)
            {
                Clientlist.Remove(client);
            }
            
        }
        public void SendResponse(client client, Request request, string data) {
            // response the client
            client.Send(request, data);
        }
        public void HandleRequest(Request request, ActionCode actioncode, string data, client client)
        {
            controllerManager.HandRequest(request, actioncode, data, client);
        }
    }
}
