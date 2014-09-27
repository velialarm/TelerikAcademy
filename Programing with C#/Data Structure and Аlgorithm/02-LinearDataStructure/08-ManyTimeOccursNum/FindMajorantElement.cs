namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// *8. Task
    /// The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
    /// Write a program to find the majorant of given array (if exists). 
    /// Example:{2, 2, 3, 3, 2, 3, 4, 3, 3} ->3
    /// </summary>
    class FindMajorantElement
    {
        static void Main(string[] args)
        {
            int[] data = { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < data.Length; i++)
            {
                int number = data[i];
                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }
            }

            int n = (data.Length - 1) / 2 + 1;

            foreach (var map in result)
            {
                if (map.Value == n)
                {
                    Console.WriteLine("Majorant Element is: {0}", map.Key);
                }
            }
            Console.Read();
        }
    }
}