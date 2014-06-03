namespace Methods
{
    using System;

    /// <summary>
    /// Represents a student with name and additional information and methods for dealing with student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">String representing the first name of the student.</param>
        /// <param name="secondName">String representing the family name of the student.</param>
        public Student(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.LastName = secondName;
        }

        /// <summary>
        /// Gets or sets the first name of the student.
        /// </summary>
        /// <value>
        /// String representing the first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the family name of the student.
        /// </summary>
        /// <value>
        /// String representing the family name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets additional information for a student.
        /// </summary>
        /// <value>
        /// String with information for the student, ending with student's birth date.
        /// </value>
        public string OtherInfo { get; set; }

        /// <summary>
        /// Compares two students by their birth dates.
        /// </summary>
        /// <param name="other">The student for comparison.</param>
        /// <returns>Whether this instance is older than other student specified.</returns>
        public bool IsOlderThan(Student other)
        {
            DateTime firstDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));   // extracts and parses this instance birth date
            DateTime secondDate =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10)); // extracts and parses other student birth date
            return firstDate > secondDate;
        }
    }
}
