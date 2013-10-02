using System;

namespace ThreeDimensionalSpace
{
    static public class Distance3D
    {
        static public double CalcDistance3D(Point3D first, Point3D second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2) + Math.Pow(first.Z - second.Z, 2));
        }
    }
}
