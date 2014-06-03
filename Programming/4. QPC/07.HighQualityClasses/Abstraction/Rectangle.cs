namespace FigureCalculation
{
    using System;

    /// <summary>
    /// Creates the figure rectangle with height and width.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public Rectangle(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("The width must be positive!", "width");
            }

            this.Width = width;

            if (height <= 0)
            {
                throw new ArgumentException("The height must be positive!", "height");
            }

            this.Height = height;
        }

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        /// <value>Width of the rectangle must be positive.</value>
        public virtual double Width { get; private set; }

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        /// <value>Height of the rectangle must be positive.</value>
        public virtual double Height { get; private set; }

        /// <summary>
        /// Calculates the perimeter of a rectangle.
        /// </summary>
        /// <returns>The perimeter of a rectangle.</returns>
        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        /// <summary>
        /// Calculates the surface of a rectangle.
        /// </summary>
        /// <returns>The surface of a rectangle.</returns>
        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
