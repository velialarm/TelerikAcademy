using System;

    class Program
    {
        static void Main()
        {
            //Write a program that gets two numbers from the console and prints the greater of them. 
            // Don’t use if statements.

            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());

            while (a > b)
            {
                Console.WriteLine("Greater digit is first number:  {0}",a);
                break;

            }
            while (a < b)
            {
                Console.WriteLine("Greater digit is second number:  {0}", b);
                break;
            
            }
        }
    }
