namespace _01.School
{
    using System;

    public class Student
    {
        private const int MaxNumber = 99999;

        private const int MinNumber = 10000;

        private int number;

        private string name;

        public Student(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name could not be null or empty!");
                }

                this.name = value;
            }
        }
        
        public int Number
        {
            get 
            {
                return this.number;
            }

            set
            {
                if (value < Student.MinNumber || value > Student.MaxNumber)
                {
                    throw new ArgumentOutOfRangeException("The number of student" + this.Name +
                        "should be between 10000 and 99999!");                    
                }

                this.number = value;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Student;
            if (other == null)
            {
                throw new ArgumentException("The student for comparison have to be object of class Student!");
            }

            return this.Number.Equals(other.Number);
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode();
        }
    }
}
