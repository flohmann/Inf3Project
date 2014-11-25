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

        public Parser(Buffer buffer){
            backend = new Backend();
            this.buffer = buffer;
            
            //create read thread and start it
            Thread readBufferThread = new Thread(new ThreadStart(readBuffer));
            readBufferThread.Start();
        }

       

        
    }
}
