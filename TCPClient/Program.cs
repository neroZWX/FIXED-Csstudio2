using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {   
            // set up
            Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress iPAddress = IPAddress.Parse("192.168.0.110");
            //IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, 100);
            //ClientSocket.Connect(iPEndPoint);
            ClientSocket.Connect(new IPEndPoint(IPAddress.Parse("192.168.0.110"),100));
            // only receive byte data
            byte[] data = new byte[1024];
            int count = ClientSocket.Receive(data);
            string m = Encoding.UTF8.GetString(data,0,count);
            Console.Write(m);
            // it can send messages many many times
            //while (true)
            //{
            //    string s = Console.ReadLine();
            //    Console.Write(s);
            //    // convert the string data to byte data then sent it to server
            //    ClientSocket.Send(Encoding.UTF8.GetBytes(s));
            //    if (s == "c") {
            //        ClientSocket.Close();
            //        return;
            //    }
                
            //}
            for (int i=0;i<100;i++){
                ClientSocket.Send(message.GetBytes(i.ToString()));
            }
            Console.ReadKey();
            ClientSocket.Close();



        }
    }
}
