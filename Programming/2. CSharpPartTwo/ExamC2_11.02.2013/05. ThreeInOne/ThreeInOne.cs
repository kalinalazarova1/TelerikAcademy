using System;

class ThreeInOne
{
    static void Main()
    {
        int firstResult = FirstTask();
        int secondResult = SecondTask();
        int thirdResult = ThirdTask();
        Console.WriteLine("{0}\n{1}\n{2}", firstResult, secondResult, thirdResult);
    }

    static int FirstTask()
    {
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(',');
        byte[] points = new byte[splittedInput.Length];
        byte[] positions = new byte[splittedInput.Length];
        for (byte i = 0; i < splittedInput.Length; i++)
        {
            points[i] = byte.Parse(splittedInput[i]);
            positions[i] = i;
        }
        Array.Sort(points, positions);
        sbyte index = (sbyte)Array.BinarySearch(points, (byte)21);
        if (index > 0 && index < points.Length - 1 && points[index + 1] == 21)
        {
            return -1;
        }
        else if ((index == 0) || (index > 0 && points[index - 1] < 21))
        {
            return positions[index];
        }
        else if ((index > 0 && points[index - 1] == 21) || (index == -1))
        {
            return -1;
        }
        else if (index < -1 && points[~index - 1 - 1] < points[~index - 1])
        {
            return positions[~index - 1];
        }
        else
        {
            return -1;
        }
    }

    static int SecondTask()
    {
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(',');
        byte[] sizes = new byte[splittedInput.Length];
        for (byte i = 0; i < sizes.Length; i++)
        {
            sizes[i] = byte.Parse(splittedInput[i]);
        }
        byte friendsCount = byte.Parse(Console.ReadLine());
        Array.Sort(sizes);
        Array.Reverse(sizes);
        byte bitesSum = 0;
        for (byte i = 0; i < sizes.Length; i += (byte)(friendsCount + 1))
        {
            bitesSum += sizes[i];
        }
        return bitesSum;
    }

    static int ThirdTask()
    {
        int operCounter = 0;
        int[] has = new int[3];
        int[] needs = new int[3];
        int[] diff = new int[3];
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');
        for (int i = 0; i < 3; i++)
        {
            has[i] = int.Parse(splittedInput[i]);
            needs[i] = int.Parse(splittedInput[i + 3]);
        }
        for (int i = 0; i < 3; i++)
        {
            diff[i] = has[i] - needs[i];
        }
        if (diff[0] < 0 && diff[1] < 0 && diff[2] < 0)
        {
            return -1;
        }
        while (diff[0] < 0 || diff[1] < 0 || diff[2] < 0)
        {
            if (diff[2] < 0 && diff[1] > 0)
            {
                diff[1]--;
                diff[2] += 9;
                operCounter++;
            }
            else if (diff[0] < 0 && diff[1] >= 11)
            {
                diff[1] -= 11;
                diff[0]++;
                operCounter++;
            }
            else if (diff[0] < 0 && diff[1] < 11 && diff[2] < 11)
            {
                return -1;
            }
            else if (diff[0] < 0 && diff[1] < 11 && diff[2] >= 11)
            {
                diff[2] -= 11;
                diff[1]++;
                operCounter++;
            }
            else if (diff[0] > 0 && diff[1] < 0 || diff[0] > 0 && diff[2] < 0)
            {
                diff[0]--;
                diff[1] += 9;
                operCounter++;
            }
            else if (diff[1] < 0 && diff[2] < 11 && diff[0] <= 0)
            {
                return -1;
            }
            else if (diff[1] < 0 && diff[2] >= 11 && diff[0] <= 0)
            {
                diff[2] -= 11;
                diff[1]++;
                operCounter++;
            }
            else
            {
                return -1;
            }
        }
        return operCounter;
    }
}