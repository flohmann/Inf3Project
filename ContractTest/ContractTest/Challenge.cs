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
        private int challengeId;
        private Boolean isAccepted;
        private Opponent opponent;
        private Player playerId;
        private Opponent opponentId;
        
        public Challenge( int challengeId, Player playerId, Opponent opponentId){
            this.challengeId = challengeId;
            this.playerId = playerId;
            this.opponentId = opponentId;
        }

        
    }
}
