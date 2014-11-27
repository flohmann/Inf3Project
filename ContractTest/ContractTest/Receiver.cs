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
        /*
         * variables
         */
        private StreamReader sr;
        private TcpClient tcpClient;
        private List<String> serverMessage;
        private Buffer buffer;

        /*
         * constructors
         */
        public Receiver(TcpClient tcpClient, StreamReader sr)
        {
            this.tcpClient = tcpClient;
            buffer = new Buffer();
            this.sr = sr;
            serverMessage = new List<String>();
            receive();
        }

        /*
         * methods
         */
        public void receive()
        {
            //create a thread to read the server messages
            Thread readThread = new Thread(new ThreadStart(readStreamThread));
            readThread.Start();
        }

        private void readStreamThread()
        {
            //repaired method - pls don't touch - easily frightened :p
            String tmpMessage = "";
            Boolean write = false;
            int value;
            while (tcpClient.Connected)
            {
                tmpMessage = sr.ReadLine().ToString();
                String[] tmp = tmpMessage.Split(':');
                if((tmp[0].Equals("begin")) && (Int32.TryParse(tmp[1], out value)))
                {
                    write = true;
                    serverMessage.Add(tmpMessage);
                    value = Int32.Parse(tmp[1]);
                } 
                else
                {
                    if((tmp[0].Equals("end")) && (Int32.TryParse(tmp[1], out value)))
                    {
                        serverMessage.Add(tmpMessage);
                        buffer.addMessageToBuffer(serverMessage);
                        write = false;
                        serverMessage.Clear();
                    }
                    else if(write)
                    {
                        serverMessage.Add(tmpMessage);
                    }
                }
            }
        }
    }
}
    