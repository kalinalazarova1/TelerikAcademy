using System;

namespace ThreeDimensionalSpace
{
    public struct Point3D
    {
        private double x;
        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (this.x == null)
                {
                    throw new ArgumentNullException("The coordinate X of the 3D Point must be different from null!");
                }
                else
                {
                    this.x = value;
                }
            }
        }

        private double y;
        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (this.y == null)
                {
                    throw new ArgumentNullException("The coordinate Y of the 3D Point must be different from null!");
                }
                else
                {
                    this.y = value;
                }
            }
        }

        private double z;
        public double Z
        {
            get
            {
                return this.z;
            }
            set
            {
                if (this.z == null)
                {
                    throw new ArgumentNullException("The coordinate Z of the 3D Point must be different from null!");
                }
                else
                {
                    this.z = value;
                }
            }
        }

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return string.Format("Point{{{0},{1},{2}}}", this.X, this.Y, this.Z);
        }

        private static readonly Point3D _PointZero = new Point3D(0,0,0);

        public static Point3D PointZero 
        {
            get
            {
                return _PointZero;
            }
        }
    }
}
