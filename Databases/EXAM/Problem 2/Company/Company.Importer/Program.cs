namespace Company.Importer
{
    using System;
    using System.Collections.Generic;
    using Data;
    using DataGenerator;
    using DataGenerator.Imp;

    public class Program
    {
        public static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
                new DepartmentDataGenerator(random, db, 10),
                new EmployersDataGenerator(random, db, 500), 
                new ProjectDataGenerator(random,db, 100),
                new ReportDataGenerator(random,db,2500)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
