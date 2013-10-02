using System;
using System.Collections.Generic;
using System.Text;

namespace School
{
    public class School
    {
        public string Name { get; set; }
        public List<SchoolClass> AllClasses { get; set; }

        public School(string name) : this(name, new List<SchoolClass>())
        {
        }

        public School(string name, List<SchoolClass> currentList)
        {
            this.Name = name;
            this.AllClasses = currentList;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("School: " + this.Name + '\n');
            foreach (var schoolClass in this.AllClasses)
            {
                output.Append(schoolClass.ToString() + '\n');
            }
            return output.ToString();
        }
    }
}
