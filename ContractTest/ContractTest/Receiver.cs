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
    class Receiver
    {
        private StreamReader sr;
        private TcpClient tcpClient;

        //constructors
        public Receiver(TcpClient tcpClient, StreamReader sr)
        {
            this.tcpClient = tcpClient;
            this.sr = sr;
            receive();
        }

        //methods
        public void receive()
        {
            //create a thread to read the server messages
            Thread readThread = new Thread(new ThreadStart(readStreamThread));
            readThread.Start();

        }

        private void readStreamThread()
        {
            while (tcpClient.Connected)
            {
                Console.WriteLine(sr.ReadLine().ToString());
            }
        }
    }
}
