namespace Courses
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used for creating offsite courses and inherits <see cref="Course"/> class.
    /// </summary>
    public class OffsiteCourse : Course
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse" /> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        /// <param name="students">List of students.</param>
        /// <param name="town">Name of the town.</param>
        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, students, teacherName)
        {
            this.Town = town;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse" /> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        /// <param name="students">List of students.</param>
        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName, students, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse" /> class.
        /// </summary>
        /// <param name="courseName">Name of the course.</param>
        /// <param name="teacherName">Name of the teacher.</param>
        public OffsiteCourse(string courseName, string teacherName)
            : this(courseName, teacherName, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OffsiteCourse" /> class.
        /// </summary>
        /// <param name="name">Name of the course.</param>
        public OffsiteCourse(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// Gets or sets the town of the course.
        /// </summary>
        /// <value>Name of the town.</value>
        public string Town { get; set; }

        /// <summary>
        /// Converts an object of the <see cref="OffsiteCourse"/> class into a string.
        /// </summary>
        /// <returns>String representing an object of the <see cref="OffsiteCourse"/> class.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");
            return result.ToString();
        }
    }
}
