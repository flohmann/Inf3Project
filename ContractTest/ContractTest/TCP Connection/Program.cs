using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPConnection
{
    class Program
    {
        private static TcpClient tcpClient;
        private static StreamWriter sw;
        private static StreamReader sr;


     /*   static void Main(string[] args)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect("127.0.0.1", 666);

            //connect the streams (write and read)
            sw = new StreamWriter(tcpClient.GetStream());
            sr = new StreamReader(tcpClient.GetStream());


            Receiver rec = new Receiver(tcpClient, sr);
            rec.Receive();
            Sender sender = new Sender(tcpClient, sw);

            while (tcpClient.Connected)
            {
                sender.SendMsg(Console.ReadLine());
            }
        }   */
    }
}
