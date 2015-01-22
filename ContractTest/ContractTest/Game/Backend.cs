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
using System.Runtime.InteropServices;
using Inf3Project.Observer;


namespace Inf3Project
{
    /// <summary>
    /// All classes in the test-directory are just classes to illustrate the concept of the frontend and its interfaces.
    /// They are undocumented and not very well written and are using dummy-data with no connection to the actual server.
    /// On purpose. Because you should come up with your own implementation. :)
    /// </summary>
    public class Backend : IBackend
    {
        [DllImport("PathFinder", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr findPath(int from, int to, int[] map, int mapw, int maph, int plength);
        [DllImport("PathFinder", CallingConvention = CallingConvention.Cdecl)]
        public static extern void freeArray(IntPtr pointer);

        private bool firstTimeMap = true;
        private bool firstTimeBoard = true;
        private List<Player> players;
        private List<Dragon> dragons;
        private ITile[][] mapMemory;
        private ArrayList challenges;
        public GUIManager m;
        private String chatMsg = "";
        private String commandMsg = "";
        private String receivedMsg = "";
        private int yourId;
        private int online;
        private Map map;
        private bool[][] walkableMap;
        private int[] walkableMap1D;
        private Connector connector;
        private Pathwalker pathwalker;
        private Player myPlayer;

        public Backend(Connector con)
        {
            this.connector = con;
            players = new List<Player>();
            dragons = new List<Dragon>();
            pathwalker = new Pathwalker(this);
        } 

        public void setMap(Map map)
        {
            this.map = map;
        }
     
        public Map getMap()
        {
            return map;
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
                else
                {
                    Console.WriteLine("Update");
                }
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
                else
                {
                    Console.WriteLine("Update");
                }
            }

        }

        // method send Comand from chatfield to Server 

        public void sendCommand(string command)
        {
            if (command != null || command.Length != 0)
            {
                this.connector.getSender().sendMessageToServer(command);
            }
            Console.WriteLine("'" + command + "'" + " SEND TO SERVER");
        }

        public String getCommand()
        {
            return commandMsg;
        }

        // send chatmessage from chatfield to server
        public void sendChat(String message)
        {
            if (message != null || message.Length != 0)
            {
                //changed something here
                this.connector.getSender().sendMessageToServer("ask:say:"+message);
            }
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

        /* 
         * translate map into 2D ITile array and returns it
         * initalize Gui
        */
        public ITile[][] getTilesOfMap()
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
            if (firstTimeBoard)
            {
                firstTimeBoard = false;
                m.initGUI();
            }
            return mapMemory;
        }

        /* 
         * checks every cell of the map if its walkable (true, false) or not
         * fills the bool 2D array "walkable" with this data
        */
        public void setWalkableMap()
        {
            this.walkableMap = new bool[map.getCells().Length][];
            for (int i = 0; i < map.getCells().Length; i++)
            {
                walkableMap[i] = new bool[map.getCells()[i].Length];
                for (int j = 0; j < map.getCells()[i].Length; j++)
                {
                    if (map.getCells()[i][j].isWalkable())
                    {
                        walkableMap[i][j] = true;
                    }
                    else
                    {
                        walkableMap[i][j] = false;
                    }
                }
            }
        }

        public void setWalkable1DMap()
        {
            walkableMap1D = new int[map.width * map.height];
            if (map != null)
            {
                int counter = 0;

                for (int x = 0; x < map.width; x++)
                {
                    for (int y = 0; y < map.height; y++)
                    {
                        if (map.getCells()[y][x].isWalkable())
                        {
                            walkableMap1D[counter] = 1;
                        }
                        else
                        {
                            walkableMap1D[counter] = 0;
                        }
                        counter++;
                    }
                }
            }
        }

        public Boolean[][] getWalkableMap()
        {
            return walkableMap;
        }

        public int[] getWalkable1dMap()
        {
            return walkableMap1D;
        }

        public int coordinateToPoint(int row, int col)
        {
            return (row * map.width + col);
        }

        public void pathfinder(MapCell start, MapCell end)
        {
            //set myPlayer
            foreach (Player p in players)
            {
                if (yourId == p.getId())
                {
                    myPlayer = p;
                }
            }
            m.setLock(true);

            try
            {
                int from = coordinateToPoint(start.getYPosition(), start.getXPosition());
                int to = coordinateToPoint(end.getYPosition(), end.getXPosition());

                Console.WriteLine("START-COO (" +start.getXPosition() + " / " + start.getYPosition() + ")");
                Console.WriteLine("END-COO (" + end.getXPosition() + " / " + end.getYPosition() + ")");
                Console.WriteLine("START-NR X=" + from + "  END-NR Y=" + to);

                int pathLength = map.width * map.height / 4;
                int[] path = new int[pathLength];

                IntPtr pointer = findPath(from, to, getWalkable1dMap(), map.width, map.height, path.Length);
                Marshal.Copy(pointer, path, 0, path.Length);


                List<MapCell> cellList = new List<MapCell>();
                foreach (int item in path)
                {
                    cellList.Add(this.map.getCell(item % map.width, item / map.width));
                }


                m.setLock(false);
                pathwalker.setCoordinates(cellList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public MapCell getMapCell(int x, int y)
        {
            return map.getCell(x, y);
        }

        public MapCell getMyPlayerPos()
        {
            return map.getCell(players[0].getXPosition(), players[0].getYPosition());
        }
    }
}