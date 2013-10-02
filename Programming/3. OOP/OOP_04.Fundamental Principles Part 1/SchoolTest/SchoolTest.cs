//1. We are given a school. In the school there are classes of students. Each class has a set of 
//teachers. Each teacher teaches a set of disciplines. Students have name and unique class number.
//Classes have unique text identifier. Teachers have name. Disciplines have name, number of 
//lectures and number of exercises. Both teachers and students are people. Students, classes, 
//teachers and disciplines could have optional comments (free text block). Your task is to 
//identify the classes (in terms of OOP) and their attributes and operations, encapsulate their
//fields, define the class hierarchy and create a class diagram with Visual Studio.



using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    public class SchoolTest
    {
        static void Main()
        {
            School MySchool = new School("Telerik Academy");
            Student[] myArrStudents = {new Student("Ivan","Ivanov","good skills"), new Student("Petya", "Nikolova"), 
                                       new Student("Stoyan","Stalev")};
            List<Student> myStudents = myArrStudents.ToList();
            List<Discipline> nakovDisciplines = new List<Discipline>();
            nakovDisciplines.Add(new Discipline("OOP", 10, 9));
            nakovDisciplines.Add(new Discipline("C#2", 10, 10));
            List<Discipline> nikiDisciplines = new List<Discipline>();
            nikiDisciplines.Add(new Discipline("OOP", 10, 9));
            nikiDisciplines.Add(new Discipline("C#1", 6, 6));
            Teacher[] myArrTeachers = { new Teacher("Svetlin", "Nakov", nakovDisciplines, "The boss"), new Teacher("Nikolay","Kostov", nikiDisciplines)};
            List<Teacher> myTeachers = myArrTeachers.ToList();
            SchoolClass myClass = new SchoolClass(myTeachers, myStudents, "test class");
            SchoolClass otherClass = new SchoolClass(myTeachers);
            MySchool.AllClasses.Add(myClass);
            MySchool.AllClasses.Add(otherClass);
            Console.WriteLine(MySchool);
        }
    }
}
