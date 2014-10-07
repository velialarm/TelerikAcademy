using System;

    class Program
    {
        static void Main()
        {

            //Write a program to print the first 100 members of the 
            // sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

            int previous = -1;
            int next = 1;
            int position = 100;
            
            //Console.WriteLine("Enter the position");
            //position = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < position; i++)
            {
                int sum = next + previous; previous = next;
                next = sum;
                Console.WriteLine(next);
            }
           

    
        }
    }