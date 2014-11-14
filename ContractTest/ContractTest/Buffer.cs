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
        private List<List<String>> buffer;
        private int BUFFERSIZE = 15;
        private Parser parser;
        private Boolean searchEnd = false;
        private int begin = -1;
        private String tmpBuffer;

        /*
         * constructors 
         */
        public Buffer(){
            parser = new Parser(this);
       
            List<String>[] buffer = new List<String>[BUFFERSIZE];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = new List<String>();
            }
            
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

        //creates a one-line element of each server-push for the buffer
        public void addMessageToBuffer(List<String> message)
        {
            
            if (bufferHasContent())
            {
                for (int i = 0; i < buffer.Count; i++)
                {
                    if (buffer[i] == null)
                    {
                        buffer[i] = message;
                        break;
                    }
                }
            }
        }

        public List<String> getLineFromBuffer()
        {
            Contract.Requires(buffer.Count > 0);

            List<String> tmp = null;
            if (buffer != null && buffer.Count > 0)
            {
              //  tmp.AddBuffer[0];                        //Hier nochmal guten ob die methode so sinn macht

                for (int i = 0; i < buffer.Count; i++)
                {
                    if ((i + 1) < buffer.Count)
                    {
                        buffer[i] = buffer[i + 1];
                        buffer[i + 1] = null;
                    }
                }
            }

            return tmp;
            
        }


        public void setLineFromBuffer(List<String> s)
        {
            buffer.Add(s);

        }

        public List<String> getBuffer(){
            List<String> tmp;
            tmp = buffer[0];
            buffer.Remove(tmp);

            return tmp;
        }

    }
}
