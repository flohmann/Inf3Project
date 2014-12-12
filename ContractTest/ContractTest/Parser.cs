using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using Inf3Project;
using Frontend;
using System.Threading;

namespace Inf3Project
{
    class Parser
    {
        /*
         * variables 
         */
        private Backend backend;
        private Buffer buffer;
        List<String> msg;
        private Connector connector;
        private String sender;
        private Map m;
        //the following have to be reset every single time
        private int id = -1;
        private String type = "";
        private bool busy = false;
        private String desc = "";
        private int x = -1;
        private int y = -1;
        private int points = -1;
        private int width = -1;
        private int height = -1;
        private int row = -1;
        private int col = -1;
        private bool walkable = false;
        private bool huntable = false;
        private bool forest = false;
        private bool water = false;
        private bool wall = false;
        private bool accepted = false;
        private bool delete = false;
        private int ver = -1;
        private DateTime time;
        private int yourId;
        private int online;
        private int round = 0;
        private bool running = false;
        private int delay = -1;
        private String decision = "";
        private int total = 0;
        private String mes = "";

        public Parser(Buffer buffer, Connector con)
        {
            this.connector = con;
            backend = new Backend(connector);
            this.buffer = buffer;

            //create read thread and start it
            Thread readBufferThread = new Thread(new ThreadStart(readBuffer));
            readBufferThread.Start();
        }

        //new method to parse the string from the buffer to a List<String>
        private List<String> parseBufferMsg()
        {
            List<String> tmpList = new List<string>();
            String[] tmp = buffer.getMessageFromBuffer().Split('$');
            for (int i = 0; i < tmp.Length; i++)
            {
                tmpList.Add(tmp[i]);
            }
            return tmpList;
        }

        public void readBuffer()
        {
            while (buffer != null)
            {
                if (buffer.bufferHasContent())
                {
                    msg = parseBufferMsg();
                    removeFrame();
                }
            }

        }

        private void removeFrame()
        {
            Console.WriteLine("--> in removeFrame");
            //delete the begin:x and end:x frame
            String[] tmp = msg[0].Split(':');
            int value;
            if ((tmp[0].Equals("begin")) && (Int32.TryParse(tmp[1], out value)))
            {
                value = Int32.Parse(tmp[1]);
                tmp = msg[msg.Count() - 1].Split(':');
                if ((tmp[0].Equals("end")) && (Int32.TryParse(tmp[1], out value)))
                {
                    msg.RemoveAt(0);
                    msg.RemoveAt(msg.Count - 1);

                    getState();
                }
                else
                {
                    throw new System.FormatException("parser.removeFrame() - no end:x found");
                }
            }
            else
            {
                throw new System.FormatException("parser.removeFrame() - no begin:x found");
            }
        }

        private void getState()
        {
            //  delete the begin:upd and end:udp if existing
            String[] tmp = msg[0].Split(':');

            if ((tmp[0].Equals("begin")) && (tmp[1].Equals("upd")))
            {
                tmp = msg[msg.Count() - 1].Split(':');
                if ((tmp[0].Equals("end")) && (tmp[1].Equals("upd")))
                {
                    delete = false;
                    msg.RemoveAt(0);
                    msg.RemoveAt(msg.Count - 1);
                    getEBNF();
                }
            }
            else if ((tmp[0].Equals("begin")) && (tmp[1].Equals("del")))
            {
                tmp = msg[msg.Count() - 1].Split(':');
                if ((tmp[0].Equals("end")) && (tmp[1].Equals("del")))
                {
                    delete = true;
                    msg.RemoveAt(0);
                    msg.RemoveAt(msg.Count - 1);
                    getEBNF();
                }
            }
            else
            {
                getEBNF();
            }
        }

