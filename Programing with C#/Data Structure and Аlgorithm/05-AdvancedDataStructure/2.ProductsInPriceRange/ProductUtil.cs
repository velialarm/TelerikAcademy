namespace ProductsInPriceRange
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    using Product = System.Tuple<string, decimal>;

    /// <summary>
    /// 2. Task
    /// Write a program to read a large collection of products (name + price) and efficiently find the first 20 products in the price range [a…b]. 
    /// Test for 500 000 products and 10 000 price searches. 
    /// Hint: you may use OrderedBag<T> and sub-ranges.
    /// </summary>
    public class ProductUtil
    {
        static OrderedMultiDictionary<decimal, Product> byPrice = new OrderedMultiDictionary<decimal, Product>(true);

        public static string FindProductsByPriceRange(decimal min, decimal max)
        {
            var result = byPrice.Range(min, true, max, true).Values.OrderBy(p => p.Item2);
            if (!result.Any())
            {
                return "No products found";
            }
            return string.Join(Environment.NewLine, result);
        }

        public static string AddProduct(string name, decimal price)
        {
            var product = new Product(name, price);
            byPrice[price].Add(product);
            return "Product added";
        }
    }
}
