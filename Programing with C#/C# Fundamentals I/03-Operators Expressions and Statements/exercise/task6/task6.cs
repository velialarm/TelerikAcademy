using System;

    class task6
    {
        static void Main()
        {
            //Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

            int radius = 5;
            Console.WriteLine("Enter point x of circle:");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter point y of circle:");
            int y = int.Parse(Console.ReadLine());
            if ((x * x) + (y * y) <= radius * radius)
            {
                Console.WriteLine("The point is inside the circle");
            }
            else
            {
                Console.WriteLine("The point is outside the circle");
            }

        }
    }
