namespace Utils
{
    // 3.Take the VS solution "Cohesion-and-Coupling" and refactor its code to follow the principles of good abstraction,
    // loose coupling and strong cohesion. Split the class Utils to other classes that have strong cohesion and are loosely
    // coupled internally.
    using System;

    /// <summary>
    /// Tests the classes <see cref="FileUtils"/> class, <see cref="GeometryUtils"/> class and <see cref="Parallelepiped"/> class.
    /// </summary>
    internal class UtilsTests
    {
        /// <summary>
        /// Tests <see cref="FileUtils"/> class.
        /// </summary>
        private static void FileUtilsTest()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));
        }

        /// <summary>
        /// Tests <see cref="GeometryUtils"/> class.
        /// </summary>
        private static void GeometryUtilsTest()
        {
            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));
        }

        /// <summary>
        /// Tests <see cref="Parallelepiped"/> class.
        /// </summary>
        private static void ParallelepipedTest()
        {
            var parallelpiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", parallelpiped.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", parallelpiped.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", parallelpiped.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", parallelpiped.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", parallelpiped.CalcDiagonalYZ());
        }

        /// <summary>
        /// Runs all the test together.
        /// </summary>
        private static void Main()
        {
            FileUtilsTest();
            GeometryUtilsTest();
            ParallelepipedTest();
        }
    }
}
