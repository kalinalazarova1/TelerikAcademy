namespace Utils
{
    using System;

    /// <summary>
    /// Creates an object representing a parallelepiped with width, height and depth.
    /// </summary>
    public class Parallelepiped
    {
        /// <summary>
        /// Initializes an instance of the <see cref="Parallelepiped"/> class.
        /// </summary>
        /// <param name="width">Double value representing the width of the parallelepiped.</param>
        /// <param name="height">Double value representing the height of the parallelepiped.</param>
        /// <param name="depth">Double value representing the depth of the parallelepiped.</param>
        public Parallelepiped(double width, double height, double depth)
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

            if (depth <= 0)
            {
                throw new ArgumentException("The depth must be positive!", "depth");
            }

            this.Depth = depth;
        }

        /// <summary>
        /// Sets or gets the width of the parallelepiped.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Sets or gets the height of the parallelepiped.
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Sets or gets the depth of the parallelepiped.
        /// </summary>
        public double Depth { get; private set; }

        public double CalcVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        /// <summary>
        /// Calculates a XYZ diagonal of a parallelepiped.
        /// </summary>
        /// <returns>Double value representing the diagonal.</returns>
        public double CalcDiagonalXYZ()
        {
            double distance = GeometryUtils.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        /// <summary>
        /// Calculates a XY diagonal of a parallelepiped.
        /// </summary>
        /// <returns>Double value representing the diagonal.</returns>
        public double CalcDiagonalXY()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        /// <summary>
        /// Calculates a XZ diagonal of a parallelepiped.
        /// </summary>
        /// <returns>Double value representing the diagonal.</returns>
        public double CalcDiagonalXZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        /// <summary>
        /// Calculates a YZ diagonal of a parallelepiped.
        /// </summary>
        /// <returns>Double value representing the diagonal.</returns>
        public double CalcDiagonalYZ()
        {
            double distance = GeometryUtils.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}
