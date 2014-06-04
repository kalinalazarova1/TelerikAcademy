// 2.Write a program to compare the performance of add, subtract, increment, multiply, divide
// for int, long, float, double and decimal values.

namespace _01.OperationComparison
{
    using System;
    using System.Diagnostics;

    internal static class OperationsComparison
    {
        internal static void Main()
        {
            var operation = new Func<dynamic, dynamic, dynamic>((x, y) => x + y);
            RunAllTests(operation, "Adding", 1000000);
            operation = new Func<dynamic, dynamic, dynamic>((x, y) => x - y);
            RunAllTests(operation, "Substracting", 1000000);
            operation = new Func<dynamic, dynamic, dynamic>((x, y) => x++);
            RunAllTests(operation, "Incrementing", 1000000);
            operation = new Func<dynamic, dynamic, dynamic>((x, y) => x * y);
            RunAllTests(operation, "Multipling", 1000000);
            operation = new Func<dynamic, dynamic, dynamic>((x, y) => x / y);
            RunAllTests(operation, "Dividing", 1000000);
        }

        private static double MeasurePerformanceInSeconds(dynamic result, Func<dynamic, dynamic, dynamic> operation, int scope)
        {
            dynamic newResult;
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (dynamic i = 0; i < scope; i++)
            {
                newResult = operation(result, (dynamic)2);
            }
            
            sw.Stop();
            return sw.ElapsedMilliseconds / 1000.0;
        }

        private static void TestOperation(
            dynamic result,
            string resultName,
            Func<dynamic, dynamic, dynamic> operation,
            string operationName,
            int scope)
        {
            var seconds = MeasurePerformanceInSeconds(result, operation, scope);
            if (resultName != null)
            {
                Console.WriteLine("{0} {1}s: {2} seconds", operationName, resultName, seconds);
            }
        }

        private static void RunAllTests(Func<dynamic, dynamic, dynamic> operation, string operationName, int scope)
        {
            int integerResult = 1011;
            long longResult = 1011;
            float floatResult = 1011;
            double doubleResult = 1011;
            decimal decimalResult = 1011;

            TestOperation(longResult, null, operation, null, scope);     // first test is ignored to avoid the side effect of JIT compilation
            TestOperation(integerResult, "integer", operation, operationName, scope);
            TestOperation(longResult, "long", operation, operationName, scope);
            TestOperation(doubleResult, "double", operation, operationName, scope);
            TestOperation(floatResult, "float", operation, operationName, scope);
            TestOperation(decimalResult, "decimal", operation, operationName, scope);
            Console.WriteLine();
        }
    }
}
