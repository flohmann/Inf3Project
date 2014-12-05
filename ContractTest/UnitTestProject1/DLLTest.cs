using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace UnitTestProject1
{
    class DLLTest
    {
        [DllImport("Dijkstra_Pathfinding_Algorithm")]
        public static extern IntPtr findPath(int from, int to, int[] map, int mapw, int maph, int pathlength);

        static void Main(string[] args)
        {
            int[] map = { 0, 1, 1, 0, 1 };
            findPath(0,9,map,5,5,9);
        }
    }
}
