using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ContractTest
{
    class GetMessage
    {
        private List<String> msgList = new List<String>();

        public GetMessage()
        {
            Thread thread = new Thread(new ThreadStart(getMessageFromServer));
            thread.Start();
        }

        public void pushMessageIntoBuffer(String message)
        {
            Contract.Requires(msgList.Count >= 0);
            Contract.Requires(message != null);


            Contract.Ensures(msgList.Contains(message));
            Contract.Ensures(msgList.Count == Contract.OldValue((msgList.Count) + 1));

        }

        public void getMessageFromServer()
        {
             while (true)
            {

            }
        }
    }
}
