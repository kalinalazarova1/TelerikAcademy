namespace FigureCalculation
{
    using System;

    /// <summary>
    /// Creates the figure circle with radius.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be positive!", "radius");
            }

            this.Radius = radius;
        }

        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        /// <value>Value representing a radius of a circle and have to be greater than zero.</value>
        public double Radius { get; private set; }

        /// <summary>
        /// Calculates the perimeter of a circle.
        /// </summary>
        /// <returns>The perimeter of a circle.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of a circle.
        /// </summary>
        /// <returns>The surface of a circle.</returns>
        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
