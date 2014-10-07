using System;



    class task2
    {
        static void Main()
        {
            //Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.
            Console.Write("Enter number: ");
            int givInt = int.Parse(Console.ReadLine());
            bool res = givInt % 5 == 0 && givInt % 7 == 0;
            Console.WriteLine("Integer {1} can be divided (without remainder) \nby 7 and 5 in the same time \n-> {0}", res, givInt);
        }
    }
