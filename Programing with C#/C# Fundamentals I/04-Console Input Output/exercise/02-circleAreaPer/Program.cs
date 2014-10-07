using System;

    class Program
    {
        static void Main()
        {
            //Write a program that reads the radius r of a circle and prints its perimeter and area.

            Console.Write("Enter radius of circle: ");
            decimal r = decimal.Parse(Console.ReadLine());
            decimal area = (decimal)(Math.PI) + (r * r);
            decimal perim = 2 * (decimal)(Math.PI) * r;
            Console.WriteLine("Area of circle is: {0}",area);
            Console.WriteLine("Perimetar of circle is: {0}",perim);

        }
    }

