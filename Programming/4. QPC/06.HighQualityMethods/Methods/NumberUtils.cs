namespace Methods
{
    using System;

    /// <summary>
    /// Provides methods for formatting numbers.
    /// </summary>
    public static class NumberUtils
    {
        /// <summary>
        /// Converts a digit to its english equivalent.
        /// </summary>
        /// <param name="number">Digit to be converted, must be between 0 and 9.</param>
        /// <returns>String representing the english equivalent of a digit.</returns>
        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid input number!");
            }
        }

        /// <summary>
        /// Prints the number on the console in the specified format.
        /// </summary>
        /// <param name="number">Number which have to be printed in specified format.</param>
        /// <param name="format">String which describes how a number should be formatted. Could be "f","%" or "r".</param>
        public static void PrintFormatedNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }
    }
}
