﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toto_6_49
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            for (int i1 = 1; i1 <= 44; i1++)
            {
                for (int i2 = i1 + 1; i2 <= 45; i2++)
                {
                    for (int i3 = i2 + 1; i3 <= 46; i3++)
                    {
                        for (int i4 = i3 + 1; i4 <= 47; i4++)
                        {
                            for (int i5 = i4 + 1; i5 <= 48; i5++)
                            {
                                for (int i6 = i5 + 1; i6 <= 49; i6++)
                                {
                                    num = num + 1; 
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Всички уникални комбинации в тото 6 от 49 са: " + num + " броя.");
        }
    }
}
