using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public class Client
    {
        IPEndPoint serverEndPoint;
        Socket socket;

        public Client(string address, int port)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse(address), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Process()
        {
            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                socket.SendTo(data, serverEndPoint);

                byte[] response = new byte[data.Length];
                int rlen = socket.Receive(response);
                Console.WriteLine(new string(Encoding.UTF8.GetChars(response, 0, response.Length)));
            }
        }
    }
}
