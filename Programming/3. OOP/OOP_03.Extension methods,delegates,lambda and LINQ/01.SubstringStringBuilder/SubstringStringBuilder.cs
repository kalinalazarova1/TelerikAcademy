//1. Implement an extension method Substring(int index, int length)
//for the class StringBuilder that returns new StringBuilder
//and has the same functionality as Substring in the class String.

using System;
using System.Text;

namespace SubstringStringBuilder
{
    public static class SubstringStringBuilder
    {
        public static string Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder res = new StringBuilder(sb.Length);
            if (index < 0 || length < 0)
            {
                throw new ArgumentException("The start index and the length of the substring must be equal or greater than zero!");
            }
            else if (sb.Length < index + length)
            {
                throw new ArgumentException("The sum of start index and the length must be less or equal to the size of the string!");
            }
            else
            {
                for (int i = index; i < index + length; i++)
                {
                    res.Append(sb[i]);
                }
            }
            return res.ToString();
        }

        static void Main()
        {
            try
            {
                StringBuilder test = new StringBuilder("The Telerik Software Academy provides free programming courses for everyone.");
                Console.WriteLine(test.Substring(4, 24));
                //Console.WriteLine(test.Substring(1, test.Length)); - this row tests the ArgumentException of the Substring method
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
