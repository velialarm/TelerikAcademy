using System;

    class task4
    {
        static void Main()
        {
            //Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true.

            Console.Write("Enter integer digit for check: ");
            int number = int.Parse(Console.ReadLine());
            bool res = (number/100) % 10 == 7;
            Console.WriteLine("{0} -> {1}", number,res);
        }
    }

