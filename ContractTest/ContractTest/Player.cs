using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    public class Player : IPositionable
    {
        private int playerId;
        private Boolean isBusy;
        private string desc;
        private int x;
        private int y;
        private int points;

        public Player(int id)
        {
            this.playerId = id;
        }

        public int getXPosition()
        {
            return x;
        }
        public int getYPosition()
        {
            return y;
        }
    
    }

}
