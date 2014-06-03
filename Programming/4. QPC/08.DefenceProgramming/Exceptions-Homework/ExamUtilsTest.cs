// 2.Add exception handling (where missing) and refactor all incorrect error handling in the code from the "Exceptions-Homework"
// project to follow the best practices for using exceptions.

using System;
using System.Collections.Generic;
using System.Text;

internal class ExceptionsHomework
{
    internal static void Main()
    {
        try
        {
            List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
        catch (ArgumentOutOfRangeException aore)
        {
            Console.WriteLine(aore.Message);
        }
        catch (ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
