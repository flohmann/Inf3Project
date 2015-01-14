using Inf3Project;
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
        public MapCell cell;
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

        public MapCell[][] getCells()
        {
            return cells;
        }

        public MapCell getCell(int x, int y)
        {
            List<MapCellAttribute> attributes = new List<MapCellAttribute>();
            MapCell mp = new MapCell(-1,-1, attributes);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (cells[i][j].getXPosition() == x && cells[i][j].getYPosition() == y)
                    {
                        mp = cells[i][j];
                    }
                }
            }
            return mp;
        }
    }
}
