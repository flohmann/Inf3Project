using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inf3Project
{

    public class Mapcells
    {
        private int row;      
        private int column;
        private bool walkable;
        private bool huntable;
        private bool forest;
        private bool water;
        private bool wall;


        public Mapcells(int row, int column, bool walkable, bool huntable, bool forest, bool water, bool wall)
        {
            this.row = row;
            this.column = column;
            this.walkable = walkable;
            this.huntable = huntable;
            this.forest = forest;
            this.water = water;
            this.wall = wall;
        }
        
        public int Row
        {
            get { return this.row; }
            set { this.row = value; }
        }

        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        }

    }
}
