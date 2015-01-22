using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Inf3Project
{
    public class Sender
    {
        /*
         * variables
         */
        private StreamWriter sw;
        private TcpClient tcpClient;

        /*
         * constructors
         */
        public Sender(TcpClient tcpClient, StreamWriter sw)
        {
            this.tcpClient = tcpClient;
            this.sw = sw;
            sendMessageToServer("get:myid");
        }

        /*
         * methods
         */
        public void sendMsg(String msg)
        {
            sw.WriteLine(msg);
            sw.Flush();
            Thread readThread = new Thread(new ThreadStart(writeStreamThread));
            readThread.Start();
        }

        private void writeStreamThread()
        {
            while (tcpClient.Connected)
            {
                sw.WriteLine(Console.ReadLine());
                sw.Flush();
            }
            
        }
        public void sendMessageToServer(String command)
        {
            sw.WriteLine(command);
            sw.Flush();
        }
    }
}
