using System;

namespace HumanWorkerStudent
{
    abstract public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
