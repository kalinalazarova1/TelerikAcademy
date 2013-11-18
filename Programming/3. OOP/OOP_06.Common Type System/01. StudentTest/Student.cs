using System;
using System.Text;

namespace StudentCommon
{
    public class Student : ICloneable, IComparable<Student>
    {
        //fields:
        private string sSN;

        //properties:
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN           //assume that only SSN cannot be changed
        {
            get
            {
                return this.sSN;
            }
            private set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("The SSN could not be null or empty!");
                }
                else
                {
                    this.sSN = value;
                }
            }
        }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }
        public Specialty Specialty { get; set; }

        //constructors:
        public Student(string first,
                    string middle,
                    string last,
                    string socialNum,
                    University uni,
                    Faculty fac,
                    Specialty spec,
                    string course = null,
                    string address = null,
                    string phone = null,
                    string email = null)
        {
            this.FirstName = first;
            this.MiddleName = middle;
            this.LastName = last;
            this.University = uni;
            this.Faculty = fac;
            this.Specialty = spec;
            this.SSN = socialNum;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
        }

        //methods:
        public override bool Equals(Object obj)
        {
            Student student = obj as Student;
            if ((object)student == null)
            {
                return false;
            }
            if (this.SSN == student.SSN &&
                this.FirstName == student.FirstName &&
                this.MiddleName == student.MiddleName &&
                this.LastName == student.LastName)            //assume that SSN is unique for each person;
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.SSN.GetHashCode() ^ this.FirstName.GetHashCode() ^ this.MiddleName.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Student: {0} {1} {2}, SSN: {3}\nUniversity: {4}, Faculty: {5}, Specialty: {6}", this.FirstName, this.MiddleName, this.LastName, this.SSN, this.University, this.Faculty, this.Specialty);
        }

        public static bool operator == (Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator != (Student first, Student second)
        {
            return !(first.Equals(second));
        }

        public Student Clone()
        {
            return new Student(this.FirstName,
            this.MiddleName,
            this.LastName,
            this.SSN,
            this.University,
            this.Faculty,
            this.Specialty,
            this.Course,
            this.Address,
            this.Phone,
            this.Email
            );
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student other)
        {
            if(this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else if(this.MiddleName.CompareTo(other.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }
            else if(this.LastName.CompareTo(other.LastName) != 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            else
            {
                return this.SSN.CompareTo(other.SSN);
            }
        }
    }
}
