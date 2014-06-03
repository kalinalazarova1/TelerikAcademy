namespace Methods
{
    using System;

    /// <summary>
    /// Provides methods for mathematical calculations.
    /// </summary>
    public static class MathUtils
    {
        /// <summary>
        /// Finds the max value from a given sequence of integers.
        /// </summary>
        /// <param name="elements">Gets optional count of integers.</param>
        /// <returns>Returns maximal integer value.</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Please, specify at least one element!");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }

            return elements[0];
        }
    }
}
