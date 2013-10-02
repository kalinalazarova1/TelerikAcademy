using System;

class MultiverseCommunication
{
    static void Main()
    {
        string[] cipher = {"CHU","TEL","OFT","IVA","EMY","VNB","POQ","ERI","CAD","K-A","IIA","YLO","PLA" };
        string input = Console.ReadLine();
        ulong output = 0;
        int pow = 0;
        for (int i = input.Length - 1; i >= 0; i -= 3)
        {
            output += (ulong)Math.Pow(13, pow) * (ulong)Array.IndexOf(cipher, string.Format("{2}{1}{0}", input[i], input[i - 1], input[i - 2]));
            pow++;
        }
        Console.WriteLine(output);
    }
}
