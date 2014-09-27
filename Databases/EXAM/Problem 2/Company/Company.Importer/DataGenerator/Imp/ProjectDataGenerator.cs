namespace Company.Importer.DataGenerator.Imp
{
    using System;
    using System.Linq;
    using Company.Data;

    public class ProjectDataGenerator : DataGenerator, IDataGenerator
    {
        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities databaseStoreEntities, int countOfGeneratedObject)
            : base(randomDataGenerator, databaseStoreEntities, countOfGeneratedObject)
        {
        }

        public override void Generate()
        {
            var employersIds = this.Database.Employers.Select(e => e.Id).ToList();
            Console.WriteLine("Adding project");
            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50)
                };

                ///TODO check me what mean - inclusive – average of 5
                for (int j = 0; j < this.Random.GetRandomNumber(2, 20); j++)
                {
                    var startingDate = this.Random.GetRandomDate(new DateTime(1980, 1, 1), DateTime.Now);
                    var endingDate = this.Random.GetRandomDate(startingDate, new DateTime(2020, 12, 31));
                    while (startingDate >= endingDate)
                    {
                        endingDate = this.Random.GetRandomDate(startingDate, new DateTime(2020, 12, 31));
                    }

                    var emplProject = new EmployerProject
                    {
                        Project = project,
                        EmployerId = employersIds[this.Random.GetRandomNumber(0, employersIds.Count - 1)],
                        StartingDate = startingDate,
                        EndingDate = endingDate,
                    };
                }

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nProject added.");
        }
    }
}
