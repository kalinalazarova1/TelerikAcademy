namespace _01.BinaryPasswords
{
    using System;
    using System.Numerics;

    internal class BinaryPasswords
    {
        internal static void Main()
        {
            BigInteger result = 1;
            var input = Console.ReadLine().ToCharArray();
            Array.Sort(input);
            for (int i = 0; i < Array.LastIndexOf(input, '*') + 1; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }
    }
}
