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
        private List<String> serverMessage;
        private Connector connector;

        //constructors
        public Receiver(TcpClient tcpClient, StreamReader sr, Connector connector)
        {
            this.tcpClient = tcpClient;
            this.connector = connector;

            this.sr = sr;
            serverMessage = new List<String>();
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
            String tmpMessage;
            Boolean write = false;
            Int32 messageId = -1;
            while (tcpClient.Connected)
            {
                tmpMessage = sr.ReadLine().ToString();
                Console.WriteLine(tmpMessage);

                String[] tmp = tmpMessage.Split(':');
                int value;

                if ((tmp[0].Equals("begin")) && (Int32.TryParse(tmp[1], out value)))
                {
                    messageId = value;
                   
                    write = true;
                   


                            if (write)
                {
                    serverMessage.Add(tmpMessage);
                }


                if ((tmp[0].Equals("end")) && (Int32.TryParse(tmp[1], out value)))
                {
                    if (value == messageId)
                    {
                       
                        connector.buffer.addMessageToBuffer(new List<String>(this.serverMessage));
                        write = false;
                        serverMessage.Clear();
                        
                    }


                }
                
            }
        }
    }
}
        }
    