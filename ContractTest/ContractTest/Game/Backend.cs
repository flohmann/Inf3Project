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
        private bool firstTimeMap = true;
        private bool firstTimeBoard = true;
        private List<Player> players;
        private List<Dragon> dragons;
        private ITile[][] mapMemory;
        private ArrayList challenges;
        public GUIManager m;
        private String chatMsg="";
        private String commandMsg="";
        private String receivedMsg="";
        private int yourId;
        private int online;
        private Map map;
        //private bool mapSave=true;
        private Connector connector;
         
        public Backend(Connector con)
        {
            this.connector = con;
            players = new List<Player>();
            dragons = new List<Dragon>();
            //this.m = new GUIManager(this);
        }

        public void sendCommandToConnector(String command)
        {
            //content here
        }

        public void setMap(Map map){
            this.map = map;
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

        //store the Player in a List and Update when the same Player appears
        public void storePlayer(Player p)
        {
            deletePlayer(p);
            players.Add(p);
            if (!firstTimeMap)
            {
                m.repaint();
            }
        }
        
        // delete the Player
        public void deletePlayer(Player p)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].getId() == p.getId())
                {
                    players.RemoveAt(i);
                }
                else Console.WriteLine("Update");
            }
                

        }
        //store the Dragon in a List and Update when the same Dragon appears
        public void storeDragon(Dragon d)
        {
            deleteDragon(d);
            dragons.Add(d);
            if (!firstTimeMap)
            {
                m.repaint();
            }
        }

        // Delete the Dragon
        public void deleteDragon(Dragon d)
        {
            for (int i = 0; i < dragons.Count; i++)
            {
                if (dragons[i].getId() == d.getId())
                {
                    dragons.RemoveAt(i);
                }
                else Console.WriteLine("Update");
            }

        }
   
        public void sendCommand(string command)
        {
            if (command != null || command.Length != 0)
            {
           
                this.connector.getSender().sendMessageToServer(command);

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
                this.connector.getSender().sendMessageToServer(message);
            }
            Console.WriteLine("received chatmessage " + getChat() );
        }

        public String getChat()
        {
            return chatMsg;
        }

        public void setChatMsg(String name, String text)
        {
            m.sendChatMessage(name, text);
        }
      
        public String getChatMsg()
        {
            return receivedMsg;
        }

        public void giveTime(DateTime time)
        {
            Console.WriteLine("Time: ", time.ToString("hh:mm:ss.fff tt"));

        }

        public List<IPositionable> getDragons()
        {
            List<IPositionable> dragon = new List<IPositionable>();
            foreach (Dragon d in dragons)
            {
                dragon.Add(d);
            }
            return dragon;
        }
        
        public List<IPositionable> getPlayers()
        {
            List<IPositionable> player = new List<IPositionable>();
            foreach (Player p in players)
            {
                player.Add(p);
            }

            return player;
        }

        public int getOnline()
        {
            return online;
        }

        public void setOnline(int online)
        {
            this.online = online;
        }

        public void setYourId(int yourId)
        {
            this.yourId = yourId;
        }

        public int getYourId()
        {
            return yourId;
        }

        public ArrayList getChallenges()
        {
           challenges = new ArrayList();
           return challenges;
        }

        public ITile[][] getMap()
        {
            if (firstTimeMap)
            {
                this.m = new GUIManager(this);
                firstTimeMap = false;
            }
            ITile[][] iTileMap = new ITile[map.height][];
            for (int x = 0; x < iTileMap.Length; x++)
            {
                iTileMap[x] = new ITile[map.width];
            }
            for (int i = 0; i < map.height; i++)
            {
                for (int j = 0; j < map.width; j++)
                {
                    iTileMap[i][j] = map.cells[i][j];
                }
            }
            this.mapMemory = iTileMap;

            //if (mapSave)
            //{
            //    int size = 20;
            //    // init
            //    ITile[][] map = new ITile[size][];
            //    for (int i = 0; i < size; i++)
            //    {
            //        map[i] = new ITile[size];
            //    }
            //    Random r = new Random();
            //    for (int x = 0; x < size; x++)
            //    {
            //        for (int y = 0; y < size; y++)
            //        {
            //          List<MapCellAttribute> attr = new List<MapCellAttribute>();

            //          attr.Add(MapCellAttribute.UNWALKABLE);

            //            }
            //            map[x][y] = new MapCell(x, y, attr);
            //            this.mapMemory = map;
            //            mapSave = false;
            //        }
            //    
            //}
            if (firstTimeBoard)
            {
                firstTimeBoard = false;
                m.initGUI();
            }
            return mapMemory;
        }
    }
}
