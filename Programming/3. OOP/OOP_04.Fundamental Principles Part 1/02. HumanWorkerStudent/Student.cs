using System;

namespace HumanWorkerStudent
{
    public class Student : Human
    {
        private int grade;
        public int Grade 
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid grade value!");
                }
                else
                {
                    this.grade = value;
                }
            }
        }

        public Student(string first, string last, int grade) : base(first, last)
        {
            this.Grade = grade;
        }
    }
}
