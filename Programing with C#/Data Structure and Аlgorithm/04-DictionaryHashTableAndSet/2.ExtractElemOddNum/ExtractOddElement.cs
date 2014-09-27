namespace DictionaryHashTableAndSetHW
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. 
    /// Example: {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
    /// </summary>
    class ExtractOddElement
    {
        static void Main(string[] args)
        {
            string[] text = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            Dictionary<string, int> data = new Dictionary<string, int>();
            int count = 0;
            foreach (var item in text)
            {
                if (data.ContainsKey(item))
                {
                    count = data[item];
                }
                data[item] = count + 1;
            }
           
            foreach (var item in data)
            {
                if (item.Value % 2 == 1)
                {
                    Console.Write("{0}, ",item.Key);
                }
            }
        }
    }
}