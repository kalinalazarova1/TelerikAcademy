using System;

namespace PersonTest
{
    public class Person
    {
        //fields:
        private string name;

        //properties:
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("The name of the person must be specified!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int? Age { get; set; }

        //constructors:
        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
            : this(name, null)
        {
        }

        //methods:
        public override string ToString()
        {
             return string.Format("Name: {0}, Age: {1}", this.Name, this.Age == null ? "not specified" : this.Age.ToString());
        }
    }
}
