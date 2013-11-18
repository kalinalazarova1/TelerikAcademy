//5. Define a class BitArray64 to hold 64 bit values inside an ulong value. Implement
//IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

using System;

namespace MyCollection
{
    public static class BitArray64Test
    {
        static void Main()
        {
            ulong number1 = 205;
            ulong number2 = 206;
            ulong number3 = 205;
            BitArray64 test1 = new BitArray64(number1);
            BitArray64 test2 = new BitArray64(number2);
            BitArray64 test3 = new BitArray64(number3);
            Console.WriteLine("Equalty check:");
            Console.WriteLine(test1 != test2);
            Console.WriteLine(test1 == test3);
            Console.WriteLine("Hash codes check:");
            Console.WriteLine(test1.GetHashCode());
            Console.WriteLine(test2.GetHashCode());
            Console.WriteLine(test3.GetHashCode());
            int i = 0;
            Console.WriteLine("GetEnumerator() check:");
            foreach (var item in test1)
            {
                Console.Write(item);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Indexer check:");
            for (i = 0; i < 64; i++)
            {
                Console.Write(test1[i]);
            }
            Console.WriteLine();
        }
    }
}
