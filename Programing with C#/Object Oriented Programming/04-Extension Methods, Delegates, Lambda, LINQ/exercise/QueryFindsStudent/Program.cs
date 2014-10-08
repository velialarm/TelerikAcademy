using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryFindsStudent
{
    class Program
    {
        static void Main(string[] args)
        {

            Students[] list_student = 
            {
                new Students("Kiril","Ivanov",13),
                new Students("Miga","Stoqnov",18),
                new Students("Kirkata","Maimunov",35),
                new Students("Stop","Gustav",17),
                new Students("Maina","Zaum",22)
            };
            /**
             * Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
             */

            var result =
                from Students in list_student
                where (Students.Age < 24 && Students.Age > 18)
                select Students;
        }
    }
}
