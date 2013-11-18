using System;

namespace Geometry
{
    public class Rectangle : Shape
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

        public Rectangle(double heigth, double width)
            : base(heigth, width)
        {
        }

        public override double CalculateSurface()
        {
            return base.Heigth * base.Width;
        }
    }
}
