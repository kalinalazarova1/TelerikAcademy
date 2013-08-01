//11. Write a method that adds two polynomials. Represent them as arrays of their coefficients
//as in the example below:
// X2 + 5 = 1.X2 + 0.X + 5 -> [5, 0, 1]

using System;

class AddPolynoms
{
    static int GetMax(int a, int b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }

    static int[] SumPolynom(int[] fNum, int[] sNum)
    {
        int[] res = new int[GetMax(fNum.GetLength(0), sNum.GetLength(0))];
        for (int i = 0; i < res.GetLength(0); i++)
        {
            if (i < fNum.GetLength(0) && i < sNum.GetLength(0))
            {
                res[i] = fNum[i] + sNum[i];
            }
            else if (i >= fNum.GetLength(0))
            {
                res[i] = sNum[i];
            }
            else
            {
                res[i] = fNum[i];
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
        int[] firstPolynomCoef = { -3, 0, -3 };
        int[] secondPolynomCoef = { 1, -2, 1 };
        PrintPolynom(firstPolynomCoef);
        Console.WriteLine("+");
        PrintPolynom(secondPolynomCoef);
        Console.WriteLine("=");
        PrintPolynom(SumPolynom(firstPolynomCoef, secondPolynomCoef));
    }
}
