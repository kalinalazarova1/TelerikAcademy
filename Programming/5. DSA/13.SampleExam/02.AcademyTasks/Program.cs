namespace _02.AcademyTasks
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var pleaString = Console.ReadLine();
            var pleaArray = pleaString.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var pleasantness = new int[pleaArray.Length];
            for (int i = 0; i < pleaArray.Length; i++)
            {
                pleasantness[i] = int.Parse(pleaArray[i]);
            }

            var variety = int.Parse(Console.ReadLine());
            var currentVariety = new TasksInfo[variety + 1, pleasantness.Length];
            currentVariety[0, 0] = new TasksInfo(pleasantness[0], pleasantness[0], 0);
            for (int c = 1; c < pleasantness.Length; c++)
            {
                for (int r = 0; r <= variety; r++)
                {
                    if (currentVariety[r, c - 1] != null)
                    {
                        if (currentVariety[r, c - 1].CurrnetTask + 1 < pleasantness.Length)
                        {
                            var task = currentVariety[r, c - 1].CurrnetTask + 1;
                            var min = Math.Min(currentVariety[r, c - 1].Min, pleasantness[currentVariety[r, c - 1].CurrnetTask + 1]);
                            var max = Math.Max(currentVariety[r, c - 1].Max, pleasantness[currentVariety[r, c - 1].CurrnetTask + 1]);
                            var currVar = max - min;
                            if (currVar >= variety)
                            {
                                Console.WriteLine(c + 1);
                                Environment.Exit(0);
                            }

                            currentVariety[currVar, c] = new TasksInfo(min, max, task);
                        }

                        if (currentVariety[r, c - 1].CurrnetTask + 2 < pleasantness.Length)
                        {
                            var task = currentVariety[r, c - 1].CurrnetTask + 2;
                            var min = Math.Min(currentVariety[r, c - 1].Min, pleasantness[currentVariety[r, c - 1].CurrnetTask + 2]);
                            var max = Math.Max(currentVariety[r, c - 1].Max, pleasantness[currentVariety[r, c - 1].CurrnetTask + 2]);
                            var currVar = max - min;
                            if (currVar >= variety)
                            {
                                Console.WriteLine(c + 1);
                                Environment.Exit(0);
                            }

                            currentVariety[currVar, c] = new TasksInfo(min, max, task);
                        }
                    }
                }
            }

            Console.WriteLine(pleasantness.Length);
        }
    }
}
