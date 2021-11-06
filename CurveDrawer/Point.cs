using System;

namespace _CurveDrawer
{
    class Point : IComparable
    {
        /// <summary>
        /// x coordinate of the point
        /// </summary>
        public int x;

        /// <summary>
        /// y coordinate of the point
        /// </summary>
        public int y;

        /// <summary>
        /// Constructor of Point class
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Method used for sorting process
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Point otherPoint = obj as Point;
            if (otherPoint != null)
            {
                if (this.x < otherPoint.x)
                {
                    return 1;
                }
                else if (this.x > otherPoint.x)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }

        /// <summary>
        /// Method used for equality checking
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   x == point.x &&
                   y == point.y;
        }

        /// <summary>
        /// Overridden ToString() function to use Point p as kind of like representation of its points without any kind of effort
        /// </summary>
        /// <returns>Coordinates of the point</returns>
        public override string ToString()
        {
            return string.Format("x={0}, y={1}", x, y);
        }

        /// <summary>
        /// '-' operator overloading to get length between two points as 'a - b'
        /// </summary>
        /// <param name="a">Point a</param>
        /// <param name="b">Point b</param>
        /// <returns></returns>
        public static double operator -(Point a, Point b)
        {
            if (a != null && b != null)
                return Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
            return 0;
        }


    }
}
