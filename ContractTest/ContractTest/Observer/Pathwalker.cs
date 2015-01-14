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

        public void nextStep()
        {

        }

        public void setCoordinates(List<MapCell> newCoords)
        {
            this.coords = newCoords;
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
