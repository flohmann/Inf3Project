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
    class Buffer
    {

        private List<String> buffer = new List<String>;
       

        public Buffer(){

        }

        public void addLineToBuffer(String message)
        {
            Contract.Requires(buffer.Count >= 0);
            Contract.Requires(message != null);

            Contract.Ensures(buffer.Contains(message));
            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) + 1));
        }

        public String getLineFromBuffer()
        {
            Contract.Requires(buffer.Count > 0);

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
            return buffer[0];
        }

        public void bufferContent()
        {
            Contract.Requires(buffer.Count >= 0);

            Contract.Ensures(buffer.Count==0);
        }

    }
}
