using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project
{
    public class Entity : IPositionable
    {
        public int x, y;
        private int id;
        private String type;
        private String desc;
        private Boolean isBusy;
        
        public Entity(int id, int x, int y, String type)
        {
            setId(id);
            setXPosition(x);
            setYPosition(y);
            setType(type);
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getType()
        {
            return type;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public String getDesc()
        {
            return desc;
        }

        public void setDesc(String desc)
        {
            this.desc = desc;
        }

        public Boolean getBusy()
        {
            return isBusy;
        }

        public void setBusy(Boolean isBusy)
        {
            this.isBusy = isBusy;
        }

        public int getXPosition()
        {
            return x;
        }

        public void setXPosition(int x)
        {
            this.x = x;
        }

        public int getYPosition()
        {
            return y;
        }

        public void setYPosition(int y)
        {
            this.y = y;
        }
    }
}
