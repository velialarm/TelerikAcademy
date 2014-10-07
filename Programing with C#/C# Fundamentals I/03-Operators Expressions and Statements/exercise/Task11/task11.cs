using System;

    class task11
    {
        static void Main()
        {
            //Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 -> value=1.

            Console.Write("Enter integer digit i: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("Enter bit number b: ");
            int b = int.Parse(Console.ReadLine());
            int mask = 1 << b;
            Console.WriteLine("value={0}",((i & mask) != 0 ? 1 : 0));
        }
    }

