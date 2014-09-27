namespace DictionaryHashTableAndSetHW
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that counts in a given array of double values the number of occurrences of each value. 
    /// Use Dictionary<TKey,TValue>.
    /// Example: array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5} 
    /// -2.5 -> 2 times 
    /// 3 -> 4 times 
    /// 4 -> 3 times
    ///  </summary>
    class CountGivenArraw
    {
        static void Main(string[] args)
        {
            double[] inputValues = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Dictionary<double, int> resultMap = new Dictionary<double, int>();
            foreach (var item in inputValues)
            {
                int count = 0;
                if (resultMap.ContainsKey(item))
                {
                    count = resultMap[item];
                }
                resultMap[item] = count + 1;
            }

            var sortedDict = from entry in resultMap orderby entry.Value ascending select entry;
            foreach (var print in sortedDict)
            {
                Console.WriteLine("{0}  ->  {1}", print.Key, print.Value);
            }
        }
    }
}