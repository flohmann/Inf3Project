﻿using System;
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
        /*
         * variables 
         */
        private String ip;
        private int port = 666;
        private Buffer buffer;
        private StreamWriter sw;
        private StreamReader sr;
        private TcpClient tcpClient;
        private Boolean isConnected = false;

        /*
         * constructors 
         */
        public Connector(String ip, int port)
        {
            setIp(ip);
            setPort(port);
            buffer = new Buffer();
            connectToServer();

            //create read thread and start it
            Thread readThread = new Thread(new ThreadStart(readStreamThread));
            readThread.Start();
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

        //method used for the readStream
        private void readStreamThread()
        {
            while (tcpClient.Connected)
            {
                buffer.addLineToBuffer(sr.ReadLine().ToString()); 
            }
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
        
        public void sendMessageToServer(String message)
        {
            Contract.Requires(isConnected);

            sw.WriteLine(message);
            sw.Flush();

            Contract.Requires(message != null);

        }

        private TcpClient getTcpClient()
        {
            return this.tcpClient;
        }

        


    }
}
