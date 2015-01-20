using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Inf3Project;
using System.Threading;

using Inf3Project.Observer;



namespace Inf3Project
{
    public class GUIManager: IPlayerObserver
    {
        public DefaultGui gui;
        private IBackend ba;
        private Thread GuiThread;

        public GUIManager(IBackend ba)
        {
            this.ba = ba;
            //gui = new DefaultGui(ba);
            //initGUI();
        }

        public void initGUI()
        {
            gui = new DefaultGui(ba);
            GuiThread = new Thread(GUIThreadStarter);
            GuiThread.Name = "GUI Thread";
            GuiThread.Start();
           
        }
        
        public void GUIThreadStarter()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(gui);

        }

        public String getCommand()
        {
            return ba.getCommand();
        }

        public String getChat()
        {
            return ba.getChat();
        }

        //public void sendChatMessage(String sender, String message)
        //{
        //    ba.setChatMsg(sender + ": " + message + "\r\n");
        //    //gui.sendChatMessage();
        //}

        public void repaint()
        {
            gui.Invoke(gui.myDelegate);
        }

        internal void sendChatMessage(String sender, String text)
        {
            gui.appendChatMessage(sender, text);
        }

        public void setLock(bool locked)
        {
            gui.setLock(locked);
        }


        public void OnChangePoints(Player p, int point)
        {
        }

        public void OnChangePosition(Player p, int x, int y)
        {
            throw new NotImplementedException();
        }

        public void OnBusy(Player p, bool busy)
        {
            throw new NotImplementedException();
        }
    }
}
