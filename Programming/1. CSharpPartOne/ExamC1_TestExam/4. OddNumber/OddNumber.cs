using System;

class OddNumber     //This version is only 50% because of the time limit erros
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        long[,] number = new long[n, 2];
        long tempNumber = 0;
        bool isUsed = false;
        for (uint i = 0; i < n; i++)
        {
            tempNumber = long.Parse(Console.ReadLine());
            for (int j = 0; j < n; j++)
            {
                if (tempNumber == number[j, 0])
                {
                    number[j, 1]++;
                    isUsed = true;
                    break;
                }

            }
            if (!isUsed)
            {
                number[i, 0] = tempNumber; 
                number[i, 1]++;
            }
        }
        for (uint i = 0; i < n; i++)
        {
            if((number[i, 1] & 1)== 1)
            {
                Console.WriteLine(number[i, 0]);
                break;
            }
        }
    }
}
