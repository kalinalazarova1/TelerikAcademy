using System;
using System.Collections.Generic;
using System.Text;

namespace School
{
    public class SchoolClass : SchoolObject
    {
        public static int ClassID { get; private set; }

        public string ClassIdentifier { get; private set; }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        public SchoolClass(List<Teacher> teachers)
            : this(teachers, new List<Student>(), null)
        {
        }

        public SchoolClass(List<Teacher> teachers, List<Student> students, string comment)
        {
            this.ClassIdentifier = 'A' + (ClassID + 1).ToString();
            ClassID++;
            this.Students = students;
            this.Teachers = teachers;
            base.Comment = comment;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            
                output.Append("Class: " + this.ClassIdentifier + '\n');
                if (base.Comment != null)
                {
                    output.Append("Comment: ");
                    output.Append(base.Comment);
                    output.Append("\n");
                }
                foreach (var student in this.Students)
                {
                    output.Append(student.ToString());
                }
                foreach (var teacher in this.Teachers)
                {
                    output.Append(teacher.ToString());
                }
                return output.ToString();
        }
    }
}
