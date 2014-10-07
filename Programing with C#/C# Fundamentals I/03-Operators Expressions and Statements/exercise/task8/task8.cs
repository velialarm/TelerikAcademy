using System;

    class Program
    {
        static void Main()
        {
            //Write an expression that calculates trapezoid's area by given sides a and b and height h.

            Console.WriteLine("Enter sides a of trapezoid: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter sides b of trapezoid: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter sides h of trapezoid: ");
            int h = int.Parse(Console.ReadLine());
            Console.WriteLine("Area of trapezoid is: {0}",((a + b) / 2) * h);
        }
    }
