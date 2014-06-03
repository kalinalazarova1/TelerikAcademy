namespace Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Abstract class for course containing name of the course, name of the teacher and list of students.
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        /// Holds the list of the students.
        /// </summary>
        private IList<string> students;

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        /// <param name="students">List of the students.</param>
        /// <param name="teacher">Name of the teacher.</param>
        protected Course(string name, IList<string> students, string teacher)
        {
            if (name == null)
            {
                throw new ArgumentNullException("The course name colud not be null!", "name");   
            }

            this.Name = name;
            this.Students = students;
            this.TeacherName = teacher;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        /// <param name="students">List of the students.</param>
        protected Course(string name, IList<string> students)
            : this(name, students, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        /// <param name="teacher">Name of the teacher.</param>
        protected Course(string name, string teacher)
            : this(name, null, teacher)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Course"/> class.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        protected Course(string name)
            : this(name, null, null)
        {
        }

        /// <summary>
        /// Gets or sets the name of the course and could not be null.
        /// </summary>
        /// <value>Name of the course.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        /// <value>Name of the teacher.</value>
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or sets a list of students.
        /// </summary>
        /// <value>
        /// List of students.
        /// </value>
        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                if (value != null)
                {
                    this.students = value;
                }

                this.students = new List<string>();
            }
        }

        /// <summary>
        /// Overrides base ToString() an converts an instance of <see cref="Course"/> class into a string.
        /// </summary>
        /// <returns>An instance of <see cref="Course"/> class converted as a string.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(" { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        /// <summary>
        /// Converts the list of students into a string.
        /// </summary>
        /// <returns>String representing the list of the students.</returns>
        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
