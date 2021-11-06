using System;
using System.Collections.Generic;

namespace _CurveDrawer
{
    class Curve : ICloneable
    {
        /// <summary>
        /// List data structure to store points of the curve
        /// </summary>
        IList<Point> points = new List<Point>();

        /// <summary>
        /// Distance between given two points
        /// </summary>
        public double Length(Point p1, Point p2)
        {
            return p1 - p2;
        }


        /// <summary>
        /// Method does print the whole points of the curve
        /// </summary>
        public void PrintPoints()
        {
            Console.WriteLine("Points in the curve:");
            foreach (Point p in points)
            {
                Console.Write("[{0}]", p);
            }
            Console.Write("\n");
        }

        /// <summary>
        /// Removes the given point from the curve
        /// </summary>
        /// <param name="p">Point that wanted to be removed</param>
        public void RemovePoint(Point p)
        {
            if (points.Contains(p))
            {
                points.Remove(p);
                Console.WriteLine("Point {0} has been removed from the curve", p);
            }
            else
            {
                Console.WriteLine("There is not such point as {0} stored in the curve", p);
            }
        }

        /// <summary>
        /// Method used for remove the last added point into the curve
        /// </summary>
        /// <returns></returns>
        public Point RemoveLastPoint()
        {
            if (points.Count > 0)
            {
                Point lastPoint = points[points.Count - 1];
                points.Remove(lastPoint);
                return lastPoint;
            }

            return new Point(-1, -1);
        }

        /// <summary>
        /// Adds the given point into the curve
        /// </summary>
        /// <param name="p">Point that wanted to be added</param>
        public int AddPoint(Point p)
        {
            if (!points.Contains(p))
            {
                foreach (Point temp in points)
                {
                    if (temp.x == p.x) return -2;
                }
                points.Add(p);
                return 1;
            } else
            {
                return -1;
            }
                
            Console.WriteLine("Point {0} has been added to the curve", p);
        }

        /// <summary>
        /// Method used for get points of the curve
        /// </summary>
        /// <returns></returns>
        public IList<Point> GetPoints()
        {
            List<Point> copyPoints = new List<Point>();
            foreach (Point p in points)
            {
                Point copyPoint = new Point(p.x, p.y);
                copyPoints.Add(copyPoint);
            }
            return copyPoints;
        }

        /// <summary>
        /// Method used for get sorted points of the curve
        /// </summary>
        /// <returns></returns>
        public List<Point> Sort()
        {
            List<Point> copyPoints = new List<Point>();
            foreach (Point p in points)
            {
                Point copyPoint = new Point(p.x, p.y);
                copyPoints.Add(copyPoint);
            }
            copyPoints.Sort();
            return copyPoints;
        }

        /// <summary>
        /// Shallow clones the curve
        /// </summary>
        /// <returns>Object that can be parsed into Curve</returns>
        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Deep clones the curve
        /// </summary>
        /// <returns>Object that can be parsed into Curve</returns>
        public object Clone()
        {
            Curve copy = new Curve();

            foreach (Point p in points)
            {
                Point copyPoint = new Point(p.x, p.y);
                copy.AddPoint(copyPoint);
            }

            return copy;
        }

        /// <summary>
        /// Calculates curve length of the curve
        /// </summary>
        /// <returns>Curve length</returns>
        public double CurveLength()
        {
            List<Point> sortedPoints = Sort();
            double totalLength = 0;
            for (int i = 0; i < sortedPoints.Count; i++)
            {
                if (i != sortedPoints.Count - 1)
                {
                    totalLength += Length(sortedPoints[i], sortedPoints[i + 1]);
                }
            }

            return totalLength;
        }

        /// <summary>
        /// Greater than operator overloading to use greater than operator directly
        /// </summary>
        /// <param name="a">First curve</param>
        /// <param name="b">Second curve</param>
        /// <returns></returns>
        public static bool operator >(Curve a, Curve b)
        {
            return a.CurveLength() > b.CurveLength();
        }

        /// <summary>
        /// Lesser than operator overloading to use lesser than operator directly
        /// </summary>
        /// <param name="a">First curve</param>
        /// <param name="b">Second curve</param>
        /// <returns></returns>
        public static bool operator <(Curve a, Curve b)
        {
            return a.CurveLength() < b.CurveLength();
        }
    }
}
