using System;
using System.Text;

class Indices
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        string[] input = Console.ReadLine().Split(' ');
        StringBuilder output = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(input[i]);
        }
        output.Append("0 ");
        for (int index = arr[0]; index >= 0 && index < n; index = arr[index])
        {
            if (index == 0)
            {
                output = output.Insert(0, '(');
                output[output.Length - 1] = ')';
                break;
            }
            int search = output.ToString().IndexOf(string.Format(" {0} ", index));
            if (search > 0)
            {
                output[search] = '(';
                output[output.Length - 1] = ')';
                break;
            }
            output.Append(string.Format("{0} ", index));
        }
        Console.WriteLine(output.ToString().Trim());
    }
}