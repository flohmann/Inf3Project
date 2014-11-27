using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project
{
    public class Map
    {
        private Mapcells[][] cells;
        public int width;
        public int height;


        public Map(int width, int height, Mapcells [][] cells)
        {
           cells = new Mapcells[width][];
        }
        public int Width{
            get { return this.width; }
            set{this.width = value;}
    }

        public int Height
        {
            get { return this.height;}
            set { this.height = value;}
        }
}
}
