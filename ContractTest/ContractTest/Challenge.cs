using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Inf3Project
{
    class Challenge
    {
        
        private Boolean isAccepted;
        private Opponent opponentId;
        private String type;

        //instead Opponent just int id ?? 
        
        public Challenge(Opponent opponent, Boolean isAccepted, String type){
            this.opponentId = opponent;
            this.isAccepted = isAccepted;
            this.type = type;
        }

        public Opponent OpponentId
        {
            get { return this.opponentId; }
            set { this.opponentId= value; }
        }

        public String Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public bool Accepted
        {
            get { return this.isAccepted; }
            set { this.isAccepted = value; }
        }
    }
}
