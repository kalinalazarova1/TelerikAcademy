namespace _02.TestCourse
{
    using System;
    using _01.School;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseConstructorCreateStudentsHashSet()
        {
            var course = new Course();
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestCourseAddMoreThanMaximumStudents()
        {
            var course = new Course();
            for (int i = 0; i <= 30; i++)
            {
                var student = new Student(i.ToString(), 10000 + i);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseAddStudentNull()
        {
            var course = new Course();
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseAddStudentTwice()
        {
            var course = new Course();
            var student = new Student("Name", 12345);
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            var course = new Course();
            var student = new Student("Name", 12345);
            course.AddStudent(student);
            Assert.IsTrue(course.Students.Contains(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseRemoveStudentNull()
        {
            var course = new Course();
            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseRemoveMissingStudent()
        {
            var course = new Course();
            var student = new Student("Name", 12345);
            course.RemoveStudent(student);
        }

        [TestMethod]
        public void TestCourseRemoveStudent()
        {
            var course = new Course();
            var student = new Student("Name", 12345);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.IsFalse(course.Students.Contains(student));
        }
    }
}
