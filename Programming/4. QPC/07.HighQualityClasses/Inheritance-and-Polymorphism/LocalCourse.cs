namespace Courses
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used for creating local courses and inherits <see cref="Course"/> class.
    /// </summary>
    public class LocalCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        /// <param name="students">List of students.</param>
        /// <param name="lab">Name of the lab.</param>
        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, students, teacherName)
        {
            this.Lab = lab;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        public LocalCourse(string courseName, string teacherName)
            : this(courseName, teacherName, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalCourse"/> class.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        public LocalCourse(string name)
            : this(name, null, null, null)
        {
        }

        /// <summary>
        /// Gets or sets the name of the lab.
        /// </summary>
        /// <value>The name of the lab.</value>
        public string Lab { get; set; }

        /// <summary>
        /// Converts an object of the <see cref="LocalCourse"/> class into a string.
        /// </summary>
        /// <returns>String representing an object of the <see cref="LocalCourse"/> class.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
