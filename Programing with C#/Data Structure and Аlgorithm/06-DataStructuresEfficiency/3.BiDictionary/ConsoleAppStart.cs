namespace DataStructureEfficiency
{
    using System;

   public  class Program
    {
       public static void Main()
        {
            var bidictionary = new BiDictionary<string, int, string>(allowDuplicateValues: true);

            bidictionary.Add("pesho", 1, "JavaScript");
            bidictionary.Add("gosho", 2, "Java");
            bidictionary.Add("nakov", 3, "C#");
            bidictionary.Add("nakov", 3, "C#");
            bidictionary.Add("gosho", 3, "Coffee");
            bidictionary.Add("nakov", 1, "Python");

            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstKey("nakov")));
            Console.WriteLine(string.Join(" ", bidictionary.GetBySecondKey(3)));
            Console.WriteLine(string.Join(" ", bidictionary.GetByFirstAndSecondKey("nakov", 3)));

            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstKey("gosho");
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveBySecondKey(3);
            Console.WriteLine(bidictionary.Count);

            bidictionary.RemoveByFirstAndSecondKey("nakov", 1);
            Console.WriteLine(bidictionary.Count);
        }
    }
}