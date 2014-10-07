using System;

    class Program
    {
        static void Main()
        {
            //Write a program that finds the biggest of three integers using nested if statements.

            Console.Write("Enter first digit: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second digit: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter third digit: ");
            int c = int.Parse(Console.ReadLine());

            if ((a > b && a > c))
            {
                Console.WriteLine("The bigest digit is first");
            } else if ((b > a && b > c))
            {
                Console.WriteLine("The bigest digit is second");
            }else if((c > a && c > b))
            {
                Console.WriteLine("The bigest digit is third");
            }
        }
    }
