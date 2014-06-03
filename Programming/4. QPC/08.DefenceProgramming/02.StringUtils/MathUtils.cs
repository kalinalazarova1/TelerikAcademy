namespace _02.Utils
{
    using System;

    public static class MathUtils
    {
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                throw new ArithmeticException("Only natural numbers greater than 1 could be checked!");
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
