namespace _01.School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxCapacity = 30;

        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public HashSet<Student> Students { get; private set; }

        public void AddStudent(Student student)
        {
            if (this.Students.Count == Course.MaxCapacity)
            {
                throw new ApplicationException("The course maximum capacity is exceeded!");
            }

            if (student == null)
            {
                throw new ArgumentNullException("The student to be added could not be null!");
            }

            if (this.Students.Contains(student))
            {
                throw new InvalidOperationException(student.Name + " is already added in the course!");
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
                throw new InvalidOperationException("Could not remove " + student.Name + " which is not presented in the course!");
            }

            this.Students.Remove(student);
        }
    }
}
