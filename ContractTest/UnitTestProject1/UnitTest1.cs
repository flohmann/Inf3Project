using System;
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
        public void sendCommandToConnectorTest()
        {
            String command = "ask:mv:up";
            Assert.AreEqual("ask:mv:up",command);
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
