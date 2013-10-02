using System;

namespace School
{
    public abstract class Person : SchoolObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected Person(string firstName, string familyName)
            : this(firstName, familyName, null)
        {
        }

        protected Person(string firstName, string familyName, string comment)
        {
            this.FirstName = firstName;
            this.LastName = familyName;
            base.Comment = comment;
        }
    }
}
