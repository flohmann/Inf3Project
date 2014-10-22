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
        private String port;
        private Boolean isConnected = false;
        private ArrayList buffer = new ArrayList();
        private ArrayList players = new ArrayList();
        private ArrayList dragons = new ArrayList();
        private ArrayList mapcells = new ArrayList();
        private ArrayList challenges = new ArrayList();

        // CONNECTOR 

        public Boolean connect(String ip, String port){
            Contract.Requires(port != null || port == "666");
            Contract.Requires(ip != null);    

            Contract.Ensures(isConnected == true);
            return isConnected;
        }



        public void pushMessageIntoBuffer(ArrayList buffer, String message){
            Contract.Requires(buffer.Count >= 0);
            Contract.Requires(message != null);
            

            Contract.Ensures(buffer.Contains(message));
            Contract.Ensures(buffer.Count > 0);

        }

       public void sendMessageToServer(String message){
           Contract.Requires(message != null);

           Contract.Ensures(message=="INVALID");   // noch nicht fertig!!
       }     


        // PARSER

        public void readBuffer(ArrayList buffer){
            Contract.Requires(buffer.Count>0);

            Contract.Ensures(buffer.Count==0);
        }




        //BUFFER

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

         public void deletPlayer(String p){
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
    
       public static void Main(string[] args)
        {
        }
    }

