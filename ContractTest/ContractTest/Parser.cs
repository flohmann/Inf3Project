﻿using System;
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
        private Mapcells cells;
        //the following have to be reset every single time
        private int id = -1;
        private String type = "";
        private bool busy = false;
        private String desc = "";
        private int x = -1;
        private int y = -1;
        private int points = -1;
        private int ver = -1;
        private int width;
        private int height;
        private int row;
        private int col;
        private bool walkable;
        private bool huntable;
        private bool forest;
        private bool water;
        private bool wall;
        private bool accepted;
        private DateTime time;
        private Dragon d;
        private Player p;

        public Parser(Buffer buffer)
        {
            backend = new Backend();
            this.buffer = buffer;

            //create read thread and start it
            Thread readBufferThread = new Thread(new ThreadStart(readBuffer));
            readBufferThread.Start();
        }

        public void readBuffer()
        {
            while (buffer != null)
            {
                if (buffer.bufferHasContent())
                {
                    msg = buffer.getMessageFromBuffer();
                    removeFrame();
                }
            }

        }

        private void removeFrame()
        {
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

                    //delete the begin:upd and end:udp if existing
                    //tmp = msg[0].Split(':');
                    //if ((tmp[0].Equals("begin")) && (tmp[1].Equals("upd")))
                    //{
                    //    tmp = msg[msg.Count() - 1].Split(':');
                    //    if ((tmp[0].Equals("end")) && (tmp[1].Equals("upd")))
                    //    {
                    //        msg.RemoveAt(0);
                    //        msg.RemoveAt(msg.Count - 1);
                    //    }
                    //}
                    getEBNF();
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

        private void getEBNF()
        {
            String[] tmp = msg[0].Split(':');
            if ((tmp[0].Equals("begin")) && (tmp[1].Equals("player")) || (tmp[1].Equals("dragon")))
            {
                msg.RemoveAt(0);
                parseEntity();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("map"))))
            {
                msg.RemoveAt(0);
                parseMap();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("server"))))
            {
                msg.RemoveAt(0);
              //  parseServer();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("challenge"))))
            {
                msg.RemoveAt(0);
                parseChallenge();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("time"))))
            {
                msg.RemoveAt(0);
                parseTime();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("upd"))))
            {
                msg.RemoveAt(0);
                parseUpd();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("del"))))
            {
                msg.RemoveAt(0);
                parseDel();
            }
            //every possible ENBF command needs its own if
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
                                    tmp = msg[0].Split(':');
                                    if (tmp[0].Equals("points"))
                                    {
                                        this.points = Int32.Parse(tmp[1]);
                                        msg.RemoveAt(0);
                                        createPlayer();
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
                    this.height =Int32.Parse(tmp[1]);
                    msg.RemoveAt(0);
                    tmp = msg[0].Split(':');

                    if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("cells"))))
                    {   
                        do{
                        parseCells();

                        //kick end ???? 

                        tmp = msg[0].Split(':');
                        } while (!((tmp[0].Equals("end")) && ((tmp[1].Equals("cells")))));

                    }

                }
            }
            createMap();
        }


        private void parseCells()
        {
            String[] tmp = msg[0].Split(':');
            if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("cell"))))
            {

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
                            do
                            {
                                parseProperty();
                                tmp = msg[0].Split(':');
                            } while (!((tmp[0].Equals("end")) && ((tmp[1].Equals("props")))));
                        }
                    }
                }
                if ((tmp[0].Equals("end")) && ((tmp[1].Equals("cell"))))
                {
                    parseMap();
                }

            }
            throw new Exception("No Cells");
        }



        private void parseProperty()
        {
            String[] tmp = msg[0].Split(':');
            if (tmp[0].Equals("WALKABLE"))
            {

                if (tmp[1].Equals("true"))
                {
                    this.walkable = true;
                }
                else
                {
                    this.walkable = false;
                }
                msg.RemoveAt(0);
            }
            tmp = msg[0].Split(':');
            if (tmp[0].Equals("HUNTABLE"))
            {
                if (tmp[1].Equals("true"))
                {
                    this.huntable = true;
                }
                else
                {
                    this.huntable = false;
                }
                msg.RemoveAt(0);
            }
            tmp = msg[0].Split(':');
            if (tmp[0].Equals("FOREST"))
            {
                if (tmp[1].Equals("true"))
                {
                    this.forest = true;
                }
                else
                {
                    this.forest = false;
                }
                msg.RemoveAt(0);
            }
            tmp = msg[0].Split(':');
            if (tmp[0].Equals("WATER"))
            {
                if (tmp[1].Equals("true"))
                {
                    this.water = true;
                }
                else
                {
                    this.water = false;
                }
                msg.RemoveAt(0);
            }
            tmp = msg[0].Split(':');
            if (tmp[0].Equals("WALL"))
            {
                if (tmp[1].Equals("true"))
                {
                    this.wall = true;
                }
                else
                {
                    this.wall = false;
                }
                msg.RemoveAt(0);
            }
            if ((tmp[0].Equals("end")) && ((tmp[1].Equals("props"))))
            {
                parseCells();
            }

            throw new Exception("No Property");
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
                //what call we ?? 
            }
            throw new Exception("No Challenge");
        }


        private void parseTime()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("time"))
            {
                this.time = DateTime.Parse(tmp[1]);
                msg.RemoveAt(0);
            }
            if ((tmp[0].Equals("end")) && ((tmp[1].Equals("time"))))
            {
                msg.RemoveAt(0);
                backend.giveTime();

            }
            throw new Exception("No Time");
        }

        private void parseUpd()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("Dragon"))
            {
                backend.storeDragon(d);
                msg.RemoveAt(0);
            }
            if (tmp[0].Equals("Player"))
            {
                backend.storePlayer(p);
                msg.RemoveAt(0);
            }
            if (tmp[0].Equals("Maocell"))
            {
                createMap();
                msg.RemoveAt(0);
            }

            throw new Exception("No update");

        }
        private void parseDel()
        {
            String[] tmp = msg[0].Split(':');

            if (tmp[0].Equals("Dragon"))
            {
                backend.deleteDragon(d);
                msg.RemoveAt(0);
            }
            if (tmp[0].Equals("Player"))
            {
                backend.deletePlayer(p);
                msg.RemoveAt(0);
            }

            throw new Exception("No delete");

        }

        private void parseOnline()
        {

        }

        private void createPlayer()
        {
            //used variables - int id, String type, bool busy, String desc, int x, int y, int points
            if ((id >= 0) && (type != "") && (x < 0) && (y < 0) && (points < 0))
            {
                Player p = new Player(id, x, y, type, points, desc, busy);
                backend.storePlayer(p);
                clearVars();
            }
        }

        private void createDragon()
        {
            //used variables - int id, String type, bool busy, String desc, int x, int y
            if ((id >= 0) && (type != "") && (x < 0) && (y < 0))
            {
                Dragon d = new Dragon(id, x, y, type, busy, desc);
                backend.storeDragon(d);
                clearVars();
            }
        }

        private void createServer()
        {
            //CREATE SERVER WUUUUUT -F
        }

        private void createMap()
        {
            if ((width > 0) && (height > 0)) { 
            backend.getMap();
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
        }

        private void convertDragon(List<String> msg)
        {
            //content here
        }


    }
}
