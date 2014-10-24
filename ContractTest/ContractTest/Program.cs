﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using System.Collections;
using ContractTest;

namespace ContractTest
{


}


    class Program
    {
        private Boolean isConnected = false;
        private Boolean isEmpty = false;
        private Boolean isChanged = false;
        private List<String> buffer = new List<String>();
        private List<Player> players = new List<Player>();
        private List<Dragon> dragons = new List<Dragon>();
        private List<Mapcells> mapcells = new List<Mapcells>();
        private List<Challenge> challenges = new List<Challenge>();
       
        

        // CONNECTOR 

        public void connect(String ip, int port){
            Contract.Requires(port >= 0 && port <= 65535);
            Contract.Requires(ip != null && ip.Length > 6 && ip.Length < 16);    

         
        }



        public void pushMessageIntoBuffer(List<String> buffer, String message)
        {
            Contract.Requires(buffer.Count >= 0);
            Contract.Requires(message != null);
            

            Contract.Ensures(buffer.Contains(message));
            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) + 1));

        }

       public void sendMessageToServer(String message){
           Contract.Requires(isConnected == true);
           Contract.Requires(message != null);

       }     


        // PARSER

       public void readBuffer(List<String> buffer)
       {
            Contract.Requires(buffer.Count>0);

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
        }

       public void EbnfRuleServer(List<String> buffer)
       {
            Contract.Requires(buffer.Count > 0);
            Contract.Requires(buffer.Contains("begin:server"));
            Contract.Requires(buffer.Contains("ver:"));
            Contract.Requires(buffer.Contains("end:server"));

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
        }


       public void EbnfRuleResult(List<String> buffer)
       {
            Contract.Requires(buffer.Count > 0);
            Contract.Requires(buffer.Contains("begin:result"));
            Contract.Requires(buffer.Contains("round:"));
            Contract.Requires(buffer.Contains("running:"));
            Contract.Requires(buffer.Contains("delay:"));
            Contract.Requires(buffer.Contains("begin:opponents"));
            Contract.Requires(buffer.Contains("end:opponents"));
            Contract.Requires(buffer.Contains("end:result"));

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
        }
       public void EbnfRuleOpponents(List<String> buffer)
       {
            Contract.Requires(buffer.Count > 0);
            Contract.Requires(buffer.Contains("begin:opponents"));
            Contract.Requires(buffer.Contains("id:"));
            Contract.Requires(buffer.Contains("decision:"));
            Contract.Requires(buffer.Contains("points:"));
            Contract.Requires(buffer.Contains("total:"));
            Contract.Requires(buffer.Contains("end:opponents"));
      
            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
        }
       public Challenge EbnfRuleChallenge(List<String> buffer)
       {
            Contract.Requires(buffer.Count > 0);

            Contract.Requires(buffer.Contains("begin:challenge"));
            Contract.Requires(buffer.Contains("id:"));
            Contract.Requires(buffer.Contains("type:"));
            Contract.Requires(buffer.Contains("DRAGON"));
            Contract.Requires(buffer.Contains("STAGHUNT")); 
            Contract.Requires(buffer.Contains("SKIRMISH"));
            Contract.Requires(buffer.Contains("accepted:"));
            Contract.Requires(buffer.Contains("end:challenge"));

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
            return default(Challenge);
        }

       public Dragon EbnfRuleDragon(List<String> buffer)
       {
            Contract.Requires(buffer.Count > 0);
            Contract.Requires(buffer.Contains("begin:dragon"));
            Contract.Requires(buffer.Contains("id:"));
            Contract.Requires(buffer.Contains("type:Dragon"));
            Contract.Requires(buffer.Contains("busy:"));
            Contract.Requires(buffer.Contains("desc:"));
            Contract.Requires(buffer.Contains("x:"));
            Contract.Requires(buffer.Contains("y:"));
            Contract.Requires(buffer.Contains("end:dragon"));

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
            return default(Dragon);
        
        }
       public Player EbnfRulePlayer(List<String> buffer)
       {
            Contract.Requires(buffer.Count > 0);
            Contract.Requires(buffer.Contains("begin:player"));
            Contract.Requires(buffer.Contains("id"));
            Contract.Requires(buffer.Contains("type:Player"));
            Contract.Requires(buffer.Contains("busy:")); 
            Contract.Requires(buffer.Contains("desk:"));
            Contract.Requires(buffer.Contains("x:"));
            Contract.Requires(buffer.Contains("y:"));
            Contract.Requires(buffer.Contains("points"));
            Contract.Requires(buffer.Contains("end:player"));

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
            return default(Player);
        }



        public void transferMethodServer(){
            Contract.Requires(isConnected == true);

        }

        public void transferMethodResult(){

        }

        public void transferMethodOpponent(){

        }

        public void transferMethodChallenge(Challenge c){
            Contract.Requires(c != null);

            Contract.Ensures(challenges.Count == Contract.OldValue((challenges.Count) + 1));
        }

        public void transferMethodDragon(Dragon d){
            Contract.Requires(d != null);

            Contract.Ensures(dragons.Count == Contract.OldValue((dragons.Count) + 1));
        }

        public void transferMethodPlayer(Player p){
            Contract.Requires(p != null);

            Contract.Ensures(players.Count == Contract.OldValue((players.Count) + 1));
        }

        //BUFFER

        public void addLineToBuffer(List<String> buffer, String message)
        {
            Contract.Requires(buffer.Count>=0);
            Contract.Requires(message!=null);

            Contract.Ensures(buffer.Contains(message));
            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) + 1));
        }

        public void getLineFromBuffer(List<String> buffer)
        {
            Contract.Requires(buffer.Count>0);

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count)-1));
        }

        public Boolean bufferContent(List<String> buffer)
        {
            Contract.Requires(buffer.Count >= 0);

            Contract.Ensures(isEmpty == true);
            return default(Boolean);
        }

        //BACKEND

        public void sendCommandToConnector(String command){
            Contract.Requires(command!=null); 
            
            //Hier wird sendMessageToServer  in Connector aufgerufen
            
        }

        public void storePlayer(Player p){
            Contract.Requires(p!=null);     

            Contract.Ensures(players.Contains(p)); 
            
        }

         public void deletePlayer(Player p){
            Contract.Requires(p!=null);    

            Contract.Ensures(!players.Contains(p)); 
            
        }

         public void storeDragon(Dragon d){
            Contract.Requires(d!=null);     

            Contract.Ensures(dragons.Contains(d)); 
            
        }

        public void deleteDragon(Dragon d){
            Contract.Requires(d!=null);     

            Contract.Ensures(!dragons.Contains(d)); 
            
        }

        public void setMap(Map m){
            Contract.Requires(m!=null);     
            Contract.Requires(m.height > 0);
            Contract.Requires(m.wigth > 0);

            Contract.Ensures(m.height > 0);
            Contract.Ensures(m.wigth > 0);
        }

        

        //FRONTEND


        public void repaint(){
            Contract.Requires(mapcells != null);

            Contract.Ensures(isChanged == true);
        }
    
       public static void Main(string[] args)
        {
        }
    }

