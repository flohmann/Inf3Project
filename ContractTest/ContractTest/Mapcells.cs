using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContractTest
{
    class Mapcells
    {
        private int row;      
        private int column;




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
