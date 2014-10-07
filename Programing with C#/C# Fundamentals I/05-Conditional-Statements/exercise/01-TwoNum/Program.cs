using System;

    class Program
    {
        static void Main()
        {
            //Write an if statement that examines two integer variables and exchanges their values 
            // if the first one is greater than the second one.

            Console.Write("Enter first digit: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second digit: ");
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine("First digit {0} is greater than second {1}",a,b);
            }
            else if (a < b)
            {
                Console.WriteLine("Second digit {0} is greater than first {1}", b, a);
            }
        }
    }
