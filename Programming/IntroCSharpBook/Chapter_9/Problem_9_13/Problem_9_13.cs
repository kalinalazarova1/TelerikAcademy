using System;

class Problem_9_13
{
    static int[] MultiplyPolynoms(int[] fNum, int[] sNum)
    {
        int[] res = new int[fNum.GetLength(0) * sNum.GetLength(0)];
        for(int j = 0; j < sNum.GetLength(0); j++)
        {
            for (int i = 0; i < fNum.GetLength(0); i++)
            {

                if (i < fNum.GetLength(0) && j < sNum.GetLength(0))
                {
                    res[i + j] = fNum[i]*sNum[j] + res[i + j];
                }
            }
        }
        return res;
    }

    static void PrintPolynom(int[] coef)
    {
        for (int i = coef.GetLength(0) - 1; i >= 0; i--)
        {
            if (coef[i] > 0 && coef[i] != 1)
            {
                if (i == 0)
                    Console.WriteLine(" +{0}", coef[i]);
                else if (i == 1)
                    Console.Write(" +{0}X", coef[i]);
                else if (i != coef.GetLength(0) - 1)
                    Console.Write(" +{0}X{1}", coef[i], i);
                else
                    Console.Write("{0}X{1}", coef[i], i); 
                    
            }
            else if (coef[i] < 0 && coef[i] != -1)
            {
                if (i == 0)
                    Console.WriteLine(" {0}", coef[i]);
                else if (i == 1)
                    Console.Write(" {0}X", coef[i]);
                else if (i != coef.GetLength(0) - 1)
                    Console.Write(" {0}X{1}", coef[i], i);
                else
                    Console.Write("{0}X{1}", coef[i], i);
            }
            else if (coef[i] == 1)
            {
                if (i == 0)
                    Console.WriteLine(" +{0}", coef[i]);
                else if (i == 1)
                    Console.Write(" +X");
                else if (i != coef.GetLength(0) - 1)
                    Console.Write(" +X{0}", i);
                else
                    Console.Write("X{0}", i);
            }
            else if (coef[i] == -1)
            {
                if (i == 0)
                    Console.WriteLine(" {0}", coef[i]);
                else if (i == 1)
                    Console.Write(" -X");
                else if (i != coef.GetLength(0) - 1)
                    Console.Write(" -X{0}", i);
                else
                    Console.Write("X{0}", i);
            }
        }
    }

    static void Main()
    {
        int[] firstPolynomCoef = {-3, 1, 3};
        int[] secondPolynomCoef = {-1, 1};
        PrintPolynom(firstPolynomCoef);
        Console.WriteLine("*");
        PrintPolynom(secondPolynomCoef);
        Console.WriteLine("=");
        PrintPolynom(MultiplyPolynoms(firstPolynomCoef, secondPolynomCoef));
    }
}
