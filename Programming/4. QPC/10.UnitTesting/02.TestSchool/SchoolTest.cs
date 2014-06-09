namespace _02.TestSchool
{
    using System;
    using _01.School;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestSchoolConstructorCreateCoursesList()
        {
            var school = new School();
            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        public void TestSchoolConstructorCreateStudentsHashSet()
        {
            var school = new School();
            Assert.AreEqual(0, school.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSchoolAddStudentNull()
        {
            var school = new School();
            school.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSchoolAddStudentTwice()
        {
            var school = new School();
            var student = new Student("Name", 12345);
            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        public void TestSchoolAddStudent()
        {
            var school = new School();
            var student = new Student("Name", 12345);
            school.AddStudent(student);
            Assert.IsTrue(school.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSchoolRemoveStudentNull()
        {
            var school = new School();
            school.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSchoolRemoveMissingStudent()
        {
            var school = new School();
            var student = new Student("Name", 12345);
            school.RemoveStudent(student);
        }

        [TestMethod]
        public void TestSchoolRemoveStudent()
        {
            var school = new School();
            var student = new Student("Name", 12345);
            school.AddStudent(student);
            school.RemoveStudent(student);
            Assert.IsFalse(school.Students.Contains(student));
        }
    }
}
