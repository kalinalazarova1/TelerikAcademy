namespace _02.Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Salaries
    {
        internal static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            var organization = new List<int>[c];
            var salaries = new long[c];

            for (int row = 0; row < c; row++)
            {
                organization[row] = new List<int>();
                string input = Console.ReadLine();
                if (input == new string('N', c))
                {
                    salaries[row] = 1;
                }
                else
                {
                    for (int col = 0; col < c; col++)
                    {
                        if (input[col] == 'Y')
                        {
                            organization[row].Add(col);
                        }
                    }
                }
            }

            while (salaries.Any(x => x == 0))
            {
                for (int i = 0; i < c; i++)
                {
                    if (salaries[i] == 0 && organization[i].All(x => salaries[x] > 0))
                    {
                        salaries[i] = organization[i].Sum(x => salaries[x]);
                    }
                }
            }

            Console.WriteLine(salaries.Sum());
        }
    }
}
