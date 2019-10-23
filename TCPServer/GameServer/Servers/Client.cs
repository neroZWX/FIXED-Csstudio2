using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;
using MySql.Data.MySqlClient;
using GameServer.Tool;
using GameServer.Model;

namespace GameServer.Servers
{
    class Client
    {
        private Socket ClientSocket;
        private Server server; 
        private Message msg = new Message();
        public MySqlConnection mysqlConn;
        private Room room;
        private User user;
        private Result result;


        public MySqlConnection MySQLConn
        {
            get { return mysqlConn; }
        }
        public void SetUserData(User user, Result result) {
            this.user = user;
            this.result = result;
        }
        public string GetUserData() {
            return user.id +","+user.Username + "," + result.TotalCount + "," + result.WinCount;
        }
        public Room Room {
            set { room = value; }
        }
        public int GetUserId() {
            return user.id;
        }
      
        public Client() {

        }
        public Client(Socket ClientSocket,Server server)
        {
            this.ClientSocket = ClientSocket;
            this.server = server;
            mysqlConn = ConnHelper.Connect();
        }

        public Client(Socket clientSocket)
        {
            ClientSocket = clientSocket;
        }

        public void Start()
        {
            if (ClientSocket == null || ClientSocket.Connected == false) return;
            ClientSocket.BeginReceive(msg.Data,msg.IndexStart,msg.RemainSize,SocketFlags.None,ReceiveCallback,null);

        }
        //Receive data
        private void ReceiveCallback(IAsyncResult ar) 
        {
            try
            {
                if (ClientSocket == null || ClientSocket.Connected == false) return;
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
            ConnHelper.CloseConnection(MySQLConn);
            if (ClientSocket != null)
                ClientSocket.Close();
            if (room != null)
            {
                room.Close(this);
            }
            server.RemoveClient(this);
                       
        }
        public void Send(ActionCode actionCode, string data) {
            byte[] bytes = Message.PackData(actionCode, data);
            ClientSocket.Send(bytes);
        }
    }
}
