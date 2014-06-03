namespace FigureCalculation
{
    /// <summary>
    /// States the methods which figures have to implement.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Calculates the surface of a figure.
        /// </summary>
        /// <returns>The surface of the figure.</returns>
        double CalcSurface();

        /// <summary>
        /// Calculates the perimeter of a figure.
        /// </summary>
        /// <returns>The perimeter of a figure.</returns>
        double CalcPerimeter();
    }
}
