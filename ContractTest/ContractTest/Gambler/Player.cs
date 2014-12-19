using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frontend;
using Inf3Project.Observer;

namespace Inf3Project
{
    public class Player : Entity
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
    }
}
