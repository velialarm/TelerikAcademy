using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads a number N and calculates the sum of the first N members 
            // of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
            // Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.

            Console.WriteLine("This calculates the first N members of the sequence of Fibonacci for N >= 2");
            // sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
            Console.WriteLine("Enter N");
            int n = int.Parse(Console.ReadLine());
            int first = 0; 
            int second = 1;
            int tmp = 0; 
            int sum = 0;
            
            for (int i = 0; i < n; i++)
            {
                tmp = first;
                first = second;
                second += tmp;

                sum += tmp;
            }

            Console.WriteLine("The sum of the element to N is {0}.", sum);
        }
    }
