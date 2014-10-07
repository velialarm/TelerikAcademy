using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:

            Console.Write("Enter row (max is 20) : ");
            int n = int.Parse(Console.ReadLine());
            int k=n;
            for (int i = 0; i < n; i++)
            {
                // Console.Write("{0}    ", i);
                for (int column = i+1; column <= n + i; column++)
                {
                    Console.Write("{0}  ",column);   
                }
                Console.WriteLine();
            }
        }
    }
