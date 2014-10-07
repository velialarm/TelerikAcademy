using System;

    class task4
    {
        static void Main()
        {
            //Write an expression that calculates rectangle’s area by given width and height.

            Console.Write("Enter reactanfle width: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Enter reactanfle height: ");
            int height = int.Parse(Console.ReadLine());
            int res = width * height;
            Console.WriteLine("Rectangle's area is {0}",res);
        }
    }

