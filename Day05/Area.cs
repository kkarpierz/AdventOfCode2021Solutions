using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Area
    {
        List<PointOnArea> _area;
        List<Line> _lines;

        public Area(List<Line> lines)
        {
            _area = new();
            _lines = lines;
            SetUpArea();
        }

        public void SetUpArea()
        {
            foreach (var line in _lines)
            {
                List<Point> tempPointsInLine = line.GetAllPointsInTheLine();

                foreach (var point in tempPointsInLine)
                {
                    if (_area.Any(pointOnArea => pointOnArea.IsEqual(point)))
                        _area.SingleOrDefault(y => y.IsEqual(point)).Occurences++;
                    else
                        _area.Add(new PointOnArea(point));
                }
            }
        }

        // check where at least two lines crosses each other
        public int CountResult()
        {
            return _area.Where(pointsOnArea => pointsOnArea.Occurences >= 2).Count();
        }

    }
}
