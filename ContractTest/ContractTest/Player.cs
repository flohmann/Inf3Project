using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    class Player : IPositionable
    {
        private Int32 playerId;
        private Boolean isBusy;
        private string desc;
        private int x;
        private int y;
        private int points;

        public Player(Int32 id)
        {
            this.playerId = id;
        }
       
        //public Player playerId { get; set; }
    
    }

}
