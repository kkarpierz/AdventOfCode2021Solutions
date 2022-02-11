using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Point
    {
        private int _x;
        private int _y;

        public int X { get => _x; }
        public int Y { get => _y; }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Point(Point point)
        {
            _x = point.X;
            _y = point.Y;
        }

        public bool IsEqual(Point point)
        {
            return (_x == point.X) && (_y == point.Y);
        }

    }
}
