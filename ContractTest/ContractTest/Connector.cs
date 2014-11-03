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

namespace Inf3Project
{
    class Connector
    {
        private String ip;
        private Int32 port = 666;
        private Buffer buffer;
        private StreamWriter sw;
        private StreamReader sr;
        private TcpClient tcpClient;

        public Connector(String ip, Int32 port)
        {
            setIp(ip);
            setPort(port);
            connect(ip, port);
            buffer = new Buffer();

            connectToServer();

            //create read thread and start it
            Thread readThread = new Thread(new ThreadStart(readStreamThread));
            readThread.Start();
        }

        public void setIp(String ip)
        {
            if (ip != null && ip.Length > 6 && ip.Length < 16)
            {
                this.ip = ip;
            }
            
        }
       
        public void setPort(Int32 port)
        {
            if (port >= 0 && port <= 65535)
            {
                this.port = port;
            }
        }
        
        public void connect(String ip, Int32 port)
        {
            Contract.Requires(port >= 0 && port <= 65535);


            Contract.Requires(ip != null && ip.Length > 6 && ip.Length < 16);
        }
        
        public void sendMessageToServer(String message)
        {
            Contract.Requires(isConnected);
            Contract.Requires(message != null);

        }

        private TcpClient getTcpClient()
        {
            return this.tcpClient;
        }

        private void connectToServer()
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

        private void readStreamThread()
        {
            while (tcpClient.Connected)
            {
                buffer.addLineToBuffer(sr.Read().ToString());
            }
        }


    }
}
