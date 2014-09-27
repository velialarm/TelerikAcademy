namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 7.Task
    /// Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
    /// </summary>
    class NumberOccur
    {
        static void Main(string[] args)
        {
            int[] data = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

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

            foreach (var numberMap in result)
            {
                Console.WriteLine("{0} -> {1} times",numberMap.Key,numberMap.Value);
            }
            Console.Read();
        }
    }
}