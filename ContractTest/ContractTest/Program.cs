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


        // CONNECTOR 

        public Boolean Connect(String ip, String port){
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

        //FRONTEND
    
       public static void Main(string[] args)
        {
        }
    }
}
