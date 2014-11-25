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
using Frontend;

namespace Inf3Project
{
    class Connector
    {
        /*
         * variables 
         */
        private String ip;
        private int port = 666;
        public Buffer buffer;
        private StreamWriter sw;
        private StreamReader sr;
        private TcpClient tcpClient;
        private GUIManager m = new GUIManager();

        /*
         * constructors 
         */
        public Connector(String ip, int port)
        {
            buffer = new Buffer();
            setIp(ip);
            setPort(port);
            connectToServer();
            Receiver rec = new Receiver(tcpClient, sr, this);
            Sender sender = new Sender(tcpClient, sw);
            m.initGUI();
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

        //send message to buffer
        public void addMessageToBuffer(List<String> msg)
        {
            buffer.addMessageToBuffer(msg);
        }

        //opens a tcp connection to the server
        public void connectToServer()
        {
            //Contract.Requires(port >= 0 && port <= 65535);
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
            //Contract.Requires(ip != null && ip.Length > 6 && ip.Length < 16);
        }

        private TcpClient getTcpClient()
        {
            return this.tcpClient;
        }

        public Buffer getBuffer()
        {
            return buffer;
        }
    }
}
