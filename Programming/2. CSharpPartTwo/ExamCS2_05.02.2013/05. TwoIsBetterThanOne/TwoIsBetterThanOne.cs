using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TwoIsBetterThanOne
{
    static string ReverseString(string s)
    {
        
        StringBuilder sb = new StringBuilder(s.Length);
        for (sbyte i = (sbyte)(s.Length - 1); i >=0; i--)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
    static StringBuilder luckyNum = new StringBuilder();
    static uint count = 0;

    static void GetLuckyNumbersCountPartial(ulong start, ulong end, byte pos)
    {
        if (start > end) return;
        if (pos == start.ToString().Length / 2)
        {
            string rev;
            if ((start.ToString().Length & 1) == 0)
            {
                rev = ReverseString(luckyNum.ToString());
                luckyNum.Append(rev);
                ulong temp = ulong.Parse(luckyNum.ToString());
                if (temp >= start && temp <= end) count++;
                luckyNum.Remove(pos, rev.Length);
            }
            else
            {
                rev = ReverseString(luckyNum.ToString());
                luckyNum.Append(3);
                luckyNum.Append(rev);
                ulong temp = ulong.Parse(luckyNum.ToString());
                if (temp >= start && temp <= end) count++;
                luckyNum.Remove(pos, rev.Length + 1);
                luckyNum.Append(5);
                luckyNum.Append(rev);
                temp = ulong.Parse(luckyNum.ToString());
                if (temp >= start && temp <= end) count++;
                luckyNum.Remove(pos, rev.Length + 1);
            }
            return;
        }
        luckyNum.Append(3);
        GetLuckyNumbersCountPartial(start, end, (byte)(pos + 1));
        luckyNum.Remove(pos, 1);
        luckyNum.Append(5);
        GetLuckyNumbersCountPartial(start, end, (byte)(pos + 1));
        luckyNum.Remove(pos, 1);
    }

    static void GetLuckyNumbersCountExact(ulong start, byte startIncluded, ulong end, byte endIncluded)
    {
        if (start > end) return;
        for (uint i = (uint)(start.ToString().Length + 1 - startIncluded); i < end.ToString().Length + endIncluded; i++)
        {
            if ((i & 1) == 0)
            {
                count += (uint)Math.Pow(2, i / 2);
            }
            else
            {
                count += (uint)Math.Pow(2, i / 2) * 2;
            }
        }
        return;
    }

    static void GetLuckyNumbersCount(ulong start, ulong end)
    {
        ulong endLowerLimit;
        ulong endUpperLimit;
        ulong startUpperLimit;
        ulong startLowerLimit;
        byte startDigitCount = (byte)start.ToString().Length;
        byte endDigitCount = (byte)end.ToString().Length;
        if (startDigitCount < endDigitCount)
        {
            StringBuilder limit = new StringBuilder(startDigitCount);
            StringBuilder limit1 = new StringBuilder(startDigitCount);
            for (int i = 1; i <= startDigitCount; i++)
            {
                limit.Append(5);
                limit1.Append(3);
            }
            startUpperLimit = ulong.Parse(limit.ToString());
            startLowerLimit = ulong.Parse(limit1.ToString());
            limit.Clear();
            limit1.Clear();
            for (int i = 1; i <= endDigitCount; i++)
            {
                limit.Append(3);
                limit1.Append(5);
            }
            endLowerLimit = ulong.Parse(limit.ToString());
            endUpperLimit = ulong.Parse(limit1.ToString());
            if (end > endUpperLimit && start > startUpperLimit)
            {
                GetLuckyNumbersCountExact(start, (byte)0, end, (byte)1);
                return;
            }
            else if(end < endLowerLimit && start > startUpperLimit)
            {
                GetLuckyNumbersCountExact(start, (byte)0, end, (byte)0);
                return;
            }
            else if (end < endLowerLimit && start < startLowerLimit)
            {
                GetLuckyNumbersCountExact(start, (byte)1, end, (byte)0);
                return;
            }
            else if (end > endUpperLimit && start < startLowerLimit)
            {
                GetLuckyNumbersCountExact(start, (byte)1, end, (byte)1);
                return;
            }
            GetLuckyNumbersCountPartial(Math.Max(start, startLowerLimit), startUpperLimit, 0);
            luckyNum.Clear();
            GetLuckyNumbersCountPartial(endLowerLimit, Math.Min(end, endUpperLimit), 0);
            luckyNum.Clear();
            GetLuckyNumbersCountExact(start, 0, end, 0);
        }
        else
        {
            StringBuilder limit = new StringBuilder(startDigitCount);
            StringBuilder limit1 = new StringBuilder(startDigitCount);
            for (int i = 1; i <= startDigitCount; i++)
            {
                limit.Append(5);
                limit1.Append(3);
            }
            endUpperLimit = ulong.Parse(limit.ToString());
            startLowerLimit = ulong.Parse(limit1.ToString());
            limit.Clear();
            limit1.Clear();
            GetLuckyNumbersCountPartial(Math.Max(start, startLowerLimit), Math.Min(end, endUpperLimit), 0);
            luckyNum.Clear();
        }
        return;
    }

    static int GetPercentileElement(byte p)
    {
        Array.Sort(numbers);
            if (p == 0 || (numbers.Length * p / 100.0) - (int)(numbers.Length * p / 100.0) > 0)
            {
                return numbers[(int)(numbers.Length * p / 100.0)];
            }
            else
            {
                return numbers[(int)(numbers.Length * p / 100.0) - 1];
            }
    }

    static int[] numbers;

    static void Main()
    {

        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');
        ulong a = ulong.Parse(splittedInput[0]);
        ulong b = ulong.Parse(splittedInput[1]);
        input = Console.ReadLine();
        splittedInput = input.Split(',');
        numbers = new int[splittedInput.Length];
        for (byte i = 0; i < splittedInput.Length; i++)
        {
            numbers[i] = int.Parse(splittedInput[i]);
        }
        byte percentage = byte.Parse(Console.ReadLine());
        GetLuckyNumbersCount(a, b);
        Console.WriteLine(count);
        Console.WriteLine(GetPercentileElement(percentage));
    }
}

