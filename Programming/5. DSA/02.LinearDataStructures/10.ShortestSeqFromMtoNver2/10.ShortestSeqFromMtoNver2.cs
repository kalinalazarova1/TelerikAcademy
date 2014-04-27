//10.* We are given numbers N and M and the following operations:
//a) N = N+1
//b) N = N+2
//c) N = N*2
//Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. 
//Hint: use a queue.
//Example: N = 5, M = 16
//Sequence: 5 -> 7 -> 8 -> 16

using System;
using System.Collections.Generic;

class ShortestSeqFromMtoNver2       //this implementation is more efficient and could work with much bigger numbers but does not work for negative numbers
{
    static void Main()
    {
        int n = 0;
        int m = 1000000;
        var result = new Stack<int>();
        result.Push(m);
        if (m <= n || n < 0)
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        while (m > n)
        {
            if (m / 2 >= n && m % 2 == 0 && m > 2)
            {
                result.Push(m / 2);
                m /= 2;
            }
            else if(m / 2 >= n && m % 2 == 1 && m > 2)
            {
                result.Push(m - 1);
                m--;
            }
            else if(m - 2 >= n)
            {
                result.Push(m - 2);
                m -= 2;
            }
            else
            {
                result.Push(m - 1);
                m--;
            }
        }
        Console.WriteLine(string.Join("->", result));
    }
}
