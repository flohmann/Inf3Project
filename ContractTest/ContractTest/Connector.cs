using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using ContractTest;

namespace ContractTest
{
    class Connector
    {
        private String ip;
        private int port = 666;
        private Boolean isConnected = false;
        private GetMessage gm;

        public Connector(String ip, int port)
        {
            setIp(ip);
            setPort(port);
            connect(ip, port);
            gm = new GetMessage();
        }

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

    /*    public String Ip{
            get
            {
                return this.ip;
            }
            set
        {
                if(ip!=null && ip.Length > 6 && ip.Length < 16)
                    this.ip = value;
            }
        }

        public Int32 Port
        {
            get
            {
                return this.port;
            }
            set
            {
                if (port >= 0 && port <= 65535)
                    this.port = value;
        }
        }*/
        
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





    }
}
