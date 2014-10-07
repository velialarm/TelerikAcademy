using System;

    class task7
    {
        static void Main()
        {
            //Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

            Console.WriteLine("Enter integer digit to check:");
            int n = int.Parse(Console.ReadLine());
            bool prime = true;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            Console.WriteLine(prime); 
        }
    }
