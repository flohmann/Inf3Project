using Frontend;
using Inf3Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Inf3Project
{
    class Program
    {
       
    
        static void Main(string[] args)
        {
            Connector connector = new Connector("127.0.0.1", 666);
        }

    }
}
