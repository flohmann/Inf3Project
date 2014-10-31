using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;


namespace Inf3Project
{
    class Buffer
    {

        private List<String> bufferList;
        private Parser parser;

        public Buffer(){
            parser = new Parser(this);
            bufferList = new List<String>();
        }

        public void addLineToBuffer(String message)
        {
            Contract.Requires(bufferList.Count >= 0);
            Contract.Requires(message != null);

            Contract.Ensures(bufferList.Contains(message));
            Contract.Ensures(bufferList.Count == Contract.OldValue((bufferList.Count) + 1));
        }

        public String getLineFromBuffer()
        {
            Contract.Requires(bufferList.Count > 0);

            Contract.Ensures(bufferList.Count == Contract.OldValue((bufferList.Count) - 1));
            return bufferList[0];
        }

        public void bufferContent()
        {
            Contract.Requires(bufferList.Count >= 0);

            Contract.Ensures(bufferList.Count==0);
        }

        public List<String> getBufferList(){
            return this.bufferList;
        }

    }
}
