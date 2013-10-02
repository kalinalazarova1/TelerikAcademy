//2. Define abstract class Human with first name and last name. Define new class Student which is 
//derived from Human and has new field – grade. Define class Worker derived from Human with new 
//property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns money earned by
//hour by the worker. Define the proper constructors and properties for this hierarchy. Initialize 
//a list of 10 students and sort them by grade in ascending order (use LINQ or OrderBy() extension
//method). Initialize a list of 10 workers and sort them by money per hour in descending order. 
//Merge the lists and sort them by first name and last name.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanWorkerStudent
{
    public class HumanWorkerStudent
    {
        static void Main()
        {
            Student[] arrStudentsTest = { new Student("Sonya", "Markova", 3), new Student("Sotir", "Galabov", 2), new Student("Svilen", "Belev", 2), 
                                        new Student("Petar","Peshev", 5),new Student("Ivaylo","Drajev", 3),new Student("Krasi","Smilkov", 4),
                                        new Student("Yana","Mileva", 3),new Student("Vito","Zagorski", 1),new Student("Valeri","Timev", 5),
                                        new Student("Rumen","Vlahov", 6),};
            List<Student> studentsTest = arrStudentsTest.ToList();
            foreach (var student in studentsTest.OrderBy(s => s.Grade))
            {
                Console.WriteLine("Student: {0},\tGrade: {1}", student, student.Grade);
            }
            Worker[] arrWorkerTest = { new Worker("Angel", "Velev", 500, 8), new Worker("Lazar", "Penev", 230, 4), new Worker("Georgi", "Kostov", 340, 7), 
                                     new Worker("Vasil", "Vasilev", 600, 10), new Worker("Teo", "Simeonov", 550, 8), new Worker("Jivko", "Jelev", 380, 7),
                                    new Worker("Daniel", "Hristov", 150, 5), new Worker("Mihail", "Ivanov", 480, 8), new Worker("Kamen", "Kamburov", 420, 8),
                                    new Worker("Vesela", "Ganeva", 100, 2)};
            List<Worker> workerTest = arrWorkerTest.ToList();
            foreach (var worker in workerTest.OrderByDescending(w => w.MoneyPerHour()))
            {
                Console.WriteLine("Worker: {0},\tMoney Per Hour: {1:0.00}", worker.ToString(), worker.MoneyPerHour());   
            }
            List<Human> all = new List<Human>();
            all.AddRange(workerTest);
            all.AddRange(studentsTest);
            foreach (var human in all.OrderBy(i => i.FirstName).ThenBy(i => i.LastName))
            {
                Console.WriteLine(human);
            }
        }
    }
}
