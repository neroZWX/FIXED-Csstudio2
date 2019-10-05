using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class Message
    {
        private byte[] data = new byte[1024];
        // save current how many bytes data
        private int indexStart = 0;
        //public void AddCount(int count)
        //{
        //    indexStart += count;
        //}
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
        public void ReadMessag(int newDataAmount)
        {

            indexStart += newDataAmount;
            while (true)
            {
                if (indexStart <= 4)
                    return;
                // Parse the data length
                int count = BitConverter.ToInt32(data, 0);
                if ((indexStart - 4 )>= count)
                {
                    string s = Encoding.UTF8.GetString(data, 4, count);
                    Console.WriteLine("Parse a data:" + s);
                    Array.Copy(data, count + 4, data, 0, indexStart - 4 - count);
                    // after parse need to updata the indexstart
                    indexStart -= (count + 4);

                }
                else {
                    break;
                }



            }


        }
    }
}

