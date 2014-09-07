// 1. Using code first approach, create database for student system with the following tables:
// Students (with Id, Name, Number, etc.)
// Courses (Name, Description, Materials, etc.)
// StudentsInCourses (many-to-many relationship)
// Homework (one-to-many relationship with students and courses), fields: Content, TimeSent
// Annotate the data models with the appropriate attributes and enable code first migrations
// Write a console application that uses the data
// Seed the data with random values

namespace SchoolConsole.Client
{
    using School.Data;
    using System;
    using System.Linq;

    public class SchoolConsoleClientEntryPoint
    {
        public static void Main()
        {
            var ran = new Random();
            var repo = new SchoolRepository();
           
            var query = repo.Courses.All().First(c => c.Name == "HTML").Students.Select(st => st.Name).OrderBy(name => name);
            Console.WriteLine("Find all students in the HTML Course:");
            Console.WriteLine(string.Join(Environment.NewLine, query));
        }
    }
}
