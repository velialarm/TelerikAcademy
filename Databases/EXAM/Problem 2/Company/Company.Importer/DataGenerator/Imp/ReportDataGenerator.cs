using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data;

namespace Company.Importer.DataGenerator.Imp
{
    public class ReportDataGenerator : DataGenerator, IDataGenerator
    {
        public ReportDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities databaseStoreEntities, int countOfGeneratedObject)
            : base(randomDataGenerator, databaseStoreEntities, countOfGeneratedObject)
        {
        }

        public override void Generate()
        {
            var employerIds = this.Database.Employers.Select(e => e.Id).ToList();
            var averageCoeficent = Math.Abs(this.Count / (employerIds.Count));
            var overflowIndexForAverage = 0;
            var emplIndex = 0;
            Console.WriteLine("Adding reports");
            for (int i = 0; i < this.Count; i++)
            {
                if (averageCoeficent < overflowIndexForAverage)
                {
                    emplIndex += averageCoeficent;
                    overflowIndexForAverage++;
                    emplIndex++;
                }
                var currEmpl = employerIds[emplIndex];
                var report = new Report
                {
                    CreatedDate = this.Random.GetRandomDate(new DateTime(1980, 1, 1), DateTime.Now),
                    EmployerId = currEmpl
                };
                this.Database.Reports.Add(report);

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nReports added.");
        }
    }
}
