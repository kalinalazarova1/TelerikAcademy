// 1. Refactor the following examples to produce code with well-named C# identifiers:

using System;

internal class FlagPrinterTest
{
    internal const int MaxCount = 6;

    public static void Main()
    {
        FlagPrinterTest.FlagPrinter instance = new FlagPrinterTest.FlagPrinter();
        instance.PrintFlag(true);
    }

    private class FlagPrinter
    {
        public void PrintFlag(bool flag)
        {
            Console.WriteLine(flag);
        }
    }
}