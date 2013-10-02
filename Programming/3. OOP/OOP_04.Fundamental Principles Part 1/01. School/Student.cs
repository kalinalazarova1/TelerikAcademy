using System;

namespace School
{
    public class Student : Person
    {
        public static int StudentID { get; private set; }

        public int StudentNumber { get; private set; }

        public Student(string firstName, string familyName, string comment) : base(firstName, familyName, comment)
        {
            this.StudentNumber = StudentID;
            StudentID++;
        }

        public Student(string firstName, string familyName)
            : this(firstName, familyName, null)
        {
        }

        public override string ToString()
        {
            if (base.Comment == null)
            {
                return string.Format("Student: {0} {1}, ID: {2}\n", base.FirstName, base.LastName, this.StudentNumber);
            }
            else
            {
                return string.Format("Student: {0} {1}, ID: {2}, Comment: {3}\n", base.FirstName, base.LastName,this.StudentNumber, base.Comment);
            }
        }
    }
}
