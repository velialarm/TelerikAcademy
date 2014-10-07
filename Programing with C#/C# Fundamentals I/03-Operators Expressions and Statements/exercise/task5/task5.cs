using System;

    class task5
    {
        static void Main()
        {
            //Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

            int number = int.Parse(Console.ReadLine());
            int mask = 1 << 3;
            Console.WriteLine("bit 3 of given integer is : {0}",(number & mask) != 0 ? 1 : 0);
        }
    }