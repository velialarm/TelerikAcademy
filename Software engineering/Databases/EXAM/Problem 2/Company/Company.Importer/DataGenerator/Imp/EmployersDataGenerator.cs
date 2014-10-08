namespace Company.Importer.DataGenerator.Imp
{
    using System;
    using System.Linq;
    using Data;

    public class EmployersDataGenerator : DataGenerator, IDataGenerator
    {
        public EmployersDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities databaseStoreEntities, int countOfGeneratedObject)
            : base(randomDataGenerator, databaseStoreEntities, countOfGeneratedObject)
        {
        }

        public override void Generate()
        {
            var departmentIds = this.Database.Departments.Select(d => d.Id).ToList();

            Console.WriteLine("Adding employers");
            for (int i = 0; i < this.Count; i++)
            {
                var employer = new Employer
                {
                    DepartmerntId = departmentIds[this.Random.GetRandomNumber(0, departmentIds.Count - 1)],
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    Salary = this.Random.GetRandomNumber(50000, 200000)
                };

                //// Add managers
                if (this.Random.GetRandomNumber(0, 100) < 95)
                {
                    ////TODO 
                }

                this.Database.Employers.Add(employer);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nEmployers added.");
        }
    }
}
