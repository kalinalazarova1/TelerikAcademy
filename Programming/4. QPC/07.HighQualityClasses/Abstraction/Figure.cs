namespace FigureCalculation
{
    using System;

    /// <summary>
    /// Abstract class for all figures and defines the methods every figure should implement.
    /// No constructor, because there are no fields for initialization.
    /// </summary>
    public abstract class Figure : IFigure
    {
        /// <summary>
        /// Calculates the surface of a figure.
        /// </summary>
        /// <returns>The surface of the figure.</returns>
        public abstract double CalcSurface();

        /// <summary>
        /// Calculates the perimeter of a figure.
        /// </summary>
        /// <returns>The perimeter of a figure.</returns>
        public abstract double CalcPerimeter();
    }
}
