using System;

namespace Animals
{
    public abstract class Animal : ISound       
    {
        private int age;
        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Invalid age value!");
                }
            }
        }

        public string Name { get; set; }

        private bool isMale;
        public bool IsMale
        {
            get
            {
                return this.isMale;
            }
        }

        protected Animal(string name, int age, bool isMale)
        {
            this.Age = age;
            this.Name = name;
            this.isMale = isMale;
        }

        abstract public void MakeSound();   //will  be implemented in the descendent classes

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.GetType().Name, this.Name);
        }

    }
}
