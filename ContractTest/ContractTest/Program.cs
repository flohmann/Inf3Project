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
        private Boolean isConnected = false;
        private Boolean isEmpty = false;
        private Boolean isChanged = false;
        private ArrayList buffer = new ArrayList();
        private ArrayList players = new ArrayList();
        private ArrayList dragons = new ArrayList();
        private ArrayList mapcells = new ArrayList();
        private ArrayList challenges = new ArrayList();
       
        

        // CONNECTOR 

        public void connect(String ip, int port){
            Contract.Requires(port >= 0 && port <= 65535);
            Contract.Requires(ip != null && ip.Length > 6 && ip.Length < 16);    

         
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


        public Player EbnfRulePlayer(ArrayList buffer){
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
 
            return default(Player);
        }


        public void transferMethodPlayer(Player p){
            Contract.Requires(p != null);

            Contract.Ensures(players.Count == Contract.OldValue((players.Count) + 1));
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

