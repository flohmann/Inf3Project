using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project.Game
{
     interface IPathfinder
    {
        // stops current path-walking-process
        void stop();

        // stops current path-walking-process
        bool isWalking();

        // pops next command from list of commands and sends to server
        bool nextStep();

        // interpret coordinates to traverse a path
        void setCoords(int[] coordinates);
    }
}


