using System;

namespace Geometry
{
    public abstract class Shape
    {
        private double width;
        private double heigth;

        protected virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The width could not be zero or negative!");
                }
            }
        }

        protected virtual double Heigth
        {
            get
            {
                return this.heigth;
            }
            set
            {
                if (value > 0)
                {
                    this.heigth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The heigth could not be zero or negative!");
                }
            }
        }

        protected Shape(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        abstract public double CalculateSurface();

        public override string ToString()
        {
            return string.Format("{0}\tWidth: {1},\tHeigth: {2}", this.GetType().Name, this.Width, this.Heigth);
        }
    }
}
