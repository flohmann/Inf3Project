using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project
{
    public class Map
    {
        public int width;
        public int height;

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
