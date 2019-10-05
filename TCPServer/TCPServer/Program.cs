using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAsync();
            Console.ReadKey();
        }
        static  Message msg = new Message();
        static byte[] dataBuffer = new byte[1024];
        static void ServerAsync() {
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("192.168.0.110");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 100);

            ServerSocket.Bind(iPEndPoint);

            ServerSocket.Listen(0);
            // starting to accept the message from cilen
            ServerSocket.BeginAccept(AcceptCallBack,ServerSocket);
            
        
        }
        static void AcceptCallBack(IAsyncResult ar) {
            Socket ServerSocket = ar.AsyncState as Socket;
           Socket ClientSocket = ServerSocket.EndAccept(ar);

            // sned the message
            string m = "hello amigo";
            Byte[] data = Encoding.UTF8.GetBytes(m);
            ClientSocket.Send(data);

            // start to receive the message
            ClientSocket.BeginReceive(msg.Data, msg.IndexStart, msg.RemainSize, SocketFlags.None, ReceiveCallBack, ClientSocket);
            // restarting 
            ServerSocket.BeginAccept(AcceptCallBack, ServerSocket);
        }

      
        static void ReceiveCallBack(IAsyncResult ar) {
            Socket ClientSocket = ar.AsyncState as Socket;
            try
            {
                int count = ClientSocket.EndReceive(ar);
                //when the server receive the null byte then close the Client
                if (count == 0) {
                    ClientSocket.Close();
                    return;
                }
                // get count byte from client then update the indexStart o
                msg.AddCount(count);
                msg.ReadMessag();         
                // Can Call this function many many times              
                ClientSocket.BeginReceive(msg.Data, msg.IndexStart, msg.RemainSize, SocketFlags.None, ReceiveCallBack, ClientSocket);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                if (ClientSocket != null) {
                    ClientSocket.Close();
                }
            }
            
        }
        void ServerSync() {
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse("192.168.0.110");
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 100);

            ServerSocket.Bind(iPEndPoint);

            ServerSocket.Listen(0);
            Socket ClientSocket = ServerSocket.Accept();
            // sned the message
            string m = "hello amigo";
            Byte[] data = Encoding.UTF8.GetBytes(m);
           
            ClientSocket.Send(data);
            // receive the message
            byte[] dataBuffer = new byte[1024];
            int count = ClientSocket.Receive(dataBuffer);
            String MReceive = Encoding.UTF8.GetString(dataBuffer, 0, count);

            // out put
            Console.WriteLine(MReceive);
            Console.ReadKey();

            ServerSocket.Close();
            ClientSocket.Close();
        }
    }
}
