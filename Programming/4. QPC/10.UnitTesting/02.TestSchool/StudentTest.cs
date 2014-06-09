namespace _02.TestSchool
{
    using System;
    using _01.School;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestConstructorStudentName()
        {
            string name = "Name";
            int number = 12345;
            var student = new Student(name, number);
            Assert.AreEqual("Name", student.Name);
        }

        [TestMethod]
        public void TestConstructorStudentNumber()
        {
            string name = "Name";
            int number = 12345;
            var student = new Student(name, number);
            Assert.AreEqual(12345, student.Number);
        }

        [TestMethod]
        public void TestSetStudentName()
        {
            string name = "Name";
            int number = 12345;
            var student = new Student(name, number);
            student.Name = "New Name";
            Assert.AreEqual("New Name", student.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStudentNameNull()
        {
            string name = null;
            int number = 12345;
            var student = new Student(name, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStudentNameEmpty()
        {
            string name = string.Empty;
            int number = 12345;
            var student = new Student(name, number);
        }

        [TestMethod]
        public void TestSetStudentNumber()
        {
            string name = "Name";
            int number = 12345;
            var student = new Student(name, number);
            student.Number = 11111;
            Assert.AreEqual(11111, student.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetStudentNumberLessThanMinimal()
        {
            string name = "Name";
            int number = 9999;
            var student = new Student(name, number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetStudentNumberMoreThanMaximal()
        {
            string name = "Name";
            int number = 100000;
            var student = new Student(name, number);
        }

        [TestMethod]
        public void TestStudentEqualsToOtherStudent()
        {
            string name = "Name";
            int number = 12345;
            string otherName = "Other name";
            var student = new Student(name, number);
            var otherStudent = new Student(otherName, number);
            Assert.AreEqual(student, otherStudent);
        }

        [TestMethod]
        public void TestStudentNotEqualsToOtherStudent()
        {
            string name = "Name";
            int number = 12345;
            string otherName = "Other name";
            int otherNumber = 99999;
            var student = new Student(name, number);
            var otherStudent = new Student(otherName, otherNumber);
            Assert.AreNotEqual(student, otherStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentEqualsToNull()
        {
            string name = "Name";
            int number = 12345;
            var student = new Student(name, number);
            Student otherStudent = null;
            student.Equals(otherStudent);
        }

        [TestMethod]
        public void TestStudentGetHashCode()
        {
            string name = "Name";
            int number = 12345;
            string otherName = "Other name";
            int otherNumber = 99999;
            var student = new Student(name, number);
            var otherStudent = new Student(otherName, otherNumber);
            Assert.AreNotEqual(student.GetHashCode(), otherStudent.GetHashCode());
        }
    }
}
