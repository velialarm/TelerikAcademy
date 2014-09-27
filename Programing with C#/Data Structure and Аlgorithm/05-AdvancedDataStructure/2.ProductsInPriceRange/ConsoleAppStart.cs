namespace ProductsInPriceRange
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));

            var output = new StringBuilder();

            for (string line = null; (line = Console.ReadLine()) != "End"; )
            {
                var match = line.Split(new[] { ' ' }, 2);
                var name = match[0];
                var parameters = match[1].Split(';');

                string result = null;

                switch (name)
                {
                    case "AddProduct":
                        result = ProductUtil.AddProduct(name: parameters[0], price: decimal.Parse(parameters[1]));
                        break;

                    case "FindProductsByPriceRange":
                        result = FindProductsByPriceRange(min: decimal.Parse(parameters[0]), max: decimal.Parse(parameters[1]));
                        break;

                    default:
                        throw new ArgumentException("Invalid command: " + name);
                }

                output.AppendLine(line);
                output.AppendLine(result);
                output.AppendLine();
            }

            Console.Write(output);
        }
    }
}