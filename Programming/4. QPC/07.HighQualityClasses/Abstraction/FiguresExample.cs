namespace FigureCalculation
{
    // 1.Take the VS solution "Abstraction" and refactor its code to provide good abstraction.
    // Move the properties and methods from the class Figure to their correct place. Move the 
    // common methods to the base class's interface. Remove all duplicated code (properties / methods / other code).
    // 2. Establish good encapsulation in the classes from the VS solution "Abstraction". Ensure that incorrect values
    // cannot be assigned in the internal state of the classes.
    using System;

    /// <summary>
    /// Tests the classes in the FigureCalculation namespace.
    /// </summary>
    internal static class FiguresExample
    {
        /// <summary>
        /// Runs the tests of the classes in the FigureCalculation namespace.
        /// </summary>
        private static void Main()
        {
            var figures = new IFigure[2];
            Circle circle = new Circle(5);
            figures[0] = circle;
            Rectangle rect = new Rectangle(2, 3);
            figures[1] = rect;

            foreach (var figure in figures)
            {
                Console.WriteLine(
                    "I am a {0}. My perimeter is {1:f2}. My surface is {2:f2}.",
                    figure.GetType().Name.ToLower(),
                    figure.CalcPerimeter(), 
                    figure.CalcSurface());
            }
        }
    }
}
