namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 5. Task 
    /// Write a program that removes from given sequence all negative numbers.
    /// </summary>
    class RemoveNegativeNumber
    {
        static void Main(string[] args)
        {
            List<int> enter = new List<int>();

            Console.WriteLine("Enter sequence in one line of numbers with space between them: ");
            string[] elements = Console.ReadLine().Split(' ');
            List<int> elem = new List<int>();

            for (int i = 0; i < elements.Length; i++)
            {
                elem.Add(int.Parse(elements[i]));
            }

            List<int> positiveNumbers = new List<int>();
            foreach (var number in elem)
            {
                if (number >= 0)
                {
                    positiveNumbers.Add(number);
                }
            }
            positiveNumbers.Sort();
            Console.Write("Result of positive number is: ");
            foreach (var number in positiveNumbers)
            {
                Console.Write("{0}; ",number);
            }

            Console.Read();
        }
    }
}