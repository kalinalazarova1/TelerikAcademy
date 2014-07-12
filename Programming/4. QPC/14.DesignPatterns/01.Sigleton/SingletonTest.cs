namespace _01.Sigleton
{
    using System;

    internal class SingletonTest
    {
        internal static void Main()
        {
            Score[] scores = { new Score("My", 20), new Score("My", 22), new Score("My", 24), new Score("You", 26), new Score("You", 28), new Score("They", 30) };
            var firstList = ScoreSheet.Instance;
            firstList.Add(scores[0]);
            firstList.Add(scores[1]);
            var secondList = ScoreSheet.Instance;
            secondList.Add(scores[2]);
            secondList.Add(scores[3]);
            secondList.Add(scores[4]);
            secondList.Add(scores[5]);
            Console.WriteLine("First List:\n{0}", firstList);
            Console.WriteLine("Second List:\n{0}", secondList);
            Console.WriteLine("The two lists have same reference: {0}", firstList == secondList);
        }
    }
}
