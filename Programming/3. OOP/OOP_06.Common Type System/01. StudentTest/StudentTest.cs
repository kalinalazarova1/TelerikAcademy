//1.Define a class Student, which contains data about a student – first, middle and last name, SSN, 
//permanent address, mobile phone e-mail, course, specialty, university, faculty. Use an enumeration 
//for the specialties, universities and faculties. Override the standard methods, inherited by 
//System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.
//2.Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's
//fields into a new object of type Student.
//3.Implement the  IComparable<Student> interface to compare students by names (as first criteria,
//in lexicographic order) and by social security number (as second criteria, in increasing order).

using System;

namespace StudentCommon
{
    class StudentTest
    {
        static void Main()
        {
            Student[] test = new Student[3];
            test[0] = new Student("Silvia", "Petrova", "Todorova", "12345679", University.NBU, Faculty.EarthSciences, Specialty.Geography);
            test[1] = new Student("Ivan", "Mladenov", "Grozev", "12345678",University.NBU,Faculty.EarthSciences,Specialty.Chemistry);
            test[2] = new Student("Ognyan", "Zarev", "Tonev", "09945678", University.NBU, Faculty.Informatics, Specialty.SoftwareEngineering);
            foreach (Student student in test)
            {
                Console.WriteLine(student);
                Console.WriteLine("Hash code: {0}", student.GetHashCode());
            }
            Console.WriteLine();
            Array.Sort(test);
            Console.WriteLine("Sorted students:");
            foreach (Student student in test)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Console.WriteLine("Original:\n{0}",test[0]);
            Student studentClone = test[0].Clone();
            Console.WriteLine("Clone:\n{0}", studentClone);
            Console.WriteLine();
            Console.WriteLine("The original and its clone are equal: {0}", studentClone.Equals(test[0]));
            studentClone.FirstName = "Stoyan";
            Console.WriteLine();
            Console.WriteLine("First name changed in clone, no change in original:");
            Console.WriteLine("Original:\n{0}", test[0]);
            Console.WriteLine("Clone:\n{0}", studentClone);
        }
    }
}
