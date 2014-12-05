using Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inf3Project.Game
{
    public class Pathfinder : IPathfinder
    {
        private int[] pathMapCell;
        private bool pathEnd = false;
        private int nextMove = 0;
        private Backend ba;

        public void stop()
        {
            pathEnd = true;
        }

        public bool isWalking()
        {
            return pathEnd;
        }

        public bool nextStep()
        {
            if (pathMapCell[nextMove] == 1)
            {
                ba.sendCommand("ask:mv:up");
            }
            else if (pathMapCell[nextMove] == 2)
            {
                ba.sendCommand("ask:mv:rgt");
            }
            else if (pathMapCell[nextMove] == 3)
            {
                ba.sendCommand("ask:mv:dwn");
            }
            else if (pathMapCell[nextMove] == 4)
            {
                ba.sendCommand("ask:mv:lft");
            }
            else if (pathMapCell[nextMove] == 0)
            {
                //Nachdem alle Schritte abgelaufen sind, wird pathEnd auf false gesetzt.
                return false;
            }
            nextMove++;
            return true;
        }

        public void setCoords(int[] coordinates)
        {
            nextMove = 0;
            pathMapCell = coordinates;
        }
    }
}