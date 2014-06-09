// 1. Write three classes: Student, Course and School. Students should have name and unique number 
// (inside the entire School). Name can not be empty and the unique number is between 10000 and 99999.
// Each course contains a set of students. Students in a course should be less than 30 and can join and
// leave courses.
// 2. Write VSTT tests for these two classes
// Use 2 class library projects in Visual Studio: School.csproj and TestSchool.csproj
// 3. Execute the tests using Visual Studio and check the code coverage. Ensure it is at least 90%.

namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
            this.Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }

        public HashSet<Student> Students { get; private set; }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student to be added could not be null!");
            }

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException(student.Name + " is already added in the school!");
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student to be removed could not be null!");
            }

            if (!this.Students.Contains(student))
            {
                throw new InvalidOperationException("Could not remove " + student.Name + " which is not presented in the school!");
            }

            this.Students.Remove(student);
        }
    }
}
