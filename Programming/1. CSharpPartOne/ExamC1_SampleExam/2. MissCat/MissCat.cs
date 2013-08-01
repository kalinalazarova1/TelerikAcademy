using System;

class MissCat
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        uint[] cat = new uint[10];
        uint maxVote = 0;

        for (uint i = 0; i < n; i++)
        {
            uint catIndex = uint.Parse(Console.ReadLine());
            cat[catIndex - 1]++;
            if (cat[catIndex - 1] > maxVote)
            {
                maxVote = cat[catIndex - 1];
            }
        }
        for (byte i = 0; i < 10; i++)
        {
            if (cat[i] == maxVote)
            {
                Console.WriteLine(i + 1);
                break;
            }
        }
    }
}
