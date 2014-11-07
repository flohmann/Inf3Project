using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    public class Opponent
    {
        private Int32 opponentId;
        private String desc;
        private int points;

        public Opponent(Int32 id, String desc, int points)
        {
            this.opponentId = id;
            this.desc = desc;
            this.points = points;
        }

        public Int32 getID()
        {
            return opponentId;
        }

        public Int32 getPoints()
        {
            return points;
        }

        public String getDesc()
        {
            return desc;
        }
       
    
    }
}