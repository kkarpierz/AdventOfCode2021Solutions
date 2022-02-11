using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class PointOnArea : Point
    {
        private int _occurences;

        public PointOnArea(int x, int y) : base(x, y)
        {
            _occurences = 1;
        }

        public PointOnArea(Point point) : base(point)
        {
            _occurences = 1;
        } 

        public int Occurences { get => _occurences; set => _occurences = value; }
    }
}
