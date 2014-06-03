namespace _02.Utils
{
    using System;

    internal static class UtilsTest
    {
        internal static void Main()
        {
            try
            {
                var substr = ArrayUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = ArrayUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = ArrayUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = ArrayUtils.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));

                Console.WriteLine(StringUtils.ExtractEnding("I love C#", 2));
                Console.WriteLine(StringUtils.ExtractEnding("Nakov", 4));
                Console.WriteLine(StringUtils.ExtractEnding("beer", 4));

                // Console.WriteLine(StringUtils.ExtractEnding("Hi", 100));
                int n = 23;
                Console.WriteLine("{0} is {1}prime.", n, MathUtils.IsPrime(n) ? string.Empty : "not ");
                n = 33;
                Console.WriteLine("{0} is {1}prime.", n, MathUtils.IsPrime(n) ? string.Empty : "not ");
            }
            catch (ArithmeticException are)
            {
                Console.WriteLine(are.Message);
            }
            catch (IndexOutOfRangeException iore)
            {
                Console.WriteLine(iore.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
