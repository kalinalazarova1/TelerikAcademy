namespace BinarySerialization
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Person // Originator class
    {
        public Person(string name, int age, bool isMale)
        {
            this.Name = name;
            this.Age = age;
            this.IsMale = true;
            this.Parents = new List<Parent>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsMale { get; set; }

        public List<Parent> Parents { get; set; }

        public void Add(Parent p)
        {
            this.Parents.Add(p);
        }

        public override string ToString()
        {
            return this.Name +
                "\n" +
                this.Age +
                " years old\n" +
                (this.IsMale ? "Male\n" : "Female\n") +
                this.Parents[0] + "\n" +
                this.Parents[1];
        }
    }
}
