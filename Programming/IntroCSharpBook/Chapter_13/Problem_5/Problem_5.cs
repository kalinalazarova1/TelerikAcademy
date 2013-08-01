using System;
using System.Text;

class Problem_5
{
    static void Main()
    {
        string s = "We kare living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        uint counter = 0;
        int result;
        s = s.ToLower();
        for (result = -2; result != -1; counter++)
        {
            result = s.IndexOf("in", result + 2);
        }
        Console.WriteLine(--counter);
    }
}
