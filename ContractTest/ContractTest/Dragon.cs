using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;

namespace Inf3Project
{
    public class Dragon : IPositionable
    {
        private int dragonId;
        private Dragon type;
        private Boolean isBusy;
        private String desc;
        private int x;
        private int y;

        public Dragon(int id){
          
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
