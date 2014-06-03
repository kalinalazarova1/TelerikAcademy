namespace Methods
{
    using System;

    /// <summary>
    /// Provides methods for calculations with segments.
    /// </summary>
    public static class SegmentUtils
    {
        /// <summary>
        /// Checks if specified segment is horizontal.
        /// </summary>
        /// <param name="x1">X coordinate of the start of the segment.</param>
        /// <param name="y1">Y coordinate of the start of the segment.</param>
        /// <param name="x2">X coordinate of the end of the segment.</param>
        /// <param name="y2">Y coordinate of the end of the segment.</param>
        /// <returns>Returns boolean value showing whether the segment is horizontal.</returns>
        public static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            return y1 == y2;
        }

        /// <summary>
        /// Checks if specified segment is vertical.
        /// </summary>
        /// <param name="x1">X coordinate of the start of the segment.</param>
        /// <param name="y1">Y coordinate of the start of the segment.</param>
        /// <param name="x2">X coordinate of the end of the segment.</param>
        /// <param name="y2">Y coordinate of the end of the segment.</param>
        /// <returns>Returns boolean value showing whether the segment is vertical.</returns>
        public static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            return x1 == x2;
        }

        /// <summary>
        /// Calculates segment length (distance between two points).
        /// </summary>
        /// <param name="x1">X coordinate of the start of the segment.</param>
        /// <param name="y1">Y coordinate of the start of the segment.</param>
        /// <param name="x2">X coordinate of the end of the segment.</param>
        /// <param name="y2">Y coordinate of the end of the segment.</param>
        /// <returns>Returns the length of the segment as a double value.</returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        /// <summary>
        /// Calculates the area of a triangle.
        /// </summary>
        /// <param name="a">First side length as a double value.</param>
        /// <param name="b">Second side length as a double value.</param>
        /// <param name="c">Third side length as a double value.</param>
        /// <returns>Returns the area of the triangle as a double value.</returns>
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (a >= b + c || b >= a + c || c >= a + b)
            {
                throw new ArgumentException("The specified segments could not form a triangle.");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }
    }
}
