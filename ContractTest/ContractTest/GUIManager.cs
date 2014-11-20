using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Frontend;
using System.Threading;

namespace Inf3Project
{
    public class GUIManager
    {
        private DefaultGui gui;
        private IBackend guiBa;
        private Thread guiThread;

        public GUIManager()
        {
            guiThread = new Thread(guiThreadStart);
            guiThread.Name = "GUI Thread";
            guiThread.Start();
        }

        private void guiThreadStart()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(gui = new DefaultGui(guiBa = new Backend()));
            
        }
    }
}
