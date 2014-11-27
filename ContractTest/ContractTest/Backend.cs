using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;
using System.Threading;
using System.Windows.Forms;

namespace Frontend
{
    /// <summary>
    /// All classes in the test-directory are just classes to illustrate the concept of the frontend and its interfaces.
    /// They are undocumented and not very well written and are using dummy-data with no connection to the actual server.
    /// On purpose. Because you should come up with your own implementation. :)
    /// </summary>
    public class Backend : IBackend
    {
        private Hashtable players;
        private Hashtable dragons;
        private ArrayList challenges;
        private GUIManager m;
        private String chatMsg="";
        private String commandMsg="";
        private String receivedMsg="";

         

        public Backend()
        {
            players = new Hashtable();
            dragons = new Hashtable();
        }

      

        public void sendCommandToConnector(String command)
        {
            Contract.Requires(command != null);

            
            //sendMessageToServer is called in Connector
        }

        public void moveLeft()
        {
            sendCommand("ask:mv:lft");
        }

        public void moveRight()
        {
            sendCommand("ask:mv:rgt");
        }

        public void moveDown()
        {
            sendCommand("ask:mv:dwn");
        }

        public void moveUp()
        {
            sendCommand("ask:mv:up");
        }


        public void storePlayer(Player p)
        {

            players[p.getId()] = p;
            //here appears an error - try to fix it :)
            m.repaint();
        }

        public void deletePlayer(Player p)
        {

            players.Remove(p.getId());

        }

        public void storeDragon(Dragon d)
        {
            dragons[d.getId()] = d;
            m.repaint();

        }

        public void deleteDragon(Dragon d)
        {
            dragons.Remove(d.getId());

        }

        public void setMap(Map m)
        {
            Contract.Requires(m != null);
            Contract.Requires(m.height > 0);
            Contract.Requires(m.width > 0);

            Contract.Ensures(m.height > 0);
            Contract.Ensures(m.width > 0);
        }

        public void giveTime()
        {
            DateTime dateValue = DateTime.Now;
            Console.WriteLine("Time: ", dateValue.ToString("hh:mm:ss.fff tt"));
        }

        public void sendCommand(string command)
        {
            if (command != null || command.Length != 0)
            {
                this.commandMsg = command;
            }
            Console.WriteLine("received command " + command);
            
        }

        public String getCommand()
        {       
            return commandMsg;     
        }
        
        public void sendChat(String message)
        {
            if (message != null || message.Length != 0)
            {
                this.chatMsg = message;
                //m.sendChatMessage();

            }

            Console.WriteLine("received chatmessage " + getChat() );
        }

        public String getChat()
        {
            return chatMsg;
        }

        public void setChatMsg(String chatmsg)
        {
            this.receivedMsg = chatMsg;
        }
      
        public String getChatMsg()
        {
            return receivedMsg;
        }

        public void giveTime(DateTime time)
        {
            Console.WriteLine("Time: ", time.ToString("hh:mm:ss.fff tt"));

        }

        //public List<IPositionable> getDragons() {
        //    List<IPositionable> dragons = new List<IPositionable>();
        //    //dragons.Add(new Entity(111, 0, 1, "dragon"));
        //    return dragons;
        //}

        public Hashtable getDragons()
        {
         
            return dragons;
        }
       
        //public List<IPositionable> getPlayers() {
        //    List<IPositionable> players = new List<IPositionable>();
        //    //players.Add(new Entity(01, 5, 5, "player"));
        //    return players;
        //}

        public Hashtable getPlayers() {
            return players;
        }

        public ArrayList getChallenges()
        {
           challenges = new ArrayList();
           return challenges;
        }

        public ITile[][] getMap()
        {
            int size = 10;
            // init
            ITile[][] map = new ITile[size][];
            for (int i = 0; i < size; i++)
            {
                map[i] = new ITile[size];
            }
            Random r = new Random();
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    List<MapCellAttribute> attr = new List<MapCellAttribute>();
                    switch (r.Next(0, 4))
                    {
                        case 0:
                            attr.Add(MapCellAttribute.WATER);
                            break;
                        case 1:
                            attr.Add(MapCellAttribute.HUNTABLE);
                            attr.Add(MapCellAttribute.FOREST);
                            break;
                        case 2:
                            attr.Add(MapCellAttribute.FOREST);
                            break;
                        case 3:
                            attr.Add(MapCellAttribute.UNWALKABLE);
                            break;
                        case 4:
                            break;

                    }
                    map[x][y] = new MapCell(x, y, attr);
                }
            }
            return map;
        }

    }
}
