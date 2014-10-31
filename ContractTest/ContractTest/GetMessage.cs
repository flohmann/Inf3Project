using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Inf3Project
{
    class GetMessage
    {
        private String message;
        private Buffer buffer;

        public GetMessage()
        {
            buffer = new Buffer();
            Thread thread = new Thread(new ThreadStart(getMessageFromServer));
            thread.Start();
        }

        public void pushMessageIntoBuffer(String message)
        {
            Contract.Requires(message != null);
        }

        public void getMessageFromServer()
        {
             while (true)
            {

            }
        }
    }
}
