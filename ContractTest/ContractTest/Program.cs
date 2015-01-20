using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inf3Project.Game;


namespace Inf3Project
{
    class Program
    {
        private static Login loginGui;
        private static Thread GuiThread;

        static void Main(string[] args)
        {
            loginGui = new Login();
            GuiThread = new Thread(GUIThreadStarter);
            GuiThread.Name = "GUI Thread";
            GuiThread.Start();            
        }

        public static void GUIThreadStarter()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(loginGui);

        }
    }
}
