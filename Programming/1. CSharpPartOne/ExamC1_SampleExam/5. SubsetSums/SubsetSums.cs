using System;

class SubsetSums
{
    static void Main()
    {
        int sumCount = 0;
        long sumValue = long.Parse(Console.ReadLine());
        byte n = byte.Parse(Console.ReadLine());
        long[] numbers = new long[n];
        long[] possibleSums = new long[(int)Math.Pow(2,n)];
        for (byte i = 0; i < n; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }
        int index = 1;
        for (byte i = 0; i < n; i++)
        {
            possibleSums[index] = numbers[i];
            if (possibleSums[index] == sumValue)
            {
                sumCount++;
            }
            int tempIndex = index;
            index++;
            for (int j = 1; j < tempIndex; j++, index++)
            {
                possibleSums[index] = possibleSums[j] + numbers[i];
                if (possibleSums[index] == sumValue)
                {
                    sumCount++;
                }
            }
        }
        Console.WriteLine(sumCount);
    }
}
