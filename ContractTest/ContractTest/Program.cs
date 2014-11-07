using Inf3Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend
{
    static class Program
    {

         static void Main()
         {
             Connector connector = new Connector("127.0.0.1", 666);

             //Application.EnableVisualStyles();
             //Application.SetCompatibleTextRenderingDefault(false);
             //Application.Run(new DefaultGui(new Backend()));
         }
    }
}
