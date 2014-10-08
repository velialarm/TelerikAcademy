using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SchoolTest
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestSchoolDuplicateId()
    {
        School school = new School();

        school.AddStudent(new Student("Vankata", 50000));
        school.AddStudent(new Student("Mainata", 50000));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestStudentNullName()
    {
        new Student(null, 50000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestStudentIdOutOfRangeLowerLimit()
    {
        new Student("Pesho", 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void TestStudentIdOutOfRangeUpperLimit()
    {
        new Student("Pesho", 100000);
    }

    [TestMethod]
    public void TestCourseAddRemoveStudent()
    {
        Course course = new Course();

        for (int i = 0; i < Course.Capacity - 1; i++)
            course.AddStudents(new Student("Pesho", 50000));

        Student student = new Student("Pesho", 50000);

        course.AddStudents(student);
        course.AddStudents(student);
        course.AddStudents(student);

        course.RemoveStudent(student);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestCourseIsFull()
    {
        Course course = new Course();

        for (int i = 0; i < Course.Capacity; i++)
            course.AddStudents(new Student("Pesho", 50000 + i));

        course.AddStudents(new Student("Pesho", 50000 + Course.Capacity));
    }
}
