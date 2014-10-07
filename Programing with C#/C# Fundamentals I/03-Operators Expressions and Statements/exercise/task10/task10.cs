using System;

    class task10
    {
        static void Main()
        {
            //Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. 
            //Example: v=5; p=1  false.

            Console.Write("Enter digit n: ");
            int n = int.Parse(Console.ReadLine()); // number
            sbyte p = 2; //possition
            int mask = 1 << p; 
            Console.WriteLine((n & mask) != 0 ? true : false);
        }
    }

