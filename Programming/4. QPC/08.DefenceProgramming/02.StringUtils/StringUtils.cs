namespace _02.Utils
{
    using System;
    using System.Text;

    public static class StringUtils
    {
        public static string ExtractEnding(string str, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str", "The string could not be null!");
            }

            if (count < 0)
            {
                throw new ArgumentException("count", "The count could not be less than zero!");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("count", "The count could not be greater than the string length!");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}
