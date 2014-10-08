namespace Company.Importer.DataGenerator
{
    using System;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static readonly IRandomDataGenerator RandomGeneratorInstance = null;
        private readonly Random random;
      
        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                return RandomGeneratorInstance == null ? new RandomDataGenerator() : RandomGeneratorInstance;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }

        public DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var range = new TimeSpan(endDate.Ticks - startDate.Ticks);
            var randTimeSpan = new TimeSpan((long)(this.random.NextDouble() * range.Ticks)); 
            return startDate + randTimeSpan;
        }
    }
}
