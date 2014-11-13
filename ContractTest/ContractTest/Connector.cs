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
        }

   // Zum Kuckuck nochmal!!!!!!!!1  ich hasse Git!!!!!!!!!!!!!

        
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

        //Lock eingefügt,   Allerdings, was macht die methode addMessageToBuffer? in Buffer haben wa auch eine ddMessageToBuffer
        //schaut da bitte danach. Ansonsten
        
        public void addMessageToBuffer(List<String> msg)
        {
            lock (buffer.getLineFromBuffer())
            {
                buffer.setLineFromBuffer(msg);
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
        
 

        private TcpClient getTcpClient()
        {
            return this.tcpClient;
        }

        


    }
}
