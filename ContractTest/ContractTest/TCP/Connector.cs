using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Inf3Project;

namespace Inf3Project
{
    public class Connector
    {
        /*
         * variables 
         */
        private String ip;
        private int port = 666;
        private StreamWriter sw;
        private StreamReader sr;
        private TcpClient tcpClient;
        private Receiver rec;
        private Sender sender;


        /*
         * constructors 
         */
        public Connector(String ip, int port)
        {
            setIp(ip);
            setPort(port);
            connectToServer();
            this.rec = new Receiver(tcpClient, sr, this);
            this.sender = new Sender(tcpClient, sw);
            sender.sendMessageToServer("get:map");
        }

        /*
         * methods 
         */
        public void setIp(String ip)
        {
            if (ip != null && ip.Length > 6 && ip.Length < 16)
            {
                this.ip = ip;
            }
        }

        public void setPort(int port)
        {
            if (port >= 0 && port <= 65535)
            {
                this.port = port;
            }
        }

        //opens a tcp connection to the server
        public void connectToServer()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(ip, port);

                //connect the streams (write and read)
                sw = new StreamWriter(tcpClient.GetStream());
                sr = new StreamReader(tcpClient.GetStream());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public Sender getSender()
        {
            return sender;
        }
    }
}
