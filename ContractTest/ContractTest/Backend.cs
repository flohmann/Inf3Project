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
        private DefaultGui defaultGui;
        private Thread GUIThread;

        public Backend()
        {
            players = new Hashtable();
            dragons = new Hashtable();
            initGUI(this);
        }

        public static void initGUI(Backend ba)
        {
            ba.GUIThread = new Thread(GUIThreadStarter);
            ba.GUIThread.Name = "GuiThread";
            ba.GUIThread.Start(ba);
        }

        public static void GUIThreadStarter(object ba)
        {
            try
            {
                if (ba != null && ba.GetType() == typeof(Backend))
                {
                    Backend be = (Backend)ba;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(true);
                    Application.Run(be.defaultGui = new DefaultGui(be));
                }
            }
            catch(Exception e){
                //content needed
            }
            
        }

        public void sendCommandToConnector(String command)
        {
            Contract.Requires(command != null);

            
            //sendMessageToServer is called in Connector
        }

        public void storePlayer(Player p)
        {
            
            
            Contract.Requires(dragons != null);
            //players.Add(8, "Nasti");
            Contract.Ensures(players.Contains(p));

        }

        public void deletePlayer(Player p)
        {
            Contract.Requires(p != null);

            Contract.Ensures(!players.Contains(p));

        }

        public void storeDragon(Dragon d)
        {
            Contract.Requires(d != null);

            Contract.Ensures(dragons.Contains(d));

        }

        public void deleteDragon(Dragon d)
        {
            Contract.Requires(d != null);

            Contract.Ensures(!dragons.Contains(d));

        }

        public void setMap(Map m)
        {
            Contract.Requires(m != null);
            Contract.Requires(m.height > 0);
            Contract.Requires(m.width > 0);

            Contract.Ensures(m.height > 0);
            Contract.Ensures(m.width > 0);
        }

        public void sendCommand(string command)
        {
            Console.WriteLine("received command " + command);
        }

        public void sendChat(string message)
        {
            Console.WriteLine("received chatmessage " + message);
        }

        public List<IPositionable> getDragons() {
            List<IPositionable> dragons = new List<IPositionable>();
            dragons.Add(new Entity(111, 0, 1, "dragon"));
            return dragons;
        }
       
        public List<IPositionable> getPlayers() {
            List<IPositionable> players = new List<IPositionable>();
            players.Add(new Entity(01, 5, 5, "player"));
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
