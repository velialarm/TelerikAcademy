namespace Company.Importer.DataGenerator.Imp
{
    using System;
    using System.Collections.Generic;
    using Data;

    public class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities databaseStoreEntities, int countOfGeneratedObject)
            : base(randomDataGenerator, databaseStoreEntities, countOfGeneratedObject)
        {
        }

        public override void Generate()
        {
            var departmentNames = new HashSet<string>();

            while (departmentNames.Count != this.Count)
            {
                departmentNames.Add(this.Random.GetRandomStringWithRandomLength(5, 50));
            }

            Console.WriteLine("Adding department");
            var index = 0;
            foreach (var departmentName in departmentNames)
            {
                var department = new Department
                {
                    Name = departmentName
                };
                
                this.Database.Departments.Add(department);
                if (index % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                index++;
            }

            Console.WriteLine("\nDepartment added");
        }
    }
}
