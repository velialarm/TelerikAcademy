using System;
using System.Collections.Generic;
using System.Linq;


namespace QueryFindsStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            Students[] list_student = 
            {
                new Students("Kiril","Ivanov",12),
                new Students("Miga","Stoqnov",45),
                new Students("Kirkata","Maimunov",23),
                new Students("Stop","Gustav",36),
                new Students("Maina","Zaum",33)
            };
            /**
             * Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators.
             */
            var res1 = list_student.Where(Students => Students.FirstName.CompareTo(Students.LastName) == -1);
            Print(res1);

            Console.WriteLine("**************************    Exercise 3    ***************************");
            /**
             * Write a LINQ query that finds the first name and last name of all students with age between 18 and 24
             */
            var res2 = list_student.Where(Students => 18 < Students.Age && Students.Age < 24);
            Print(res2);
            Console.WriteLine("*************************   Exercise 4    ****************************");

            /**
             * Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students 
             * by first name and last name in descending order. 
             * Rewrite the same with LINQ.
             */
            var res3 = list_student.OrderByDescending(Student => Student.FirstName).ThenByDescending( Student => Student.LastName);
            Print(res3);
            Console.WriteLine("*************************   Exercise 5    ****************************");

            Print(
            from Student in list_student

            orderby Student.FirstName descending,
                    Student.LastName descending

            select Student);
            Console.WriteLine("*****************************************************");
        }

        static void Print(IEnumerable<Students> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine("{0} {1}",item.FirstName,item.LastName);
            }

        }

        class Students
        {

            public Students(string firstName, string lastName,int age)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}
