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
            private Boolean isConnected = false;

        public Connector()
        {

        }


        public void connect(String ip, int port)
        {
            Contract.Requires(port >= 0 && port <= 65535);
            Contract.Requires(ip != null && ip.Length > 6 && ip.Length < 16);


        }



        public void pushMessageIntoBuffer(List<String> buffer, String message)
        {
            Contract.Requires(buffer.Count >= 0);
            Contract.Requires(message != null);


            Contract.Ensures(buffer.Contains(message));
            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) + 1));

        }

        public void sendMessageToServer(String message)
        {
            Contract.Requires(isConnected);
            Contract.Requires(message != null);

        }     





    }
}
