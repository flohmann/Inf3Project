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
        private List<String> bufferList;

        /*
         * constructors 
         */
        public Buffer()
        {
            bufferList = new List<String>();
        }

        /*
         * methods 
         */
        public Boolean bufferHasContent()
        {
            Boolean tmp = false;
            if (bufferList != null && bufferList.Count > 0)
            {
                tmp = true ;
            }
            return tmp;
        }

        //creates a one-message element of each server-push for the buffer
        public void addMessageToBuffer(String message)
        {
            lock (bufferList)
            {
                if (bufferList.Count() < 15)
                {    
                    bufferList.Add(message);
                    Console.WriteLine(message);
                }
                else
                {
                    //throw new Exception("Buffer Overflow");
                }
            }
        }

        public String getMessageFromBuffer()
        {
            String tmp = "";
            lock (bufferList)
            {
                if (bufferHasContent())
                {
                    tmp = bufferList.ElementAt(0);
                    bufferList.RemoveAt(0);
                }
            }
            return tmp;
        }
    }
}
    
    



