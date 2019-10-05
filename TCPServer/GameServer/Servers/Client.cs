using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;
using MySql.Data.MySqlClient;
using GameServer.Tool;

namespace GameServer.Servers
{
    class client
    {
        private Socket ClientSocket;
        private Server server;
        private Message msg = new Message();
        private MySqlConnection mysqlConn;
        public client(client client) {

        }
        public client(Socket ClientSocket)
        {
            this.ClientSocket = ClientSocket;
            this.server = server;
            mysqlConn = ConnHelper.Connect();
        }
        public void Start()
        {
            ClientSocket.BeginReceive(msg.Data,msg.IndexStart,msg.RemainSize,SocketFlags.None,ReceiveCallback,null);

        }
        //Receive data
        private void ReceiveCallback(IAsyncResult ar) 
        {
            try
            {
                int count = ClientSocket.EndReceive(ar);
                if (count == 0)
                {
                    Close();
                }
                // handel the data that receive
                msg.ReadMessag(count,OnProcessMessage);
                Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Close();

            }
                     
        }
        private void OnProcessMessage(Request request, ActionCode actioncode,string data)
        {
            server.HandleRequest(request, actioncode, data, this);
        }
        private void Close() {
            ConnHelper.CloseConnection(mysqlConn);
            if (ClientSocket != null)
                ClientSocket.Close();
            server.RemoveClient(this);
            
        }
        public void Send(Request request, string data) {
            byte[] bytes = Message.PackData(request, data);
            ClientSocket.Send(bytes);
        }
    }
}
