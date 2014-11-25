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
            Application.Run(gui = new DefaultGui(ba = new Backend()));

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
            gui.sendChatMessage();
        }

        public void repaint()
        {
            gui.repaint();
        }


       
        public List<IPositionable> getDragons()
        {
            List<IPositionable> dragons = new List<IPositionable>();
            foreach (Dragon dragon in ba.getDragons())
            {
                dragons.Add(dragon);
            }
            return dragons;

        }

        public List<IPositionable> getPlayers()
        {
            List<IPositionable> players = new List<IPositionable>();
            foreach (Player player in ba.getPlayers())
            {
                players.Add(player);
            }
            return players;
        }

        internal void sendChatMessage()
        {
            throw new NotImplementedException();
        }
    }
}
