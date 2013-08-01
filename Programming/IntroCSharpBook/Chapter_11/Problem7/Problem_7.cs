using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem7.Chapter_11;

namespace Problem_8
{
    class Problem_7
    {

        static void Main()
        {
            string[] colors = { "red", "black", "white", "grey", "striped", "yellow", "blue", "green" };
            Random radomGen = new Random();
            List<Cat> myCats = new List<Cat>();
            for (int i = 0; i < 10; i++)
            {
                Cat singleCat = new Cat("Cat" + Sequence.NextValue(), colors[radomGen.Next(0, 8)]);
                myCats.Add(singleCat);
            }
            Problem7.Chapter_11.Examples.CatManipulation.PrintMyCats();
            foreach (var cat in myCats)
            {
                cat.SayMiau();
            }
        }
    }
}
