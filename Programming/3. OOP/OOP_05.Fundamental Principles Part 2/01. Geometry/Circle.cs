using System;

namespace Geometry
{
    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius, radius)
        {
        }

        public double Radius                    //for the outer world the circle has only radius and no heigth and width
        {
            get
            {
                return base.Heigth;
            }
            set
            {
                if (value > 0)
                {
                    base.Heigth = value;
                    base.Width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The radius could not be zero or negative!");
                }
            }
        }

        public override double CalculateSurface()
        {
            return base.Heigth * base.Width * Math.PI;
        }

        public override string ToString()
        {
            return string.Format("{0}\tRadius: {1}", this.GetType().Name, this.Width);
        }
    }
}
