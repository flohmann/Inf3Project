using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inf3Project;

namespace Inf3Project.Observer
{
    public class Pathwalker : IObserver<Player>
    {
        List<MapCell> coords;
        private Backend be;
        private int xOld = 0;
        private int yOld = 0;

        public Pathwalker(Backend be)
        {
            this.be = be;
        }

        public void nextStep()
        {
            if (coords[0].getXPosition() < 0 && coords[0].getYPosition() < 0)
            {
                coords.RemoveAt(0);
            }
            else
            {
                MapCell newMC = coords[0];
                int xNew = newMC.getXPosition();
                int yNew = newMC.getYPosition();
                coords.RemoveAt(0);

                //please correct if wrong :)
                if (yNew == yOld && xNew == (xOld - 1))
                {
                    be.sendCommand("ask:mv:lft");
                }
                else if (yNew == yOld && xNew == (xOld + 1))
                {
                    be.sendCommand("ask:mv:rgt");
                }
                else if (xNew == xOld && yNew == (yOld - 1))
                {
                    be.sendCommand("ask:mv:up");
                }
                else if (xNew == xOld && yNew == (yOld + 1))
                {
                    be.sendCommand("ask:mv:dwn");
                }
                else
                {
                    //error mgt here
                }
                if (coords.Count == 0)
                {
                    xOld = -1;
                    yOld = -1;
                }
                else
                {
                    xOld = xNew;
                    yOld = yNew;
                }
                    
            }
            
        }

        public void setCoordinates(List<MapCell> newCoords)
        {
            //get actual (x,y) of myPlayer
            MapCell oldMC = be.getMyPlayerPos();
            this.xOld = oldMC.getXPosition();
            this.yOld = oldMC.getYPosition();
            this.coords = newCoords;
            coords.RemoveAt(0);
            while (coords.Count > 0)
            {
                nextStep();
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Player value)
        {
            nextStep();
        }
    }
}
