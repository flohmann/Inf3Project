using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;
using Frontend;
using System.Threading;

namespace Inf3Project
{
    class Parser
    {
        private Backend backend;
        private Buffer buffer;
        private List<String> msg;
        private int id;
        private String type;

        List<String> message;
        public Parser(Buffer buffer){
            backend = new Backend();
            this.buffer = buffer;
            
            //create read thread and start it
            Thread readBufferThread = new Thread(new ThreadStart(readBuffer));
            readBufferThread.Start();
        }
        
        public void readBuffer()
        {
            msg = buffer.getMessageFromBuffer();
            String[] tmp = msg[0].Split(':');
            int value ;
            if ((tmp[0].Equals("begin")) && (Int32.TryParse(tmp[1], out value)))
            {
                value=Int32.Parse(tmp[1]);
                tmp = msg[msg.Count()-1].Split(':');
                if((tmp[0].Equals("end")) && (Int32.TryParse(tmp[1], out value)))
                {
                    msg.RemoveAt(0);
                    msg.RemoveAt(msg.Count-1);
                }
                //delete upd 
            }
            tmp = msg[1].Split(':');
            if((tmp[0].Equals("begin")) && (tmp[1].Equals("player"))){
                playerConvert(msg);

            }
    }

        private void playerConvert(List<String> msg)
        {
            String [] tmp = msg[0].Split(':');
            //beginn:player delete and  adapt msg.Count  
            if (msg.Count == 9)
            {
                if(tmp[0].Equals("id")){
                   id = Int32.Parse(tmp[1]);
                }
                tmp = msg[1].Split(':');
                    if(tmp[0].Equals("type")){
                        type = tmp[1];
                    }
            }
        }

       
}
}
