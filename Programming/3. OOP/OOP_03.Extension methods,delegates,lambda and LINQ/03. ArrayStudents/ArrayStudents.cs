//3. Write a method that from a given array of students finds all students whose first name is
//before its last name alphabetically. Use LINQ query operators.
//4. Write a LINQ query that finds the first name and last name of all students with age between
//18 and 24.
//5. Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students
//by first name and last name in descending order. Rewrite the same with LINQ.

using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayStudents
{
    class ArrayStudents
    {
        static void PrintStudentsFisrtBeforeLastName(Student[] studentsList)
        {
            var results =
                from student in studentsList
                where student.FisrtName.CompareTo(student.LastName) < 0
                select student;
            foreach (var student in results)
            {
                Console.WriteLine("{0} {1}", student.FisrtName, student.LastName);
            }
        }

        static void Main()
        {
            Student[] test = { new Student("Anton", "Popov", 21), new Student("Vasil", "Milev", 25), new Student("Hristo", "Uzunov", 17), new Student("Anton", "Drajev", 20), new Student("Silvia", "Lulcheva", 35)};
            foreach (var item in test)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Fisrt name before the last name:");
            PrintStudentsFisrtBeforeLastName(test);
            Console.WriteLine("Age between 18 and 24 including:");
            var ageIntervalSelection =
                from student in test
                where student.Age >= 18 && student.Age <= 24
                select student;
            foreach (var student in ageIntervalSelection)
            {
                Console.WriteLine("{0} {1}", student.FisrtName, student.LastName);
            }
            Console.WriteLine("Sorted in descending order by first and last name:");
            foreach (var student in test.OrderByDescending(k => k.FisrtName).ThenByDescending(k => k.LastName))
            {
                Console.WriteLine("{0} {1}", student.FisrtName, student.LastName);
            }
        }
    }
}
