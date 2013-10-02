using System;

namespace ArrayStudents
{
    public class Student
    {
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; } 

        public Student(string first, string last) : this(first, last, null)
        {
        }

        public Student(string first, string last, int? age)
        {
            this.FisrtName = first;
            this.LastName = last;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.FisrtName, this.LastName, this.Age);
        }
    }
}
