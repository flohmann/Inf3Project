using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;



namespace Inf3Project
{
    class Buffer
    {
        /*
         * variables 
         */
        private List<List<String>> bufferListList;
        private Parser parser;

        /*
         * constructors 
         */
        public Buffer()
        {
            parser = new Parser(this);
            bufferListList = new List<List<String>>();
        }

        /*
         * methods 
         */
        public Boolean bufferHasContent()
        {
            Boolean tmp = false;
            if (bufferListList != null && bufferListList.Count > 0)
            {
                tmp = true ;
            }
            return tmp;
        }

        //creates a one-message element of each server-push for the buffer
        public void addMessageToBuffer(List<String> message)
        {
            lock (bufferListList)
            {
                if (bufferListList.Count() < 15)
                {
                    bufferListList.Add(message);
                }
                else
                {
                    throw new Exception("BufferOverFlow");
                }
            }
        }

        public List<String> getMessageFromBuffer()
        {
            
            List<String> tmp = new List<string>();
            lock (bufferListList)
            {
                if (bufferHasContent())
                {
                    tmp = new List<String>(bufferListList.ElementAt(0));
                    bufferListList.RemoveAt(0);
                }
            }
            return tmp;
        }
    }
}
    
    



