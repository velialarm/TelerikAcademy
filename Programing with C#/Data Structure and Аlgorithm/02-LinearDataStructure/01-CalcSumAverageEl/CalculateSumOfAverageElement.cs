namespace LinearDataStructuresHomework
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    /// <summary>
    /// 1. Task
    /// Write a program that reads from the console a sequence of positive integer numbers. 
    /// The sequence ends when empty line is entered. 
    /// Calculate and print the sum and average of the elements of the sequence. 
    /// Keep the sequence in List<int>. 
    /// </summary>
    class CalculateSumOfAverageElement
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Enter positive intiger value or empty line for exit");
            Console.WriteLine(new string('-', 20));
            while (true)
            {
                Console.Write("Enter positive intiger or empty for exit: ");
                string input = Console.ReadLine();
                if (input.Equals(""))
                {
                    break;
                }
                try
                {
                    int res = int.Parse(input);
                    
                    if (res < 0)
                    {
                        Console.WriteLine("Negative number is not allowed.");
                        continue;
                    }
                    list.Add(res);
                }
                catch (Exception)
                {
                    throw new Exception("You enter invalid number.");
                }
            }

            BigInteger sum = 0;
            foreach (var number in list)
            {
                sum += number;
            }
            Console.WriteLine("Sum of elements is {0}", sum);
            Console.WriteLine("End.");

        }
    }
}