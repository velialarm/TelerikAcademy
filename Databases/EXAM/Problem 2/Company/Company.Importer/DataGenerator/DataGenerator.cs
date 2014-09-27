namespace Company.Importer.DataGenerator
{
    using Data;

    public abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities databaseStoreEntities, int countOfGeneratedObject)
        {
            this.random = randomDataGenerator;
            this.db = databaseStoreEntities;
            this.count = countOfGeneratedObject;
        }

        public CompanyEntities Database
        {
            get { return this.db; }
        }

        public int Count
        {
            get { return this.count; }
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        public abstract void Generate();
    }
}
