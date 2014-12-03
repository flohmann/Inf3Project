using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Frontend;
using System.Threading;
using Inf3Project;



namespace Frontend
{
    public class GUIManager
    {
        private DefaultGui gui;
        private IBackend ba;
        private Thread GuiThread;

        public GUIManager(IBackend ba)
        {
            
            this.ba = ba;
            gui = new DefaultGui(ba);
            initGUI();
        }

        public void initGUI()
        {
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

        public void sendChatMessage(String sender, String message)
        {
            ba.setChatMsg(sender + ": " + message + "\r\n");
            //gui.sendChatMessage();
        }

        public void repaint()
        {
            gui.Invoke(gui.myDelegate);

        }


        internal void sendChatMessage()
        {

            throw new NotImplementedException();
        }
    }
}
