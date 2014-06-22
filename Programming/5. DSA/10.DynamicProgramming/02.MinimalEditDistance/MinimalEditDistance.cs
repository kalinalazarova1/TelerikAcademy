// 2.Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y) is the minimal sum of costs of edit
// operations used to transform x to y. Sample costs are given below:
// cost (replace a letter) = 1
// cost (delete a letter) = 0.9
// cost (insert a letter) = 0.8
// Example: x = "developer", y = "enveloped" -> cost = 2.7 
// delete ‘d’:  "developer" -> "eveloper", cost = 0.9
// insert ‘n’:  "eveloper" -> "enveloper", cost = 0.8
// replace ‘r’ -> ‘d’:  "enveloper" -> "enveloped", cost = 1
namespace _02.MinimalEditDistance
{
    using System;

    internal static class MinimalEditDistance
    {
        private static double replaceWeight = 1;

        private static double deleteWeight = 0.9;

        private static double insertWeight = 0.8;

        internal static void Main()
        {
            Console.WriteLine("The total weight is: {0}", GetTotalWeight("developer", "enveloped"));
        }

        private static string GetMaxEqualSequence(string source, string result)
        {
            for (int i = source.Length; i >= 1; i--)
            {
                for (int j = 0; j <= source.Length - i; j++)
                {
                    var current = source.Substring(j, i);
                    if (result.IndexOf(current) > -1)
                    {
                        return current;
                    }
                }
            }

            return string.Empty;
        }

        private static double GetTotalWeight(string source, string result)
        {
            var common = GetMaxEqualSequence(source, result);
            if (common == string.Empty)
            {
                if (source.Length < result.Length)
                {
                    return (source.Length * replaceWeight) + ((result.Length - source.Length) * insertWeight);
                }
                else
                {
                    return (result.Length * replaceWeight) + ((source.Length - result.Length) * deleteWeight);
                }
            }

            var prefixResult = result.Substring(0, result.IndexOf(common));
            var suffixResult = result.Substring(result.IndexOf(common) + common.Length);
            var prefixSource = source.Substring(0, source.IndexOf(common));
            var suffixSource = source.Substring(source.IndexOf(common) + common.Length);
            return GetTotalWeight(prefixSource, prefixResult) + GetTotalWeight(suffixSource, suffixResult);
        }
    }
}
