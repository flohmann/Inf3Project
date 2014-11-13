using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;
using System.Exception;


namespace Inf3Project
{
    class Buffer
    {
        /*
         * variables 
         */
        private List<List<String>> buffer;
        private int counter=0;
        private Parser parser;

        private Object lockthis = new Object();


        /*
         * constructors 
         */
        public Buffer()
        {
            parser = new Parser(this);
            List<List<String>> buffer = new List<List<String>>();
            

        }

        /*
         * methods 
         */
        public Boolean bufferHasContent()
        {
            Boolean tmp = false;
            Contract.Requires(buffer.Count >= 0);
            if (buffer != null && buffer.Count > 0)
            {
                tmp = true;
            }

            Contract.Ensures(buffer.Count == 0);
            return tmp;
        }

        //creates a one-message element of each server-push for the buffer
        public void addMessageToBuffer(List<String> message)
        {

            if (bufferHasContent())
            {

                lock (lockthis)
                {
                    for (int i = 0; i < buffer.Count; i++)
                    {
                        if (counter < 15)
                        {
                            buffer.Add(message);
                            counter++;
                        }
                        else
                        {
                           throw new System.Exception("Buffer is OverFlow");
                        }
                    }
                }
            }
        }


        public List<String> getMessageFromBuffer()
        {
            Contract.Requires(buffer.Count > 0);

            List<String> tmp = null;
            lock (lockthis)
            {
                if (buffer != null && buffer.Count > 0)
                {
                    tmp = buffer[0];

                    for (int i = 0; i < buffer.Count; i++)
                    {
                        if ((i + 1) < buffer.Count)
                        {
                            buffer[i] = buffer[i + 1];
                            buffer[i + 1] = null;
                        }
                    }
                }
            }
            return tmp;

        }

       

    }
}


