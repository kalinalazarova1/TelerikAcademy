namespace Methods
{
    using System;

    /// <summary>
    /// Tests the other classes in this project.
    /// </summary>
    internal static class Test
    {
        /// <summary>
        /// Tests the class SegmentUtils.
        /// </summary>
        private static void SegmentUtilsTest()
        {
            Console.WriteLine(SegmentUtils.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(SegmentUtils.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + SegmentUtils.IsHorizontal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + SegmentUtils.IsVertical(3, -1, 3, 2.5));
        }

        /// <summary>
        /// Tests the class NumberUtils.
        /// </summary>
        private static void NumerUtilsTest()
        {
            Console.WriteLine(NumberUtils.NumberToDigit(5));          

            NumberUtils.PrintFormatedNumber(1.3, "f");
            NumberUtils.PrintFormatedNumber(0.75, "%");
            NumberUtils.PrintFormatedNumber(2.30, "r");
        }

        /// <summary>
        /// Tests the class MathUtils.
        /// </summary>
        private static void MathUtilsTest()
        {
            Console.WriteLine(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));
        }

        /// <summary>
        /// Tests the class StudentUtils.
        /// </summary>
        private static void StudentTest()
        {
            Student peter = new Student("Peter", "Ivanov");
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student("Stella", "Markova");
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        /// <summary>
        /// Runs all the tests from this class.
        /// </summary>
        private static void Main()
        {
            NumerUtilsTest();
            SegmentUtilsTest();
            MathUtilsTest();
            StudentTest();
        }
    }
}
