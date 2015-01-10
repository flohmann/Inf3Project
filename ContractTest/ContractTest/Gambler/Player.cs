using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;
using Inf3Project.Observer;

namespace Inf3Project
{
    public class Player : Entity, IMyObservable<IPlayerObserver>
    {
        private int points;

        public Player(int id, int x, int y, String type, int points, String desc, Boolean isBusy)
            : base(id, x, y, type)
        {
            setPoints(points);
            setBusy(isBusy);
            setDesc(desc);
        }

        public int getPoints()
        {
            return points;
        }
        public void setPoints(int points)
        {
            this.points = points;
        }

        public void addPoint(int amount)
        {
        if(amount !=0){
            this.points += amount;
            foreach(IPlayerObserver po in getObservers()){

            }
        }
        }

        public void positionChange(int i, int j)
        {
            if (this != null)
            {
                this.x = i;
                this.y = j;
                foreach (IPlayerObserver po in getObservers())
                {
                    po.OnChangePosition(this, this.x, this.y);
                }
            }
        }

        List<IObserver<IPlayerObserver>> getObservers()
        {
            return null;
        }
    }
}
