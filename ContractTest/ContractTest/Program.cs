using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Inf3Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerData serverData = new ServerData();

            serverData.ShowDialog();

            //---- ogrady server ----
            //ip:port 85.214.103.114:110

            String ip = serverData.getIP();
            int port = serverData.getPort();

            if (ip != null && ip.Length >= 7)
            {
                if (port > 0 && port <= 65535)
                {
                    Connector connector = new Connector(ip, port);
                }
                else
                {
                    //error code here - port error
                }
            }
            else
            {
                //error code here - ip error
            }

                      
        }

    }
}
