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
        //the following have to be reset every single time
        private int id = -1;
        private String type = "";
        private bool busy = false;
        private String desc = "";
        private int x = -1;
        private int y = -1;
        private int points = -1;

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
            if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("player"))) || (tmp[1].Equals("dragon")))
            {
                parseEntity();
            }
            else if ((tmp[0].Equals("begin")) && ((tmp[1].Equals("map"))))
            {
                parseMap();
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
            //Yulia's code here <<==---- HERE!!!!!
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
    }
}
