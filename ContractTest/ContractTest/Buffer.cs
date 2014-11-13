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
        /*
         * variables 
         */
        private List<Object> buffer;
        private int BUFFERSIZE = 15;
        private Parser parser;
       

        /*
         * constructors 
         */
        public Buffer(){
            parser = new Parser(this);
       
            List<Object> buffer = new List<Object>(BUFFERSIZE);
            //for (int i = 0; i < buffer.Length; i++)
            //{
            //    buffer = new List<String>();
            //}
            
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
                for (int i = 0; i < buffer.Count; i++)
                {
                    //if (buffer == null)
                    //{
                        buffer.Add(message);
                        break;
                    }
                }
            }
        }

        //public List<String> getLineFromBuffer()
        //{
        //    Contract.Requires(buffer.Length > 0);

        //    List<String> tmp = null;
        //    if (buffer != null && buffer.Length > 0)
        //    {
        //        tmp = buffer[0];

        //        for (int i = 0; i < buffer.Length; i++)
        //        {
        //            if ((i + 1) < buffer.Length)
        //            {
        //                buffer[i] = buffer[i + 1];
        //                buffer[i + 1] = null;
        //            }
        //        }
        //    }

        //    return tmp;
            
        //}

    //    public List<String>[] getBuffer(){
    //        return this.buffer;
    //    }

    //}
}
