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
        private List<List<String>> buffer;
        private int counter = 0;
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
            while (counter >= 15)
            {
                Thread.Sleep(5000);
            }
            lock (lockthis)
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


        public List<String> getMessageFromBuffer()
        {
            Contract.Requires(buffer.Count > 0);
            List<String> message = null;

            while (buffer.Count == 0)
            {
                Thread.Sleep(5000);
            }

            if (bufferHasContent())
            {
                lock (lockthis)
                {

                    buffer.ElementAt(0); 
                    buffer.RemoveAt(0);
                    counter--;

                }
               
            } return message;
               }
        }
    }



