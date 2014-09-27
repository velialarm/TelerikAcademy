namespace DataStructureEfficiency
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class StudentCourse
    {
        private readonly static OrderedMultiDictionary<string, Student> ByCourse = new OrderedMultiDictionary<string, Student>(true);

        public static string FindStudentsByCourse(string course)
        {
            var result = ByCourse[course];
            if (!result.Any())
            {
                return "No students found";
            }

            return string.Join(", ", result);
        }

        public static string AddStudent(string firstName, string lastName, string course)
        {
            var student = new Student(firstName, lastName);
            ByCourse[course].Add(student);
            return "Student added";
        }

        public static void Main()
        {
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
            for (string line = null; (line = Console.ReadLine()) != null; )
            {
                var match = line.Split('|').Select(m => m.Trim()).ToArray();
                AddStudent(firstName: match[0], lastName: match[1], course: match[2]);
            }

            Console.WriteLine(string.Join(Environment.NewLine, ByCourse.Keys.Select(course => string.Format("{0}: {1}", course, FindStudentsByCourse(course)))));
        }
    }
}