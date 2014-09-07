namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using School.Data;
    using School.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolDbContext context)
        {
            SetStudents(context);
            SetCourses(context);
            SetResources(context);
            SetHomeworks(context);
        }

        private void SetHomeworks(SchoolDbContext context)
        {
            if (context.Homeworks.Any())
            {
                return;
            }

            Homework[] homeworks = {
                                   new Homework() { TimeSent = new DateTime(2014, 08, 29), Content = "Homework 1" },
                                   new Homework() { TimeSent = new DateTime(2014, 08, 30), Content = "Homework 2" }
                                   };
            context.Homeworks.Add(homeworks[0]);
            context.Homeworks.Add(homeworks[1]);

            context.Courses.Local.First().Homeworks.Add(homeworks[0]);
            context.Courses.Local.First().Homeworks.Add(homeworks[1]);

            context.Students.Local.First().Homeworks.Add(homeworks[0]);
            context.Students.Local.First().Homeworks.Add(homeworks[1]);
        }

        private void SetResources(SchoolDbContext context)
        {
            if (context.Resources.Any())
            {
                return;
            }

            Resource[] res = { 
                             new Resource() { Content = "Lecture 1" },
                             new Resource() { Content = "Lecture 2" }, 
                             new Resource() { Content = "Lecture 1" },
                             new Resource() { Content = "Lecture 2" } 
                             };
            
            context.Courses.Local.First().Resources.Add(res[0]);
            context.Courses.Local.First().Resources.Add(res[1]);
            context.Courses.Local.Last().Resources.Add(res[2]);
            context.Courses.Local.Last().Resources.Add(res[3]);
        }

        private void SetCourses(SchoolDbContext context)
        {
            var ran = new Random();
            if (context.Courses.Any())
            {
                return;
            }

            Course[] courses = { 
                                   new Course() { Name = "C# 1", Description = "C# Proramming courses for beginners" },
                                   new Course() { Name = "HTML", Description = "HTML course for beginners" }};
            context.Courses.Add(courses[0]);
            context.Courses.Add(courses[1]);
            foreach (var student in context.Students.Local)
            {
                if(ran.Next(0, 2) == 1)
                {
                    student.Courses.Add(context.Courses.Local.First(c => c.Name == "HTML"));
                }
                else
                {
                    student.Courses.Add(context.Courses.Local.First(c => c.Name == "C# 1"));
                }
                
            }
        }

        private void SetStudents(SchoolDbContext context)
        {
            string[] first = { "Ivan", "Hristo", "Petar", "Dimitar", "Georgi" };
            string[] last = { "Ivanov", "Petrov", "Hristov", "Dimitrov", "Georgiev" };
            if (context.Students.Any())
            {
                return;
            }

            var ran = new Random();
            for (int i = 0; i < 20; i++)
            {
                context.Students.Add(new Student() { Name = first[ran.Next(0, 5)] + ' ' + last[ran.Next(0, 5)], Number = (12345 + ran.Next(0, 100)).ToString() });
            }
        }
    }
}
