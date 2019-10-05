using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPClient
{
    class message
    {
        public static byte[] GetBytes(string data)
            {
            // Convering the string to Byte
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            // get data length
            int dataLength = data.Length;
            // Convering the data length to 4 bytes
            byte [] LengthBytes = BitConverter.GetBytes(dataLength);
            //Combination of the dataBytes and dataLength
            byte[] newByte = LengthBytes.Concat(dataBytes).ToArray();
            return newByte;
            
            }
    }
}
