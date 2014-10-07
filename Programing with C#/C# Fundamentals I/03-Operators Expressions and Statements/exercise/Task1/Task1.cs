using System;



    class Program
    {
        static void Main()
        {
            //Write an expression that checks if given integer is odd or even.

            Console.Write("Enter number: ");
            int givenInt = int.Parse(Console.ReadLine());
            string res = givenInt % 2 == 1 ? "Odd" : "Even";
            Console.WriteLine("The number {0} is {1}",givenInt ,res);
        }
    }

