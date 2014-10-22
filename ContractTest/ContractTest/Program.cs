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
        private Boolean connect = false;
        private ArrayList buffer = new ArrayList();
        private ArrayList players = new ArrayList();
        private ArrayList dragons = new ArrayList();
      
        // CONNECTOR 

        public Boolean isConnect(String ip, String port){
            Contract.Requires(port != null || port == "666");
            Contract.Requires(ip != null);    

            Contract.Ensures(connect = true);
            return connect;
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

         public void deletPlayer(Player p){
            Contract.Requires(p!=null);     //Precondition

            Contract.Ensures(!players.Contains(p)); //Postcondition
            
        }

         public void storeDragon(Dragon d){
            Contract.Requires(d!=null);     //Precondition

            Contract.Ensures(dragons.Contains(d)); //Postcondition
            
        }

        public void deleteDragon(Dragon d){
            Contract.Requires(d!=null);     //Precondition

            Contract.Ensures(!dragons.Contains(d)); //Postcondition
            
        }

        public void setMap(Mapcell [][] m){
            Contract.Requires(m!=null);     //Precondition

            Contract.Ensures(mapcells.Contains(m)); //Postcondition Nicht fertig !!!
            
        }

        public void storeChallenge(Challenge c){
            Contract.Requires(c!=null);     //Precondition

            Contract.Ensures(challenges.Contains(c)); //Postcondition
            
        }

        //FRONTEND
    
       public static void Main(string[] args)
        {
        }
    }
}
