using System;

    class Program
    {
        static void Main( )
        {
            //Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.

            Console.Write("Enter first digit: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second digit: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter third digit: ");
            int c = int.Parse(Console.ReadLine());

            if ((a < 0 && b < 0 && c < 0) ||
                (a < 0 && b > 0 && c > 0) ||
                (a > 0 && b < 0 && c > 0) ||
                (a > 0 && b > 0 && c < 0))
            {
                Console.WriteLine("Result is minus");
            }
            else 
            {
                Console.WriteLine("Result is plus");
            }
        }
    }
