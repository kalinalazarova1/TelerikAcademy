using System;

class Liquid
{
    static void Main()
    {
        char[] separator = {' '};
        string input = Console.ReadLine();
        string[] splittedInput = input.Split(' ');
        int w = int.Parse(splittedInput[0]);
        int h = int.Parse(splittedInput[1]);
        int d = int.Parse(splittedInput[2]);
        int[,,] cuboid = new int[h, w, d];
        int[,] inputLiquid = new int[h, w];
        for (int r = 0; r < h; r++)
        {
            input = Console.ReadLine();
            splittedInput = input.Split('|');
            for (int l = 0; l < d; l++)
            {
                string[] doubleSplitted = splittedInput[l].Split(separator,StringSplitOptions.RemoveEmptyEntries);
                for (int c = 0; c < w; c++)
                {
                    cuboid[r, c, l] = int.Parse(doubleSplitted[c]);
                }
            }
        }
        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                inputLiquid[r, c] = cuboid[r, c, 0];
            }
        }
        for (int l = 1; l < d; l++)
        {
            for (int r = 0; r < h; r++)
            {
                for (int c = 0; c < w; c++)
                {
                    if (inputLiquid[r, c] > cuboid[r, c, l])
                    {             
                        int diff = inputLiquid[r, c] - cuboid[r, c, l];
                        inputLiquid[r, c] = cuboid[r, c, l];
                        int[,] capacity = GetFreeCapacity(cuboid, inputLiquid, l);
                        while (true)
                        {
                            if (IsInside(inputLiquid, r + 1, c))
                            {
                                diff -= capacity[r + 1, c];
                                if (diff <= 0)
                                {
                                    inputLiquid[r + 1, c] += (diff + capacity[r + 1, c]);
                                    break;
                                }
                                else
                                {
                                    inputLiquid[r + 1, c] += capacity[r + 1, c];
                                }
                            }
                            if (IsInside(inputLiquid, r, c + 1))
                            {
                                diff -= capacity[r, c + 1];
                                if (diff <= 0)
                                {
                                    inputLiquid[r, c + 1] += (diff + capacity[r, c + 1]);
                                    break;
                                }
                                else
                                {
                                    inputLiquid[r, c + 1] += capacity[r, c + 1];
                                }
                            }
                            if (IsInside(inputLiquid, r - 1, c))
                            {
                                diff -= capacity[r - 1, c];
                                if (diff <= 0)
                                {
                                    inputLiquid[r - 1, c] += (diff + capacity[r - 1, c]);
                                    break;
                                }
                                else
                                {
                                    inputLiquid[r - 1, c] += capacity[r - 1, c];
                                }
                            }
                            if (IsInside(inputLiquid, r, c - 1))
                            {
                                diff -= capacity[r, c - 1];
                                if (diff <= 0)
                                {
                                    inputLiquid[r, c - 1] += (diff + capacity[r, c - 1]);
                                    break;
                                }
                                else
                                {
                                    inputLiquid[r, c - 1] += capacity[r, c - 1];
                                }
                            }
                            break;
                        }
                    }
                    /*else
                    {
                        cuboid[r, c, l] -= inputLiquid[r, c];
                    }*/
                }
            }
        }
        int sum = 0;
        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                sum += inputLiquid[r, c];
            }
        }
        Console.WriteLine(sum);
    }

    static int[,] GetFreeCapacity(int[,,] cuboid, int[,] inputLiquid, int layer)
    {
        int[,] capacity = new int[inputLiquid.GetLength(0), inputLiquid.GetLength(1)];
        for (int r = 0; r < capacity.GetLength(0); r++)
        {
            for (int c = 0; c < capacity.GetLength(1); c++)
            {
                if (cuboid[r, c, layer] >= inputLiquid[r, c])
                {
                    capacity[r, c] = (cuboid[r, c, layer] - inputLiquid[r, c]);
                }
            }
        }
        return capacity;
    }

    static bool IsInside(int[,] array, int r, int c)
    {
        if (r >= 0 && r < array.GetLength(0) && c >= 0 && c < array.GetLength(1))
        {
            return true;
        }
        return false;
    }
}
