using ClientSystem.Data.Migrations;

namespace ClientSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Model;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
            : base("StudentSystemHW")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentSystemDbContext>());
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
