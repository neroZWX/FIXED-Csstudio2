using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace GameServer.Servers
{
    class Message
    {
        private byte[] data = new byte[1024];
        // save current how many bytes data
        private int indexStart = 0;
        
        public byte[] Data
        {
            get { return data; }
        }
        public int IndexStart
        {
            get { return indexStart; }
        }
        public int RemainSize
        {
            get { return data.Length - indexStart; }
        }
        // Parse the data from client
        public void ReadMessag(int newDataAmount, Action<Request,ActionCode,string>processDataCallBack)
        {
            indexStart += newDataAmount;
            while (true)
            {
                if (indexStart <= 4)
                    return;
                // Parse the data length
                int count = BitConverter.ToInt32(data, 0);
                //check the message is complete or not
                if ((indexStart - 4) >= count)
                {
                    //string s = Encoding.UTF8.GetString(data, 4, count);
                    //Console.WriteLine("Parse a data:" + s);
                    //pharse data
                    Request request = (Request)BitConverter.ToInt32(data, 4);
                    ActionCode actioncode = (ActionCode)BitConverter.ToInt32(data, 4);
                    string s = Encoding.UTF8.GetString(data, 12, count - 8);
                    processDataCallBack(request, actioncode, s);

                    Array.Copy(data, count + 4, data, 0, indexStart - 4 - count);
                    // after parse need to updata the indexstart
                    indexStart -= (count + 4);
               }
                else
                {
                    break;
                }
            }
        }
        public static byte[] PackData(ActionCode actionCode, string data)
        {
            byte[] requestBytes = BitConverter.GetBytes((int)actionCode);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataAmount = requestBytes.Length + dataBytes.Length;
            byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
            byte[] newBytes = dataAmountBytes.Concat(requestBytes).ToArray<byte>();//Concat(dataBytes);
            return newBytes.Concat(dataBytes).ToArray<byte>();

        }

       

        public static byte[] PackData(Request request, ActionCode actionCdoe,string data)
        {
            byte[] requestBytes = BitConverter.GetBytes((int)request);
            byte[] actionCodeBytes = BitConverter.GetBytes((int)actionCdoe);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int dataAmount = requestBytes.Length + dataBytes.Length + actionCodeBytes.Length;
            byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
            //byte[] newBytes = dataAmountBytes.Concat(requestBytes).ToArray<byte>();//Concat(dataBytes);
            //return newBytes.Concat(dataBytes).ToArray<byte>();
            return dataAmountBytes.Concat(requestBytes).ToArray<byte>()
                .Concat(actionCodeBytes).ToArray<byte>().Concat(dataBytes).ToArray<byte>();

        }
    }
}
