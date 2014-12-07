using Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inf3Project
{
    public class Map
    {
        public MapCell[][] cells;
        public int width;
        public int height;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new MapCell[width][];
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new MapCell[this.height];
            }
        }

        public void addCell(MapCell cell)
        {
            cells[cell.getXPosition()][cell.getYPosition()] = cell;
        }
    }
}
