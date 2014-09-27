namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 3. Task
    /// Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order
    /// </summary>
    class SortSequenceOfNumbers
    {
        static void Main(string[] args)
        {
            List<int> sortedList = new List<int>();
            Console.WriteLine("Enter positive intiger value or empty line for exit");

            while (true)
            {
                Console.Write("Enter number: ");
                string input = Console.ReadLine();
                if (input.Equals(""))
                {
                    break;
                }

                try
                {
                    sortedList.Add(int.Parse(input));
                }
                catch (Exception)
                {
                    throw new Exception("Invalid number...");
                }
            }
            sortedList.Sort();
            Console.WriteLine("Result is: ");
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.Write("{0}; ",sortedList[i]);
            }

            Console.Read();
        }
    }
}