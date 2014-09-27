namespace Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program based on dynamic programming to solve the "Knapsack Problem": 
    /// you are given N products, each has weight Wiand costs Ciand a knapsack of Capacity M 
    /// and you want to put inside a subset of the products with highest cost and weight ≤ M. 
    /// The numbers N, M, Wiand Ciare integers in the range [1..500]. 
    /// Example: M=10kg, N=6, products:
    ///  * beer – weight=3, cost=2 
    ///  *  vodka –weight=8, cost=12
    ///  * cheese –weight=4, cost=5
    ///  * nuts –weight=1, cost=4
    ///  * ham –weight=2, cost=3
    ///  * whiskey –weight=8, cost=13
    /// </summary>
    public class Program
    {
        private const int Capacity = 10;

        private static Product[] allProducts;

        private static int[,] valueTable;

        private static int[,] keepTable;

        public static void Main()
        {
            allProducts = new Product[]
            {
                new Product("beer", 3, 2),
                new Product("vodka", 8, 12),
                new Product("cheese", 4, 5),
                new Product("nuts", 1, 4),
                new Product("ham", 2, 3),
                new Product("whiskey", 8, 13),
            };

            valueTable = new int[allProducts.Length + 1, Capacity + 1];

            for (int prod = 1; prod < valueTable.GetLength(0); prod++)
            {
                for (int cap = 1; cap < valueTable.GetLength(1); cap++)
                {
                    int upperValue = valueTable[prod - 1, cap];
                    int currentValue = GetValueForCurrentCapacity(prod, cap);
                    valueTable[prod, cap] = Math.Max(upperValue, currentValue);
                }
            }

            var usedProducts = GetUsedProductsArray();

            PrintResults(usedProducts);
        }

        private static void PrintResults(IEnumerable<Product> usedProducts)
        {
            var usedSpace = 0;
            var totalCost = 0;

            foreach (var item in usedProducts)
            {
                Console.WriteLine(item);
                usedSpace += item.Weight;
                totalCost += item.Cost;
            }

            Console.WriteLine("Total weight: {0}", usedSpace);
            Console.WriteLine("Total cost: {0}", totalCost);
        }

        private static IEnumerable<Product> GetUsedProductsArray()
        {
            var usedProducts = new List<Product>();

            var leftWeight = Capacity;
            var itemIndex = allProducts.Length;

            while (itemIndex > 0)
            {
                if (valueTable[itemIndex, leftWeight] != valueTable[itemIndex - 1, leftWeight])
                {
                    usedProducts.Add(allProducts[itemIndex - 1]);
                    leftWeight -= allProducts[itemIndex - 1].Weight;
                }

                itemIndex--;
            }

            return usedProducts;
        }

        private static int GetValueForCurrentCapacity(int prod, int cap)
        {
            int productIndex = prod - 1;

            if (allProducts[productIndex].Weight <= cap)
            {
                return allProducts[productIndex].Cost + valueTable[prod - 1, cap - allProducts[productIndex].Weight];
            }

            return 0;
        }
    }
}