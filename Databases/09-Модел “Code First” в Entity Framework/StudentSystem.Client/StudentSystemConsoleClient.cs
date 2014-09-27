using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSystem.Data;
using StudentSystem.Model;

namespace StudentSystem.Client
{
    class StudentSystemConsoleClient
    {
        static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentSystemDbContext>());
                var student = new Student()
                {
                    Age = 30,
                    FirstName = "Pesho",
                    LastName = "Kasvotov"
                };
                db.Students.Add(student);
                db.SaveChanges();

                var savedStudent = db.Students.First();
                Console.WriteLine(savedStudent.Id + " - "+savedStudent.FirstName);
            }
        }
    }
}