        private void getEBNF()
        {
            String[] tmp = msg[0].Split(':');
            if ((tmp[0].Equals("begin")) && (tmp[1].Equals("player")) || (tmp[1].Equals("dragon")))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseEntity();
            }

            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("ents"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                getEBNF();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("map"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseMap();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("server"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                //  parseServer();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("challenge"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseChallenge();

            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("time"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseTime();

            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("cells"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseCells();

            }

            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("yourId"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseYourId();

            }

            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("online"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseOnline();

            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("mes"))))
            {
                msg.RemoveAt(0);
                msg.RemoveAt(msg.Count - 1);
                parseChat();

            }
            //every possible ENBF command needs its own if

        }

        public void parseChat()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("srcid"))
            {
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("scr"))
                {
                    this.sender = tmp[1];
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');
                }
                if (tmp[0].Equals("txt"))
                {
                    this.mes = tmp[1];
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');
                }
                if ((tmp[0].Equals("end")) && ((tmp[1].Equals("mes"))))
                {
                    msg.RemoveAt(0);
                    backend.setChatMsg(sender, mes);
                }
            }
        }

        public void parseEntity()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("id"))
            {
                this.id = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("type"))
                {
                    this.type = tmp[1];
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');
                    if (tmp[0].Equals("busy"))
                    {
                        if (tmp[1].Equals("true"))
                        {
                            this.busy = true;
                        }
                        else
                        {
                            this.busy = false;
                        }
                        msg.RemoveAt(0);
                        tmp = msg[0].Split(':');
                        if (tmp[0].Equals("desc"))
                        {
                            this.desc = tmp[1];
                            msg.RemoveAt(0);
                            tmp = msg[0].Split(':');
                            if (tmp[0].Equals("x"))
                            {
                                this.x = Int32.Parse(tmp[1]);
                                msg.RemoveAt(0);
                                tmp = msg[0].Split(':');
                                if (tmp[0].Equals("y"))
                                {
                                    this.y = Int32.Parse(tmp[1]);
                                    msg.RemoveAt(0);
                                    //can only use Split(msg), if a row is in msg left
                                    if (msg.Count > 0)
                                    {
                                        tmp = msg[0].Split(':');
                                        if (tmp[0].Equals("points"))
                                        {
                                            this.points = Int32.Parse(tmp[1]);
                                            msg.RemoveAt(0);

                                            createPlayer();
                                        }
                                    }
                                    else
                                    {
                                        createDragon();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void parseMap()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("width"))
            {
                this.width = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("height"))
                {
                    this.height = Int32.Parse(tmp[1]);
                    //create new Map
                    m = new Map(width, height);
                    backend.setMap(m);
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');

                    if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("cells"))))
                    {
                        do
                        {
                            msg.RemoveAt(0);
                            parseCells();
                            tmp = msg[0].Split(':');
                        } while (!((tmp[0].Equals("end")) && ((tmp[1].Equals("cells")))));
                    }
                }
            }
            createMap();
            backend.setMap(m);
            backend.setWalkableMap();
        }

        private void parseCells()
        {
            String[] tmp = msg[0].Split(':');
            if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("cell"))))
            {
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("row"))
                {
                    this.row = Int32.Parse(tmp[1]);
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');
                    if (tmp[0].Equals("col"))
                    {
                        this.col = Int32.Parse(tmp[1]);
                        msg.RemoveAt(0);
                        tmp = msg[0].Split(':');
                        if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("props"))))
                        {
                            msg.RemoveAt(0);
                            do
                            {
                                parseProperty();
                                tmp = msg[0].Split(':');
                            } while (!((tmp[0].Equals("end")) && ((tmp[1].Equals("props")))));
                            msg.RemoveAt(0);
                        }
                    }
                }
            }
            if (row >= 0 && col >= 0)
            {
                List<MapCellAttribute> attributes = new List<MapCellAttribute>();
                if (walkable)
                {
                    attributes.Add(MapCellAttribute.WALKABLE);
                }
                if (huntable)
                {
                    attributes.Add(MapCellAttribute.HUNTABLE);
                }
                if (forest)
                {
                    attributes.Add(MapCellAttribute.FOREST);
                }
                if (water)
                {
                    attributes.Add(MapCellAttribute.WATER);
                }
                if (wall)
                {
                    attributes.Add(MapCellAttribute.WALL);
                }


                m.addCell(new MapCell(this.row, this.col, attributes));
            }
            clearVars();
        }

        private void parseProperty()
        {
            String[] tmp = msg[0].Split(':');
            if (tmp[0].Equals("WALKABLE"))
            {
                this.walkable = true;
                msg.RemoveAt(0);
            }
            else if (tmp[0].Equals("HUNTABLE"))
            {
                this.huntable = true;
                msg.RemoveAt(0);
            }
            else if (tmp[0].Equals("FOREST"))
            {
                this.forest = true;
                msg.RemoveAt(0);
            }
            else if (tmp[0].Equals("WATER"))
            {
                this.water = true;
                msg.RemoveAt(0);
            }
            else if (tmp[0].Equals("WALL"))
            {
                this.wall = true;
                msg.RemoveAt(0);
            }
        }

        private void parseTime()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("time"))
            {
                this.id = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
                if ((tmp[0].Equals("end")) && ((tmp[1].Equals("time"))))
                {
                    this.time = DateTime.Parse(tmp[1]);
                    msg.RemoveAt(0);
                    backend.giveTime(time);
                }
                throw new Exception("No Time");
            }
        }

        private void parseChallenge()
        {

            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("id"))
            {
                this.id = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("type"))
                {

                    if ((tmp[1].Equals("Dragon") || tmp[1].Equals("Staghunt")) || tmp[1].Equals("Skirmish"))
                    {
                        this.type = tmp[1];
                        msg.RemoveAt(0);
                    }
                    tmp = msg[0].Split(':');
                    if (tmp[0].Equals("accepted"))
                    {
                        if (tmp[1].Equals("true"))
                        {
                            this.accepted = true;
                        }
                        else
                        {
                            this.accepted = false;
                        }
                        msg.RemoveAt(0);
                    }
                    if ((tmp[0].Equals("end")) && ((tmp[1].Equals("challenge"))))
                    {
                        msg.RemoveAt(0);

                    }

                }

            }
            throw new Exception("No Challenge");
        }

        private void parseYourId()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("id"))
            {
                this.yourId = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
            } if ((tmp[0].Equals("end")) && ((tmp[1].Equals("challenge"))))
            {
                msg.RemoveAt(0);
                backend.setYourId(this.yourId);
                this.clearVars();
            }
            else
            {
                throw new Exception("There is no id");
            }
        }

        private void parseOnline()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("online"))
            {
                this.online = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if ((tmp[0].Equals("end")) && ((tmp[1].Equals("online"))))
                {
                    backend.setOnline(online);
                    this.clearVars();

                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        private void parseResult()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("round"))
            {
                this.round = Int32.Parse(tmp[1]);
                msg.RemoveAt(0);
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("running"))
                {
                    if (tmp[1].Equals("true"))
                    {
                        this.running = true;
                    }
                    else
                    {
                        this.running = false;
                    }
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');
                    if (tmp[0].Equals("delay"))
                    {
                        this.delay = Int32.Parse(tmp[1]);
                        msg.RemoveAt(0);
                        tmp = msg[0].Split(':');
                        if ((tmp[0].Equals("begin")) && (tmp[1].Equals("opponents")))
                        {
                            parseOpponent();
                        }

                        if ((tmp[0].Equals("end")) && ((tmp[1].Equals("result"))))
                        {
                            clearVars();
                        }

                        else { throw new Exception("No Result"); }

                    }
                }
            }
            else
                throw new Exception("No Result");
        }

        private void parseOpponent()
        {
            String[] tmp = msg[0].Split(':');
            while (!(tmp[0].Equals("end") && tmp[1].Equals("opponent")))
            {
                tmp = msg[0].Split(':');
                if (tmp[0].Equals("id"))
                {
                    this.id = Int32.Parse(tmp[1]);
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');
                    if (tmp[0].Equals("decision"))
                    {
                        this.decision = tmp[1];
                        msg.RemoveAt(0);
                        tmp = msg[0].Split(':');
                        if (tmp[0].Equals("points"))
                        {
                            this.points = Int32.Parse(tmp[1]);
                            msg.RemoveAt(0);
                            tmp = msg[0].Split(':');
                            if (tmp[0].Equals("total"))
                            {
                                this.total = Int32.Parse(tmp[1]);
                                msg.RemoveAt(0);
                                tmp = msg[0].Split(':');
                                if (tmp[0].Equals("end") && tmp[1].Equals("opponent"))
                                {

                                    Opponent o = new Opponent(id, decision, points, total);
                                    clearVars();
                                }
                                else
                                {
                                    throw new Exception("NO OPPONENT");
                                }
                            }
                        }

                    }
                }
                else
                {
                    throw new Exception("NO OPPONENT");
                }
            }
        }

        private void createPlayer()
        {
            //used variables - int id, String type, bool busy, String desc, int x, int y, int points
            if ((id >= 0) && (type != "") && (x > 0) && (y > 0) && (points >= 0))
            {
                Player p = new Player(id, x, y, type, points, desc, busy);
                if (!delete)
                {
                    backend.storePlayer(p);
                    clearVars();
                }
                else
                {
                    backend.deletePlayer(p);
                    clearVars();
                }


            }
        }

        private void createDragon()
        {
            //used variables - int id, String type, bool busy, String desc, int x, int y
            if ((id >= 0) && (type != "") && (x > 0) && (y > 0))
            {
                Dragon d = new Dragon(id, x, y, type, busy, desc);
                if (!delete)
                {
                    backend.storeDragon(d);
                    clearVars();
                }
                else
                {
                    backend.deleteDragon(d);
                    clearVars();
                }
            }
        }

        private void createServer()
        {

        }

        private void createMap()
        {
            if ((m.width > 0) && (m.height > 0))
            {
                backend.getTilesOfMap();
                clearVars();
            }
        }

        private void clearVars()
        {
            //at this moment it only clears the variables of the Player
            //needs to be improoved to all vars
            this.id = -1;
            this.type = "";
            this.busy = false;
            this.desc = "";
            this.x = -1;
            this.y = -1;
            this.points = -1;
            this.width = -1;
            this.height = -1;
            this.row = -1;
            this.col = -1;
            this.walkable = false;
            this.huntable = false;
            this.forest = false;
            this.water = false;
            this.wall = false;
            this.accepted = false;
            this.delete = false;
            this.ver = -1;
            this.time = new DateTime();
            this.yourId = -1;
            this.online = -1;
            this.round = 0;
            this.running = false;
            this.delay = -1;
            this.decision = "";
            this.total = 0;
            this.mes = "";
        }

    }
}
