using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    public class Opponent : IPositionable
    {
        private Int32 OpponentId;
        private string desc;
        private int x;
        private int y;
        private int points;

        public Opponent(Int32 id)
        {
            
        }

        public int getXPosition(){
            return x;
        }
        public int getYPosition()
        {
            return y;
        }
    }
}