using System;
using System.Collections.Generic;
using System.Text;

namespace School
{
    public class Teacher : Person
    {
        public List<Discipline> Disciplines { get; set; }

        public Teacher(string firstName, string familyName, List<Discipline> disciplines)
            : this(firstName, familyName, disciplines, null)
        {
        }

        public Teacher(string firstName, string familyName, List<Discipline> disciplines, string comment)
            : base(firstName, familyName, comment)
        {
            this.Disciplines = disciplines;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (base.Comment == null)
            {
                output.Append(string.Format("Teacher: {0} {1}\n", base.FirstName, base.LastName));
            }
            else
            {
                output.Append(string.Format("Teacher: {0} {1}, Comment: {2}\n", base.FirstName, base.LastName, base.Comment));
            }
            foreach (var discipline in this.Disciplines)
            {
                output.Append(discipline.ToString());
            }
            return output.ToString();
        }
    }
}
