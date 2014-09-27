namespace ClientSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true; 
            this.AutomaticMigrationDataLossAllowed = true; 
            this.ContextKey = "ClientSystem.Data.StudentSystemDbContext";
        }

        /// <summary>
        /// 3. Task
        /// Seed the data with random values
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(StudentSystemDbContext context)
        {
            IList<Course> defaultStandards = new List<Course>();

            defaultStandards.Add(new Course(){Name = "Clean Code", Description = "learn how to write clean code ... " });
            defaultStandards.Add(new Course() { Name = "Java Script Testing", Description = "learn how to write clean code ... " });
            defaultStandards.Add(new Course() { Name = "Model Database", Description = "learn how to write clean code ... " });

            foreach (Course crs in defaultStandards)
            {
                context.Courses.Add(crs);
            }

            base.Seed(context);
        }
    }
}
