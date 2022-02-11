using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Line
    {
        private Point _startPoint;
        private Point _endPoint;

        public Line(Point startPoint, Point endPoint)
        {
            _startPoint = startPoint;
            _endPoint = endPoint;
        }

        public List<Point> GetAllPointsInTheLine()
        {
            List<Point> points = new();

            // horizontal line
            if (_startPoint.X == _endPoint.X)
            {
                int minYPoint = _endPoint.Y < _startPoint.Y ? _endPoint.Y : _startPoint.Y;
                int maxYPoint = _endPoint.Y > _startPoint.Y ? _endPoint.Y : _startPoint.Y;
                int x = _startPoint.X;
                List<int> yValuesInTheLine = FindNumbersBetweenTwo(minYPoint, maxYPoint);

                foreach(var tempY in yValuesInTheLine)
                {
                    points.Add(new Point(x, tempY));
                }
            }
            // vertical line
            else if (_startPoint.Y == _endPoint.Y)
            {
                int minXPoint = _endPoint.X < _startPoint.X ? _endPoint.X : _startPoint.X;
                int maxXPoint = _endPoint.X > _startPoint.X ? _endPoint.X : _startPoint.X;
                int y = _startPoint.Y;
                List<int> xValuesInTheLine = FindNumbersBetweenTwo(minXPoint, maxXPoint);

                foreach(var tempX in xValuesInTheLine)
                {
                    points.Add(new Point(tempX, y));
                }
            }
            // diagonal line
            else if (Math.Abs(_startPoint.X - _endPoint.X) == Math.Abs(_startPoint.Y - _endPoint.Y))
            {
                int minXPoint = _endPoint.X < _startPoint.X ? _endPoint.X : _startPoint.X;
                int maxXPoint = _endPoint.X > _startPoint.X ? _endPoint.X : _startPoint.X;
                List<int> xValuesInTheLine = FindNumbersBetweenTwo(minXPoint, maxXPoint);

                Point pointWithMinX = new(minXPoint, _startPoint.X == minXPoint ? _startPoint.Y : _endPoint.Y);
                Point pointWithMaxX = new(maxXPoint, _startPoint.X == maxXPoint ? _startPoint.Y : _endPoint.Y);

                int tempY = pointWithMinX.Y;

                if (pointWithMaxX.Y > pointWithMinX.Y)
                {
                    foreach (var tempX in xValuesInTheLine)
                    {
                        points.Add(new Point(tempX, tempY));
                        ++tempY;
                    }
                }
                else
                {
                    foreach (var tempX in xValuesInTheLine)
                    {
                        points.Add(new Point(tempX, tempY));
                        --tempY;
                    }
                }
            }


            // on whole this method there is potential to make it faster, it takes very long iterating here, good to check why

            return points;
        }

        private List<int> FindNumbersBetweenTwo(int min, int max)
        {
            return Enumerable.Range(min, max - min + 1).ToList(); // second argument of Range is count so put here counted amount of numbers
        }

    }
}
