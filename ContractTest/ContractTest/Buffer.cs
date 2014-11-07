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
        private List<String> bufferList;
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
            bufferList = new List<String>(BUFFERSIZE);
        }

        /*
         * methods 
         */
        public Boolean bufferContent()
        {
            Boolean tmp = false;
            Contract.Requires(bufferList.Count >= 0);
            if (bufferList != null && bufferList.Count > 0)
            {
                tmp = true;
            }
            
            Contract.Ensures(bufferList.Count == 0);
            return tmp;
        }

        //creates a one-line element of each server-push for the buffer
        public void addLineToBuffer(String message)
        {
            if (message != null)
            {
                if (searchEnd)
                {
                    String[] tmp = message.Split(':');
                    if (tmp[0].Equals("end"))
                    {
                        int end = -1;
                        bool isNumber = int.TryParse(tmp[1], out end);
                        if (isNumber)
                        {
                            if (begin.Equals(end))
                            {
                                searchEnd = false;
                                begin = -1;
                                end = -1;
                                bufferList.Add(tmpBuffer);
                                tmpBuffer = "";
                            }
                        }
                        else
                        {
                            tmpBuffer += message + ";";
                        } 
                    }
                    else
                    {
                        tmpBuffer += message + ";";
                    }
                }
                else
                {
                    String[] tmp = message.Split(':');
                    if (tmp[0].Equals("begin"))
                    {
                        bool isNumber = int.TryParse(tmp[1], out begin);
                        if (isNumber)
                        {
                            searchEnd = true;
                        }
                    }
                }
            }
            
            Contract.Ensures(bufferList.Contains(message));
            Contract.Ensures(bufferList.Count == Contract.OldValue((bufferList.Count) + 1));
        }

        public String getLineFromBuffer()
        {
            Contract.Requires(bufferList.Count > 0);

            if (bufferList != null && bufferList.Count > 0)
            {
                String tmp = bufferList[0];
                bufferList.RemoveAt(0);
                return tmp;
            }

            Contract.Ensures(bufferList.Count == Contract.OldValue((bufferList.Count) - 1));
            return null;
        }

        public List<String> getBufferList(){
            return this.bufferList;
        }

    }
}
