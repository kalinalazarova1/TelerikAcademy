// 2. You are given 3 points A, B and C, forming triangle, and a point P. Check if the point P is in the triangle or not.
namespace _02.PointInTriangle
{
    using System;

    internal class PointInTriangle
    {
        internal static void Main()
        {
            var p = new Point(1, 0.9);
            var a = new Point(2, 0);
            var b = new Point(0, 1);
            var c = new Point(1, 1);
            Console.WriteLine("The point P({0}, {1}) is in the triangle: {2}", p.X, p.Y, IsPointInTriangle(p, a, b, c));
        }

        private static bool IsPointInTriangle(Point p, Point a, Point b, Point c)
        {
            var s = (a.Y * c.X) - (a.X * c.Y) + ((c.Y - a.Y) * p.X) + ((a.X - c.X) * p.Y);
            var t = (a.X * b.Y) - (a.Y * b.X) + ((a.Y - b.Y) * p.X) + ((b.X - a.X) * p.Y);

            if ((s < 0) != (t < 0))
            {
                return false;
            }

            var area = -(b.Y * c.X) + (a.Y * (c.X - b.X)) + (a.X * (b.Y - c.Y)) + (b.X * c.Y);
            if (area < 0.0)
            {
                s = -s;
                t = -t;
                area = -area;
            }

            return s > 0 && t > 0 && (s + t) < area;
        }
    }
}
