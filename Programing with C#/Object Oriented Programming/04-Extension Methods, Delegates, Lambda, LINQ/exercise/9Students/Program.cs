using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Students
{
    class Program
    {
        /**
         * Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
         * Create a List<Student> with sample students.
         * Select only the students that are from group number 2. 
         * Use LINQ query. Order the students by FirstName.
         */
        static void Main(string[] args)
        {
            List<Student> listStudents = new List<Student>();
            listStudents.Add(new Student("Ivan","Stoqnov",345,"03244444","ivan@gmail.com",new List<int>(){3,3,4,4},1));
            listStudents.Add(new Student("Pesho", "Petkov", 34, "03244444", "sdf@mail.bg", new List<int>() { 2, 3, 5, 4 }, 2));
            listStudents.Add(new Student("Muskala", "Papkova", 34, "02844444", "asdasd@abv.bg", new List<int>() { 3, 5, 5, 3 }, 2));
            listStudents.Add(new Student("Djovan", "Trabanov", 1234456, "02244444", "dfgerg@opa.bg", new List<int>() { 2, 3, 5, 4 }, 2));
            listStudents.Add(new Student("Opala", "trqss", 234, "024244444", "sdf@abv.bg", new List<int>() { 2, 4, 5, 6 }, 2));

            var result =
               from Students in listStudents
               where (Students.GroupNumber == 2)
               select Students;

           // var res3 = list_student.OrderByDescending(Student => Student.FirstName).ThenByDescending(Student => Student.LastName);
            Console.WriteLine("\n9 task Select only the students that are from group number 2 . Use LINQ query\n");
            Print(result);

            /**
             * Implement the previous using the same query expressed with extension methods.
             */
            Console.WriteLine("\n10 task Implement the previous using the same query expressed with extension methods.\n");
            var res1 = listStudents.Where(Students => Students.GroupNumber == 2);
           // res1.ThenByDescending(Student => Student.FirstName);
            Print(res1);
            /**
             * Extract all students that have email in abv.bg. Use string methods and LINQ.
             */
            Console.WriteLine("\n11 task Extract all students that have email in abv.bg. Use string methods and LINQ.\n");
            var resa =
                from Student in listStudents
                where (Student.Email.Contains("abv.bg"))
                select Student;
            Print(resa);
            /**
             * Extract all students with phones in Sofia. Use LINQ.
             */
            Console.WriteLine("\n12 task Extract all students with phones in Sofia. Use LINQ.\n");
            var resb =
               from Student in listStudents
               where (Student.Tel.StartsWith("02"))
               select Student;
            Print(resb);
            /**
             * Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
             */
            Console.WriteLine("\n13 task \n");
            var resc =
                from Student in listStudents
                where (Student.FirstName.Length > 0 && Student.Marks.Contains(6))
                select Student;
            Print(resc);
            /**
             * Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
             */
            Console.WriteLine("\n14 task \n");
            //listStudents.Where(Students => Students.Marks.);
            /**
             * Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
             */
            Console.WriteLine("\n15 task \n");
            /**
             * Write a program to return the string with maximum length from an array of strings. Use LINQ.
             */
            Console.WriteLine("\n17 task \n");
            /**
             * Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
             */
            Console.WriteLine("\n18 task \n");
            /**
             * Rewrite the previous using extension methods.
             */
            Console.WriteLine("\n19 task \n");
        }

        private static void Print(IEnumerable<Student> res1)
        {
            foreach (var item in res1)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.FirstName,item.LastName,item.Email,item.Tel);
            }
        }
    }
    class Student{
        public Student(string firstName,string lastname, int fn,string tel,string email,List<int> marks,int group )
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Fn = fn;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = group;
            this.Tel = tel;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Fn { get; set; }
        public string Tel { get; set; }
        public String Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
    }
}
