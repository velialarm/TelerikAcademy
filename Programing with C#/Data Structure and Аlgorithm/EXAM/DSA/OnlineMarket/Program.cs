using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace OnlineMarket
{
    class Program
    {

        private static HashSet<string> productNames = new HashSet<string>();
        private static HashSet<string> existType = new HashSet<string>();
        private static List<Product> products = new List<Product>();

//        private static Dictionary<string, List<Product>>byType = new Dictionary<string, List<Product>>();
//        private static Dictionary<double, List<Product>> byPrice = new  Dictionary<double, List<Product>>();

        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
//            Console.SetIn(new StreamReader("../../input.txt"));

            string line = Console.ReadLine().Trim();
            while (line != "end")
            {
                // adds a new product to the market

                if (line.StartsWith("add"))
                {
                    bool prodBool = true;
                    var productsArr = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // check product
                    var productName = productsArr[1];
                    if (productNames.Contains(productName))
                    {
                        prodBool = false;
                    }
                    else
                    {
                        productNames.Add(productName);
                    }

                    //check	PRODUCT_PRICE
                    var productPrice = double.Parse(productsArr[2]);
                    if (0 >= productPrice && productPrice > 5000)
                    {
                        prodBool = false;
                    }

                    //check PROCUCT_TYPE 
                    var productType = productsArr[3];
                    var prodTyleLength = productType.Length;

                    if (3 >= prodTyleLength && prodTyleLength >= 20)
                    {
                        prodBool = false;
                    }

                    if (prodBool)
                    {
                        // add
                        var addText = string.Format("Ok: Product {0} added successfully", productName);
                        output.AppendLine(addText);
                        var product = new Product(productName, productPrice, productType);

                        products.Add(product);

//                        if (byType.ContainsKey(productType))
//                        {
//                            byType[productType].Add(product);
//                        }
//                        else
//                        {
//                            byType.Add(productType,new List<Product>(products));
//                        }
//
//                        if (byPrice.ContainsKey(productPrice))
//                        {
//                            byPrice[productPrice].Add(product);
//                        }
//                        else
//                        {
//                            byPrice.Add(productPrice, new List<Product>(products));
//                        }

                        
                        existType.Add(productType);
                    }
                    else
                    {
                        // error
                        var addTxt = string.Format("Error: Product {0} already exists", productName);
                        output.AppendLine(addTxt);
                    }

                    line = Console.ReadLine();
                    continue;
                }

                // filter by type 
                //lists the first 10 products that have the given PRODUCT_TYPE
                if (line.StartsWith("filter by type"))
                {
                    var type = line.Substring(("filter by type").Length).Trim();
                    if (existType.Contains(type))
                    {
                        //print result
//                        var resFilterType = byType[type].OrderBy(p => p.Price)
//                            .ThenBy(p => p.ProductName)
//                            .Take(10)
//                            .ToList();

                        List<Product> resFilterType = products
                            .Where(t => t.ProductType == type)
                            .OrderBy(p => p.Price)
                            .ThenBy(p => p.ProductName)
                            .Take(10)
                            .ToList();
                        var sb = ToText(resFilterType);
                        output.AppendLine(sb.ToString());
                    }
                    else
                    {
                        // print error
                        var errTypeTxt = string.Format("Error: Type {0} does not exists", type);
                        output.AppendLine(errTypeTxt);
                    }

                    line = Console.ReadLine();
                    continue;
                }

                //filter by price
                if (line.StartsWith("filter by price from"))
                {
                    // RANGE  - MIN_PRICE to MAX_PRICE 
                    var rangeFilterStr = line.Substring(("filter by price to").Length).Trim();
                    var ranges = rangeFilterStr.Split(' ');
                    if (ranges.Length > 2)
                    {
                        var minRangePrice = double.Parse(ranges[1]);
                        var maxRangePrice = double.Parse(ranges[3]);
                        //print result
                        List<Product> resFilterType = products
                            .Where(t => t.Price >= minRangePrice && t.Price <= maxRangePrice)
                            .OrderBy(p => p.Price)
                            .ThenBy(p => p.ProductName)
                            .Take(10)
                            .ToList();
                        var sb = ToText(resFilterType);
                        output.AppendLine(sb.ToString());
                    }
                    else
                    {
                        // MIN_PRICE
                        var minPrice = double.Parse(ranges[1]);
                        //print result
                        List<Product> resFilterType = products
                             .Where(t => t.Price > minPrice)
                            .OrderBy(p => p.Price)
                            .ThenBy(p => p.ProductName)
                             .Take(10)
                            .ToList();
                        var sb = ToText(resFilterType);
                        output.AppendLine(sb.ToString());
                    }

                    line = Console.ReadLine();
                    continue;
                }

                if (line.StartsWith("filter by price to"))
                {
                    //MAX_PRICE 
                    var toPriceFilter = line.Substring(("filter by price to").Length).Trim();
                    var maxPrice = double.Parse(toPriceFilter);
                    //print result
                    List<Product> resFilterType = products
                         .Where(t => t.Price < maxPrice)
                        .OrderBy(p => p.Price)
                        .ThenBy(p => p.ProductName)
                         .Take(10)
                        .ToList();
                    var sb = ToText(resFilterType);
                    output.AppendLine(sb.ToString());
                    line = Console.ReadLine();
                    continue;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static StringBuilder ToText(List<Product> resFilterType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Ok: ");
            for (int i = 0; i < resFilterType.Count; i++)
            {
                sb.Append(resFilterType[i].ProductName);
                sb.Append("(");
                sb.Append(resFilterType[i].Price);
                sb.Append(")");
                sb.Append(", ");
            }
            if (resFilterType.Count > 0)
            {
                sb.Length -= 2;
            }
            return sb;
        }
    }

    public class Product
    {
        public Product(string name, double price, string type)
        {
            this.ProductName = name;
            this.Price = price;
            this.ProductType = type;
        }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public string ProductType { get; set; }

//        public override int GetHashCode()
//        {
//            return this.ProductName.GetHashCode();
//        }
//
//        public int CompareTo(object obj)
//        {
//            throw new NotImplementedException();
//        }
    }
}
