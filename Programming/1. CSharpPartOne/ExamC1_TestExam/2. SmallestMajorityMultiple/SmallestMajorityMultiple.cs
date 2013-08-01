using System;

class SmallestMajorityMultiple
{
    static void Main()
    {
        byte a = byte.Parse(Console.ReadLine());
        byte b = byte.Parse(Console.ReadLine());
        byte c = byte.Parse(Console.ReadLine());
        byte d = byte.Parse(Console.ReadLine());
        byte e = byte.Parse(Console.ReadLine());
        uint leastMajorityMultiple = 0;
        for (uint i = 1; i < 1000000; i++)
			{
                byte counter = 0;
                if (i % a == 0) counter++;
                if (i % b == 0) counter++;
                if (i % c == 0) counter++;
                if (i % d == 0) counter++;
                if (i % e == 0) counter++;
                if (counter > 2)
                {
                    leastMajorityMultiple = i;
                    break;
                }
			}
        Console.WriteLine(leastMajorityMultiple);
    }
}
