using System;

namespace Geometry
{
    public class Triangle : Shape
    {
        public double Heigth
        {
            get
            {
                return base.Heigth;
            }
            set
            {
                base.Heigth = value;
            }
        }

        public double Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
            }
        }

        public Triangle(double heigth, double width)
            : base(heigth, width)
        {
        }

        public override double CalculateSurface()
        {
            return (base.Heigth * base.Width) / 2;
        }
    }
}
