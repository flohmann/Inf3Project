using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inf3Project;
using Inf3Project.Observer;

namespace Inf3Project
{
    public class Player : Entity, IMyObservable<IPlayerObserver>
    {
        private int points;
        private Boolean busy;
        private int id;

        public Player(int id, int x, int y, String type, int points, String desc, Boolean isBusy)
            : base(id, x, y, type)
        {
            setPoints(points);
            setBusy(isBusy);
            setDesc(desc);
            setId(id);
        }
        public int getId()
        {
            return points;
        }
        public void setId(int id)
        {
            this.id = id;
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
                po.OnChangePoints(this, this.points);
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
            List<IObserver<IPlayerObserver>> pl = new List<IObserver<IPlayerObserver>>();
            return pl;
        }

        public void busyTest(bool busy)
        {
            if (busy)
            {
                foreach(IPlayerObserver po in getObservers())
                {
                    po.OnBusy(this, this.busy);
                }
            }
        }
    }
}
