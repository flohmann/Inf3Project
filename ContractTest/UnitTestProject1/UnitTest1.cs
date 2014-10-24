﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
       

        [TestMethod]
        public void pushMessageIntoBufferTest()
        {
           List<String> buffer=new List<String>();
           String message = "Begin:Player...";
           buffer.Add(message);

           Assert.IsTrue(buffer.Contains(message)); //Schaut ob die Message im Buffer ist
           Assert.IsNotNull(buffer);                //Schaut ob der Buffer null ist
           Assert.AreEqual("Begin:Player...", message);        //Vergleicht die geschickte Nachricht mit der im Buffer

            //bzw ist das doch dann der selbe Test für EbnfRulePlayer() ?
        }

       //PARSER
       
        [TestMethod]
        public void readBufferTest()
        {
            List<String> buffer = new List<String>();
            buffer.Add("Begin:Player");

            String tempCommand = buffer.FirstOrDefault();
            buffer.RemoveAt(0);

            Assert.IsFalse(buffer.Contains(tempCommand));
        }

        [TestMethod]
        public void EbnfRuleServerTest()
        {
            List<String> buffer = new List<String>();
            buffer.Add("begin:server");
            buffer.Add("ver:");
            buffer.Add("end:server");

            String tempCommand = buffer.FirstOrDefault();
            buffer.RemoveAt(0);

            Assert.IsFalse(buffer.Contains(tempCommand));
        }

        [TestMethod]
        public void EbnfRuleResult()
        {
            List<String> buffer = new List<String>();
            buffer.Add("begin:result");
            buffer.Add("round:");
            buffer.Add("running:");
            buffer.Add("delay:");
            buffer.Add("begin:opponents");
            buffer.Add("end:opponents");
            buffer.Add("end:result");

            String tempCommand = buffer.FirstOrDefault();
            buffer.RemoveAt(0);
            Assert.IsFalse(buffer.Contains(tempCommand));         
        }


       //BUFFER


        [TestMethod]
        public void addLineToBufferTest()
        {
            List<String> buffer = new List<String>();
            buffer.Add("begin:result");

            Assert.IsTrue(buffer.Contains(buffer.FirstOrDefault()));
        }

        [TestMethod]
        public void getLineFromBufferTest()
        {
            List<String> buffer = new List<String>();
            buffer.Add("begin:result");

            String tempCommand = buffer.FirstOrDefault();
            buffer.RemoveAt(0);

            Assert.IsFalse(buffer.Contains(tempCommand));                          
        }



       //BACKEND


       [TestMethod]
       public void sendCommandToConnectorTest()
       {
           String command = "ask:mv:up";
           Assert.AreEqual("ask:mv:up", command);
       }

        [TestMethod]
        public void storePlayerTest()
        {
            Player p = new Player();
            List<Player> players = new List<Player>();
            players.Add(p);

            Assert.AreEqual(p,players.Last());

        }

        [TestMethod]
        public void deletePlayerTest()
        {
            Player p = new Player();
            List<Player> players = new List<Player>();
            players.Add(p);

            Assert.AreEqual(p, players.Last());

            players.Remove(p);
            Assert.IsFalse(players.Contains(p));
        }

        [TestMethod]
        public void storeDragonTest()
        {
            Dragon d = new Dragon();
            List<Dragon> dragons = new List<Dragon>();
            dragons.Add(d);

            Assert.AreEqual(d,dragons.Last());
        }

        [TestMethod]
        public void deleteDragonTest()
        {
            Dragon d = new Dragon();
            List<Dragon> dragons = new List<Dragon>();
            dragons.Add(d);

            Assert.AreEqual(d, dragons.Last());

            dragons.Remove(d);
            Assert.IsFalse(dragons.Contains(d));
        }


        //FRONTEND

        [TestMethod]
        public void setMapTest()
        {
            Map m = new Map();
            m.Height = 30;
            m.Wigth = 30;


           Assert.AreEqual(30, m.Height);
           Assert.AreEqual(30, m.Wigth);
        }
    }
}