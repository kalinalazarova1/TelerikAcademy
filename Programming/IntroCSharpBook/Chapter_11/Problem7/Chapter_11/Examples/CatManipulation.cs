using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7.Chapter_11.Examples
{
    class CatManipulation
    {
        public static void PrintMyCats()
        {
            string[] colors = { "red", "black", "white", "grey", "striped" };
            string[] names = { "Alfred", "Oscar", "Pussy", "Oliver", "Maza" };
            Random radomGen = new Random();
            List<Cat> myCats = new List<Cat>();
            for (int i = 0; i < 5; i++)
            {
                Cat singleCat = new Cat(names[radomGen.Next(0, 5)], colors[radomGen.Next(0, 5)]);
                myCats.Add(singleCat);
            }
            foreach (var cat in myCats)
            {
                Console.WriteLine("My {0} cat is {1} and its color is {2}", Sequence.NextValue(), cat.Name, cat.Color);
            }
        }
    }
}
