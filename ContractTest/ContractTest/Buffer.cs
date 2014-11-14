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
        private List<List<String>>buffer;
        private Parser parser;

        private Object lockthis = new Object();


        /*
         * constructors 
         */
        public Buffer()
        {
            parser = new Parser(this);
            buffer = new List<List<String>>();


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

        public int getCount()
        {
            return buffer.Count;
        }

        //creates a one-message element of each server-push for the buffer
        public void addMessageToBuffer(List<String> message)
        {
           
            lock (lockthis)
            {
                if (buffer.Count() < 15)
                {
                    buffer.Add(message);
                   
                }
                else
                {
                    throw new System.Exception("BufferOverFlow");
                }
            }
        }


        public List<String> getMessageFromBuffer()
        {
            Contract.Requires(buffer.Count > 0);
            List<String> tmp = new List<string>();

            if (bufferHasContent())
            {
                lock (lockthis)
           
                    tmp=(buffer.ElementAt(0)); 
                    buffer.RemoveAt(0);
                    

                }
                return tmp;
            }
               }
        }
    



