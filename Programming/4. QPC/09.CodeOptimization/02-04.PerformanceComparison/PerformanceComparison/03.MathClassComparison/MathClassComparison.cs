// 3.Write a program to compare the performance of square root, natural logarithm, sinus for float, double and decimal values.

namespace _03.MathClassComparison
{
    using System;
    using System.Diagnostics;

    internal class MathClassComparison
    {
        internal static void Main()
        {
            // These tests are pointless, because Math.Sqrt, Math.Log and Math.Sin all work only with doubles
            // and therefore double is fastest because all other numbers are casted to double which makes the difference between the tests
            var operation = new Func<dynamic, dynamic>((x) => Math.Sqrt((double)x)); 
            RunAllTests(operation, "Square root", 1000000);
            operation = new Func<dynamic, dynamic>((x) => Math.Log((double)x, Math.E));
            RunAllTests(operation, "Natural logarithm", 1000000);
            operation = new Func<dynamic, dynamic>((x) => Math.Sin((double)x));
            RunAllTests(operation, "Sinus", 1000000);
        }

        private static double MeasurePerformanceInSeconds(dynamic result, Func<dynamic, dynamic> operation, int scope)
        {
            double newResult;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (dynamic i = 0; i < scope; i++)
            {
                newResult = operation(result);
            }

            sw.Stop();
            return sw.ElapsedMilliseconds / 1000.0;
        }

        private static void TestOperation(
            dynamic result,
            string resultName,
            Func<dynamic, dynamic> operation,
            string operationName,
            int scope)
        {
            var seconds = MeasurePerformanceInSeconds(result, operation, scope);
            if (resultName != null)
            {
                Console.WriteLine("{0} {1}s: {2} seconds", operationName, resultName, seconds);
            }
        }

        private static void RunAllTests(Func<dynamic, dynamic> operation, string operationName, int scope)
        {
            float floatResult = 0;
            double doubleResult = 0;
            decimal decimalResult = 0;

            TestOperation(doubleResult, null, operation, null, scope);     // first test is ignored to avoid the side effect of JIT compilation      
            TestOperation(doubleResult, "double", operation, operationName, scope);
            TestOperation(floatResult, "float", operation, operationName, scope);
            TestOperation(decimalResult, "decimal", operation, operationName, scope);
            Console.WriteLine();
        }
    }
}
