using System;
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
        private String ip;
        private int port;
        private Boolean isConnected = false;
        private Boolean isEmpty = false;
        private ArrayList buffer = new ArrayList();
        private ArrayList players = new ArrayList();
        private ArrayList dragons = new ArrayList();
        private ArrayList mapcells = new ArrayList();
        private ArrayList challenges = new ArrayList();

        // CONNECTOR 

        public void connect(String ip, int port){
            Contract.Requires(port >= 0 && port <= 65535);
            Contract.Requires(ip != null && ip.Length > 6 && ip.Length < 16);    

            Contract.Ensures(isConnected == true);
        }



        public void pushMessageIntoBuffer(ArrayList buffer, String message){
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

        public void readBuffer(ArrayList buffer){
            Contract.Requires(buffer.Count>0);

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) - 1));
        }


        public void playerkey(String keyword){
            Contract.Requires(keyword == "PLAYER");


        }


        public void transferMethod(){

        }

        //BUFFER

        public void addLineToBuffer(ArrayList buffer, String message){
            Contract.Requires(buffer.Count>=0);
            Contract.Requires(message!=null);

            Contract.Ensures(buffer.Contains(message));
            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count) + 1));
        }

        public void getLineFromBuffer(ArrayList buffer){
            Contract.Requires(buffer.Count>0);

            Contract.Ensures(buffer.Count == Contract.OldValue((buffer.Count)-1));
        }

        public Boolean bufferContent(ArrayList buffer){
            Contract.Requires(buffer.Count >= 0);

            Contract.Ensures(isEmpty == true);
            return default(Boolean);
        }

        //BACKEND

        public void sendCommandToConnector(String command){
            Contract.Requires(command!=null); 
            //Hier wird sendMessageToServer  in Connector aufgerufen
            // Es gibt kein Postcondition. 
        }

        public void storePlayer(Player p){
            Contract.Requires(p!=null);     //Precondition

            Contract.Ensures(players.Contains(p)); //Postcondition
            
        }

         public void deletePlayer(Player p){
            Contract.Requires(p!=null);     //Precondition

            Contract.Ensures(!players.Contains(p)); //Postcondition
            
        }

         public void storeDragon(String d){
            Contract.Requires(d!=null);     //Precondition

            Contract.Ensures(dragons.Contains(d)); //Postcondition
            
        }

        public void deleteDragon(String d){
            Contract.Requires(d!=null);     //Precondition

            Contract.Ensures(!dragons.Contains(d)); //Postcondition
            
        }

        public void setMap(String [][] m){
            Contract.Requires(m!=null);     //Precondition

            Contract.Ensures(mapcells.Contains(m)); //Postcondition Nicht fertig !!!
            
        }

        public void storeChallenge(String c){
            Contract.Requires(c!=null);     //Precondition

            Contract.Ensures(challenges.Contains(c)); //Postcondition
            
        }

        //Unit-Test

        public void sendCommandToConnectorTest(String command){


        }

        //FRONTEND


        public void repaint(){

        }
    
       public static void Main(string[] args)
        {
        }
    }

